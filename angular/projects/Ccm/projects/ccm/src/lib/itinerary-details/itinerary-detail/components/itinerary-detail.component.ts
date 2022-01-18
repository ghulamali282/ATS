import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetItineraryDetailsInput,
  ItineraryDetailDto,
} from '../../../proxy/itinerary-details/models';
import { ItineraryDetailService } from '../../../proxy/itinerary-details/itinerary-detail.service';

@Component({
  selector: 'lib-itinerary-detail',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './itinerary-detail.component.html',
  styles: [],
})
export class ItineraryDetailComponent implements OnInit {
  data: PagedResultDto<ItineraryDetailDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetItineraryDetailsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected?: ItineraryDetailDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: ItineraryDetailService,
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

    const setData = (list: PagedResultDto<ItineraryDetailDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetItineraryDetailsInput;
  }

  buildForm() {
    const {
      itinerary,
      name,
      day,
      ports,
      alternativePorts,
      welcomeDrink,
      welcomeSnack,
      breakfast,
      brunch,
      lunch,
      afternoonSnack,
      dinner,
      captainDinner,
      liveMusic,
      wineTasting,
      overnightOnAnchor,
      overnightAtMarina,
    } = this.selected || {};

    this.form = this.fb.group({
      itinerary: [itinerary ?? null, [Validators.required]],
      name: [name ?? null, [Validators.required]],
      day: [day ?? null, [Validators.required]],
      ports: [ports ?? null, [Validators.required, Validators.maxLength(1000)]],
      alternativePorts: [alternativePorts ?? null, [Validators.maxLength(1000)]],
      welcomeDrink: [welcomeDrink ?? false, [Validators.required]],
      welcomeSnack: [welcomeSnack ?? false, [Validators.required]],
      breakfast: [breakfast ?? false, [Validators.required]],
      brunch: [brunch ?? false, [Validators.required]],
      lunch: [lunch ?? false, [Validators.required]],
      afternoonSnack: [afternoonSnack ?? false, [Validators.required]],
      dinner: [dinner ?? false, [Validators.required]],
      captainDinner: [captainDinner ?? false, [Validators.required]],
      liveMusic: [liveMusic ?? false, [Validators.required]],
      wineTasting: [wineTasting ?? false, [Validators.required]],
      overnightOnAnchor: [overnightOnAnchor ?? false, [Validators.required]],
      overnightAtMarina: [overnightAtMarina ?? false, [Validators.required]],
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

  update(record: ItineraryDetailDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: ItineraryDetailDto) {
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
