import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetPassengersInput,
  PassengerDto,
} from '../../../proxy/passengers/models';
import { PassengerService } from '../../../proxy/passengers/passenger.service';

@Component({
  selector: 'lib-passenger',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './passenger.component.html',
  styles: [],
})
export class PassengerComponent implements OnInit {
  data: PagedResultDto<PassengerDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetPassengersInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected?: PassengerDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: PassengerService,
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

    const setData = (list: PagedResultDto<PassengerDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetPassengersInput;
  }

  buildForm() {
    const {
      reservation,
      reservationDetail,
      reservationHolder,
      title,
      firstName,
      lastName,
      country,
      agePolicyDetail,
      passengerDOB,
      documentType,
      documentNo,
      issueDate,
      expiration,
      passengerNote,
      clientNo,
      reduction,
    } = this.selected || {};

    this.form = this.fb.group({
      reservation: [reservation ?? null, [Validators.required]],
      reservationDetail: [reservationDetail ?? null, [Validators.required]],
      reservationHolder: [reservationHolder ?? false, [Validators.required]],
      title: [title ?? null, []],
      firstName: [firstName ?? null, [Validators.required, Validators.maxLength(50)]],
      lastName: [lastName ?? null, [Validators.required, Validators.maxLength(50)]],
      country: [country ?? null, [Validators.maxLength(2)]],
      agePolicyDetail: [agePolicyDetail ?? null, [Validators.required]],
      passengerDOB: [passengerDOB ? new Date(passengerDOB) : null, []],
      documentType: [documentType ?? null, []],
      documentNo: [documentNo ?? null, [Validators.maxLength(50)]],
      issueDate: [issueDate ? new Date(issueDate) : null, []],
      expiration: [expiration ? new Date(expiration) : null, []],
      passengerNote: [passengerNote ?? null, []],
      clientNo: [clientNo ?? null, [Validators.required]],
      reduction: [reduction ?? null, [Validators.required]],
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

  update(record: PassengerDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: PassengerDto) {
    this.confirmation.warn(
      'Crm::DeleteConfirmationMessage',
      'Crm::AreYouSure',
      { messageLocalizationParams: [] }
    ).pipe(
      filter(status => status === Confirmation.Status.confirm),
      switchMap(() => this.service.delete(record.id)),
    ).subscribe(this.list.get);
  }
}
