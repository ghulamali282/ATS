import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetPaymentPoliciesInput,
  PaymentPolicyWithNavigationPropertiesDto,
} from '../../../proxy/payment-policies/models';
import { PaymentPolicyService } from '../../../proxy/payment-policies/payment-policy.service';

@Component({
  selector: 'lib-payment-policy',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './payment-policy.component.html',
  styles: [],
})
export class PaymentPolicyComponent implements OnInit {
  data: PagedResultDto<PaymentPolicyWithNavigationPropertiesDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetPaymentPoliciesInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected?: PaymentPolicyWithNavigationPropertiesDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: PaymentPolicyService,
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

    const setData = (list: PagedResultDto<PaymentPolicyWithNavigationPropertiesDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetPaymentPoliciesInput;
  }

  buildForm() {
    const {
      delayedDepositAt,
      deposit,
      depositAtReservation,
      depositType,
      finalPaymentDueDays,
      fullPaymentRequiredDays,
      policyString,
      operatorName,
      policyName,
    } = this.selected?.paymentPolicy || {};

    this.form = this.fb.group({
      delayedDepositAt: [delayedDepositAt ?? null, [Validators.maxLength(50)]],
      deposit: [deposit ?? null, [Validators.required]],
      depositAtReservation: [depositAtReservation ?? false, [Validators.required]],
      depositType: [depositType ?? null, [Validators.required, Validators.maxLength(3)]],
      finalPaymentDueDays: [finalPaymentDueDays ?? null, [Validators.required]],
      fullPaymentRequiredDays: [fullPaymentRequiredDays ?? null, [Validators.required]],
      policyString: [policyString ?? null, [Validators.required]],
      operatorName: [operatorName ?? null, [Validators.required]],
      policyName: [policyName ?? null, [Validators.required]],
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
      ? this.service.update(this.selected.paymentPolicy.id, this.form.value)
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

  update(record: PaymentPolicyWithNavigationPropertiesDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: PaymentPolicyWithNavigationPropertiesDto) {
    this.confirmation.warn(
      'Ccm::DeleteConfirmationMessage',
      'Ccm::AreYouSure',
      { messageLocalizationParams: [] }
    ).pipe(
      filter(status => status === Confirmation.Status.confirm),
      switchMap(() => this.service.delete(record.paymentPolicy.id)),
    ).subscribe(this.list.get);
  }
}
