import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetCharterShipsInput,
  CharterShipDto,
} from '../../../proxy/charter-ships/models';
import { CharterShipService } from '../../../proxy/charter-ships/charter-ship.service';

@Component({
  selector: 'lib-charter-ship',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './charter-ship.component.html',
  styles: [],
})
export class CharterShipComponent implements OnInit {
  data: PagedResultDto<CharterShipDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetCharterShipsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected?: CharterShipDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: CharterShipService,
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

    const setData = (list: PagedResultDto<CharterShipDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetCharterShipsInput;
  }

  buildForm() {
    const {
      operatorName,
      season,
      shipNamePrefix,
      ship,
      itinerary,
      tabs,
      video,
      featured,
      freeInternetOnBoard,
      internet,
      transferIncluded,
      enabledByUser,
      disabledBySystem,
      b2B,
      b2C,
      b2B_Agent,
      b2C_Agent,
      shipAmenities,
      shipArticles,
      shipPhotos,
      cabinAmenities,
      cabinArticles,
      cabinPhotos,
    } = this.selected || {};

    this.form = this.fb.group({
      operatorName: [operatorName ?? null, [Validators.required]],
      season: [season ?? null, [Validators.required]],
      shipNamePrefix: [shipNamePrefix ?? null, []],
      ship: [ship ?? null, [Validators.required]],
      itinerary: [itinerary ?? null, [Validators.required]],
      tabs: [tabs ?? null, [Validators.required, Validators.maxLength(500)]],
      video: [video ?? null, [Validators.maxLength(500)]],
      featured: [featured ?? false, [Validators.required]],
      freeInternetOnBoard: [freeInternetOnBoard ?? false, [Validators.required]],
      internet: [internet ?? false, [Validators.required]],
      transferIncluded: [transferIncluded ?? false, [Validators.required]],
      enabledByUser: [enabledByUser ?? false, [Validators.required]],
      disabledBySystem: [disabledBySystem ?? null, []],
      b2B: [b2B ?? false, [Validators.required]],
      b2C: [b2C ?? false, [Validators.required]],
      b2B_Agent: [b2B_Agent ?? false, [Validators.required]],
      b2C_Agent: [b2C_Agent ?? false, [Validators.required]],
      shipAmenities: [shipAmenities ?? null, []],
      shipArticles: [shipArticles ?? null, []],
      shipPhotos: [shipPhotos ?? null, []],
      cabinAmenities: [cabinAmenities ?? null, []],
      cabinArticles: [cabinArticles ?? null, []],
      cabinPhotos: [cabinPhotos ?? null, []],
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
      ? this.service.update(this.selected.id, this.form.value)
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

  update(record: CharterShipDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: CharterShipDto) {
    this.confirmation.warn(
      'Ccm::DeleteConfirmationMessage',
      'Ccm::AreYouSure',
      { messageLocalizationParams: [] }
    ).pipe(
      filter(status => status === Confirmation.Status.confirm),
      switchMap(() => this.service.delete(record.id)),
    ).subscribe(this.list.get);
  }
}
