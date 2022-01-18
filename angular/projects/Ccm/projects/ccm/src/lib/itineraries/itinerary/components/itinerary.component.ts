import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetItinerariesInput,
  ItineraryWithNavigationPropertiesDto,
} from '../../../proxy/itineraries/models';
import { ItineraryService } from '../../../proxy/itineraries/itinerary.service';

@Component({
  selector: 'lib-itinerary',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './itinerary.component.html',
  styles: [],
})
export class ItineraryComponent implements OnInit {
  data: PagedResultDto<ItineraryWithNavigationPropertiesDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetItinerariesInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected?: ItineraryWithNavigationPropertiesDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: ItineraryService,
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

    const setData = (list: PagedResultDto<ItineraryWithNavigationPropertiesDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetItinerariesInput;
  }

  buildForm() {
    const {
      itineraryNameString,
      itineraryCode,
      googleMapLink,
      duration,
      extendedItinerary,
      marina,
      embarcationLatitude,
      embarcationLongitude,
      disembarkationLatitude,
      disembarkationLongitude,
      checkInTime,
      checkOutTime,
      transferIncluded,
      video,
      requestDuration,
      optionDuration,
      operatorName,
      themes,
      boarding,
      agePolicyId,
      embarcationPort,
      disembarkationPort,
      cancellationPolicy,
      paymentPolicy,
      itineraryName,
    } = this.selected?.itinerary || {};

    this.form = this.fb.group({
      itineraryNameString: [itineraryNameString ?? null, [Validators.required]],
      itineraryCode: [itineraryCode ?? null, [Validators.required, Validators.maxLength(10)]],
      googleMapLink: [googleMapLink ?? null, [Validators.maxLength(100)]],
      duration: [duration ?? null, [Validators.required]],
      extendedItinerary: [extendedItinerary ?? false, [Validators.required]],
      marina: [marina ?? null, []],
      embarcationLatitude: [embarcationLatitude ?? null, [Validators.required, Validators.maxLength(50)]],
      embarcationLongitude: [embarcationLongitude ?? null, [Validators.required, Validators.maxLength(50)]],
      disembarkationLatitude: [disembarkationLatitude ?? null, [Validators.required, Validators.maxLength(50)]],
      disembarkationLongitude: [disembarkationLongitude ?? null, [Validators.required, Validators.maxLength(50)]],
      checkInTime: [checkInTime ?? null, [Validators.required, Validators.maxLength(3)]],
      checkOutTime: [checkOutTime ?? null, [Validators.required, Validators.maxLength(3)]],
      transferIncluded: [transferIncluded ?? false, [Validators.required]],
      video: [video ?? null, [Validators.maxLength(1000)]],
      requestDuration: [requestDuration ?? null, [Validators.required]],
      optionDuration: [optionDuration ?? null, [Validators.required]],
      operatorName: [operatorName ?? null, [Validators.required]],
      themes: [themes ?? null, [Validators.required]],
      boarding: [boarding ?? null, [Validators.required]],
      agePolicyId: [agePolicyId ?? null, [Validators.required]],
      embarcationPort: [embarcationPort ?? null, [Validators.required]],
      disembarkationPort: [disembarkationPort ?? null, [Validators.required]],
      cancellationPolicy: [cancellationPolicy ?? null, [Validators.required]],
      paymentPolicy: [paymentPolicy ?? null, [Validators.required]],
      itineraryName: [itineraryName ?? null, [Validators.required]],
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
      ? this.service.update(this.selected.itinerary.id, this.form.value)
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

  update(record: ItineraryWithNavigationPropertiesDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: ItineraryWithNavigationPropertiesDto) {
    this.confirmation.warn(
      'Ccm::DeleteConfirmationMessage',
      'Ccm::AreYouSure',
      { messageLocalizationParams: [] }
    ).pipe(
      filter(status => status === Confirmation.Status.confirm),
      switchMap(() => this.service.delete(record.itinerary.id)),
    ).subscribe(this.list.get);
  }

}
