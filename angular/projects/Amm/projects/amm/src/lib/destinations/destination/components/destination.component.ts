import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetDestinationsInput,
  DestinationWithNavigationPropertiesDto,
} from '../../../proxy/destinations/models';
import { DestinationService } from '../../../proxy/destinations/destination.service';

@Component({
  selector: 'lib-destination',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './destination.component.html',
  styles: [],
})
export class DestinationComponent implements OnInit {
  data: PagedResultDto<DestinationWithNavigationPropertiesDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetDestinationsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected?: DestinationWithNavigationPropertiesDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: DestinationService,
    private confirmation: ConfirmationService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    const getData = (query: ABP.PageQueryParams) =>
      this.service.getList({
        ...query,
        ...this.filters,
        filterText: query.filter,
      });

    const setData = (list: PagedResultDto<DestinationWithNavigationPropertiesDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetDestinationsInput;
  }

  buildForm() {
    const {
      city,
      cityLocalName,
      latitude,
      longitude,
      videoUrl,
      placeId,
      destCountry,
    } = this.selected?.destination || {};

    this.form = this.fb.group({
      city: [city ?? null, [Validators.required, Validators.maxLength(128)]],
      cityLocalName: [cityLocalName ?? null, [Validators.required, Validators.maxLength(128)]],
      latitude: [latitude ?? null, [Validators.required]],
      longitude: [longitude ?? null, [Validators.required]],
      videoUrl: [videoUrl ?? null, [Validators.maxLength(500)]],
      placeId: [placeId ?? null, [Validators.required, Validators.maxLength(50)]],
      destCountry: [destCountry ?? null, [Validators.required]],
    });
  }

  hideForm() {
    this.isModalOpen = false;
    this.form.reset();
  }

  showForm() {
    this.buildForm();
    this.isModalOpen = true;
  }

  submitForm() {
    if (this.form.invalid) return;

    const request = this.selected
      ? this.service.update(this.selected.destination.id, this.form.value)
      : this.service.create(this.form.value);

    this.isModalBusy = true;

    request
      .pipe(
        finalize(() => (this.isModalBusy = false)),
        tap(() => this.hideForm()),
      )
      .subscribe(this.list.get);
  }

  create() {
    this.selected = undefined;
    this.showForm();
  }

  update(record: DestinationWithNavigationPropertiesDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: DestinationWithNavigationPropertiesDto) {
    this.confirmation.warn(
      'Amm::DeleteConfirmationMessage',
      'Amm::AreYouSure',
      { messageLocalizationParams: [] }
    ).pipe(
      filter(status => status === Confirmation.Status.confirm),
      switchMap(() => this.service.delete(record.destination.id)),
    ).subscribe(this.list.get);
  }
}
