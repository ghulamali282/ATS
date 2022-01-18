import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetClientsInput,
  ClientDto,
} from '../../../proxy/clients/models';
import { ClientService } from '../../../proxy/clients/client.service';

@Component({
  selector: 'lib-client',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './client.component.html',
  styles: [],
})
export class ClientComponent implements OnInit {
  data: PagedResultDto<ClientDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetClientsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected?: ClientDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: ClientService,
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

    const setData = (list: PagedResultDto<ClientDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetClientsInput;
  }

  buildForm() {
    const {
      title,
      firstName,
      secondName,
      gender,
      clientDOB,
      agePolicy,
      email,
      emailConfirmed,
      country,
      nacionality,
      state,
      zipCode,
      city,
      cellPhone,
      cellPhoneConfirmed,
      documentType,
      documentNo,
      issueDate,
      expiration,
      mailingList,
    } = this.selected || {};

    this.form = this.fb.group({
      title: [title ?? null, []],
      firstName: [firstName ?? null, [Validators.required, Validators.maxLength(50)]],
      secondName: [secondName ?? null, [Validators.required, Validators.maxLength(50)]],
      gender: [gender ?? null, []],
      clientDOB: [clientDOB ? new Date(clientDOB) : null, []],
      agePolicy: [agePolicy ?? null, []],
      email: [email ?? null, [Validators.maxLength(50)]],
      emailConfirmed: [emailConfirmed ?? false, []],
      country: [country ?? null, [Validators.maxLength(2)]],
      nacionality: [nacionality ?? null, [Validators.maxLength(2)]],
      state: [state ?? null, [Validators.maxLength(50)]],
      zipCode: [zipCode ?? null, [Validators.maxLength(50)]],
      city: [city ?? null, [Validators.maxLength(50)]],
      cellPhone: [cellPhone ?? null, [Validators.maxLength(50)]],
      cellPhoneConfirmed: [cellPhoneConfirmed ?? false, []],
      documentType: [documentType ?? null, []],
      documentNo: [documentNo ?? null, [Validators.maxLength(50)]],
      issueDate: [issueDate ? new Date(issueDate) : null, []],
      expiration: [expiration ? new Date(expiration) : null, []],
      mailingList: [mailingList ?? false, [Validators.required]],
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

  update(record: ClientDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: ClientDto) {
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
