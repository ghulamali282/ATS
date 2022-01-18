import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetCruisesInput,
  CruiseWithNavigationPropertiesDto,
} from '../../../proxy/cruises/models';
import { CruiseService } from '../../../proxy/cruises/cruise.service';

@Component({
  selector: 'lib-cruise',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './cruise.component.html',
  styles: [],
})
export class CruiseComponent implements OnInit {
  data: PagedResultDto<CruiseWithNavigationPropertiesDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetCruisesInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected?: CruiseWithNavigationPropertiesDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: CruiseService,
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

    const setData = (list: PagedResultDto<CruiseWithNavigationPropertiesDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetCruisesInput;
  }

  buildForm() {
    const {
      season,
      cruiseEnabled,
      featured,
      freeInternetOnBoard,
      internetOnBoard,
      video,
      b2B,
      b2C,
      b2B_Agent,
      b2C_Agent,
      cruiseDescriptions,
      shipAmenities,
      shipArticles,
      shipPhotos,
      cabinAmenities,
      cabinArticles,
      cabinPhotos,
      ship,
      itinerary,
    } = this.selected?.cruise || {};

    this.form = this.fb.group({
      season: [season ?? null, [Validators.required]],
      cruiseEnabled: [cruiseEnabled ?? false, [Validators.required]],
      featured: [featured ?? false, [Validators.required]],
      freeInternetOnBoard: [freeInternetOnBoard ?? false, [Validators.required]],
      internetOnBoard: [internetOnBoard ?? false, [Validators.required]],
      video: [video ?? null, [Validators.maxLength(500)]],
      b2B: [b2B ?? false, [Validators.required]],
      b2C: [b2C ?? false, [Validators.required]],
      b2B_Agent: [b2B_Agent ?? false, [Validators.required]],
      b2C_Agent: [b2C_Agent ?? false, [Validators.required]],
      cruiseDescriptions: [cruiseDescriptions ?? null, []],
      shipAmenities: [shipAmenities ?? null, []],
      shipArticles: [shipArticles ?? null, []],
      shipPhotos: [shipPhotos ?? null, []],
      cabinAmenities: [cabinAmenities ?? null, []],
      cabinArticles: [cabinArticles ?? null, []],
      cabinPhotos: [cabinPhotos ?? null, []],
      ship: [ship ?? null, [Validators.required]],
      itinerary: [itinerary ?? null, [Validators.required]],
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
      ? this.service.update(this.selected.cruise.id, this.form.value)
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

  update(record: CruiseWithNavigationPropertiesDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: CruiseWithNavigationPropertiesDto) {
    this.confirmation.warn(
      'Ccm::DeleteConfirmationMessage',
      'Ccm::AreYouSure',
      { messageLocalizationParams: [] }
    ).pipe(
      filter(status => status === Confirmation.Status.confirm),
      switchMap(() => this.service.delete(record.cruise.id)),
    ).subscribe(this.list.get);
  }
}
