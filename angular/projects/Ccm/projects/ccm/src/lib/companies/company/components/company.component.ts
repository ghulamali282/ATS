import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetCompaniesInput,
  CompanyDto,
} from '../../../proxy/companies/models';
import { CompanyService } from '../../../proxy/companies/company.service';

@Component({
  selector: 'lib-company',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './company.component.html',
  styles: [],
})
export class CompanyComponent implements OnInit {
  data: PagedResultDto<CompanyDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetCompaniesInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected?: CompanyDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: CompanyService,
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

    const setData = (list: PagedResultDto<CompanyDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetCompaniesInput;
  }

  buildForm() {
    const {
      legalName,
      companyCode,
      street,
      streetNumber,
      zipCode,
      city,
      stateRegion,
      country,
      inEU,
      taxNo,
      travelAgencyCode,
      invoicePrefix,
      invoiceLegal1,
      invoiceLegal2,
      paymentInfo,
      webSite,
      companyEmail,
      telephone,
      fax,
      facebookPage,
      twiterPage,
      instagram,
      ceoName,
      ceoEmail,
      bookingEmail,
      bookingEmailConfirmed,
      bookingCellPhone,
      bookingPhoneConfirmed,
      workingYear,
      tenantCurrency,
      roundingAfterExchange,
      defaultCruiseDeposit,
      defaultCharterDeposit,
      defaultCruiseDepositType,
      defautCharterDepositType,
      requestDurationCruise,
      requestDurationCharter,
      optionDurationCruise,
      optionDurationCharter,
      cruiseFinalPaymentDueDays,
      charterFinalPaymentDueDays,
      cruiseFullPaymentRequiredDays,
      charterFullPaymentRequiredDays,
    } = this.selected || {};

    this.form = this.fb.group({
      legalName: [legalName ?? null, [Validators.required, Validators.maxLength(50)]],
      companyCode: [companyCode ?? null, [Validators.required, Validators.maxLength(5)]],
      street: [street ?? null, [Validators.required, Validators.maxLength(50)]],
      streetNumber: [streetNumber ?? null, [Validators.required, Validators.maxLength(50)]],
      zipCode: [zipCode ?? null, [Validators.required, Validators.maxLength(50)]],
      city: [city ?? null, [Validators.required, Validators.maxLength(50)]],
      stateRegion: [stateRegion ?? null, [Validators.maxLength(50)]],
      country: [country ?? null, [Validators.required, Validators.maxLength(2)]],
      inEU: [inEU ?? false, []],
      taxNo: [taxNo ?? null, [Validators.required, Validators.maxLength(50)]],
      travelAgencyCode: [travelAgencyCode ?? null, [Validators.maxLength(50)]],
      invoicePrefix: [invoicePrefix ?? null, [Validators.maxLength(10)]],
      invoiceLegal1: [invoiceLegal1 ?? null, []],
      invoiceLegal2: [invoiceLegal2 ?? null, []],
      paymentInfo: [paymentInfo ?? null, []],
      webSite: [webSite ?? null, [Validators.maxLength(50)]],
      companyEmail: [companyEmail ?? null, [Validators.required, Validators.maxLength(50), Validators.email]],
      telephone: [telephone ?? null, [Validators.maxLength(50)]],
      fax: [fax ?? null, [Validators.maxLength(50)]],
      facebookPage: [facebookPage ?? null, [Validators.maxLength(50)]],
      twiterPage: [twiterPage ?? null, [Validators.maxLength(50)]],
      instagram: [instagram ?? null, [Validators.maxLength(50)]],
      ceoName: [ceoName ?? null, [Validators.maxLength(50)]],
      ceoEmail: [ceoEmail ?? null, [Validators.maxLength(50)]],
      bookingEmail: [bookingEmail ?? null, [Validators.required, Validators.email]],
      bookingEmailConfirmed: [bookingEmailConfirmed ?? false, [Validators.required, Validators.email]],
      bookingCellPhone: [bookingCellPhone ?? null, [Validators.required]],
      bookingPhoneConfirmed: [bookingPhoneConfirmed ?? false, []],
      workingYear: [workingYear ?? null, []],
      tenantCurrency: [tenantCurrency ?? null, [Validators.maxLength(3)]],
      roundingAfterExchange: [roundingAfterExchange ?? null, []],
      defaultCruiseDeposit: [defaultCruiseDeposit ?? null, [Validators.required]],
      defaultCharterDeposit: [defaultCharterDeposit ?? null, [Validators.required]],
      defaultCruiseDepositType: [defaultCruiseDepositType ?? null, [Validators.required, Validators.maxLength(3)]],
      defautCharterDepositType: [defautCharterDepositType ?? null, [Validators.required, Validators.maxLength(3)]],
      requestDurationCruise: [requestDurationCruise ?? null, [Validators.required]],
      requestDurationCharter: [requestDurationCharter ?? null, [Validators.required]],
      optionDurationCruise: [optionDurationCruise ?? null, []],
      optionDurationCharter: [optionDurationCharter ?? null, [Validators.required]],
      cruiseFinalPaymentDueDays: [cruiseFinalPaymentDueDays ?? null, []],
      charterFinalPaymentDueDays: [charterFinalPaymentDueDays ?? null, [Validators.required]],
      cruiseFullPaymentRequiredDays: [cruiseFullPaymentRequiredDays ?? null, [Validators.required]],
      charterFullPaymentRequiredDays: [charterFullPaymentRequiredDays ?? null, []],
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

  update(record: CompanyDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: CompanyDto) {
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
