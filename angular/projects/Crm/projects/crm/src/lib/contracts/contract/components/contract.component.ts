import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetContractsInput,
  ContractDto,
} from '../../../proxy/contracts/models';
import { ContractService } from '../../../proxy/contracts/contract.service';

@Component({
  selector: 'lib-contract',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './contract.component.html',
  styles: [],
})
export class ContractComponent implements OnInit {
  data: PagedResultDto<ContractDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetContractsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected?: ContractDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: ContractService,
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

    const setData = (list: PagedResultDto<ContractDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetContractsInput;
  }

  buildForm() {
    const {
      operatorName,
      season,
      isEnabledAgent,
      isEnabledOperator,
    } = this.selected || {};

    this.form = this.fb.group({
      operatorName: [operatorName ?? null, [Validators.required]],
      season: [season ?? null, [Validators.required]],
      isEnabledAgent: [isEnabledAgent ?? false, [Validators.required]],
      isEnabledOperator: [isEnabledOperator ?? false, [Validators.required]],
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

  update(record: ContractDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: ContractDto) {
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
