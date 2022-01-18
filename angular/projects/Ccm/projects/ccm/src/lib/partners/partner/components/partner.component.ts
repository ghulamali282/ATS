import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetPartnersInput,
  PartnerWithNavigationPropertiesDto,
} from '../../../proxy/partners/models';
import { PartnerService } from '../../../proxy/partners/partner.service';

@Component({
  selector: 'lib-partner',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './partner.component.html',
  styles: [],
})
export class PartnerComponent implements OnInit {
  data: PagedResultDto<PartnerWithNavigationPropertiesDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetPartnersInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected?: PartnerWithNavigationPropertiesDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: PartnerService,
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

    const setData = (list: PagedResultDto<PartnerWithNavigationPropertiesDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetPartnersInput;
  }

  buildForm() {
    const {
      partnerName,
      address,
      taxNo,
      bookingEmail,
      bookingCellPhone,
      bookingEmailConfirmed,
      bookingPhoneConfirmed,
      email,
      phone,
      countryName,
    } = this.selected?.partner || {};

    this.form = this.fb.group({
      partnerName: [partnerName ?? null, [Validators.required, Validators.maxLength(100)]],
      address: [address ?? null, [Validators.required]],
      taxNo: [taxNo ?? null, [Validators.required, Validators.maxLength(50)]],
      bookingEmail: [bookingEmail ?? null, [Validators.required, Validators.maxLength(256), Validators.email]],
      bookingCellPhone: [bookingCellPhone ?? null, [Validators.required, Validators.maxLength(16)]],
      bookingEmailConfirmed: [bookingEmailConfirmed ?? false, []],
      bookingPhoneConfirmed: [bookingPhoneConfirmed ?? false, []],
      email: [email ?? null, [Validators.maxLength(256), Validators.email]],
      phone: [phone ?? null, [Validators.maxLength(16)]],
      countryName: [countryName ?? null, [Validators.required]],
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
      ? this.service.update(this.selected.partner.id, this.form.value)
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

  update(record: PartnerWithNavigationPropertiesDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: PartnerWithNavigationPropertiesDto) {
    this.confirmation.warn(
      'Ccm::DeleteConfirmationMessage',
      'Ccm::AreYouSure',
      { messageLocalizationParams: [] }
    ).pipe(
      filter(status => status === Confirmation.Status.confirm),
      switchMap(() => this.service.delete(record.partner.id)),
    ).subscribe(this.list.get);
  }
}
