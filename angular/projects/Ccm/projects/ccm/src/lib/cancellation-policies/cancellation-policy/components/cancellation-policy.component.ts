import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetCancellationPoliciesInput,
  CancellationPolicyWithNavigationPropertiesDto,
} from '../../../proxy/cancellation-policies/models';
import { CancellationPolicyService } from '../../../proxy/cancellation-policies/cancellation-policy.service';

@Component({
  selector: 'lib-cancellation-policy',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './cancellation-policy.component.html',
  styles: [],
})
export class CancellationPolicyComponent implements OnInit {
  data: PagedResultDto<CancellationPolicyWithNavigationPropertiesDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetCancellationPoliciesInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected?: CancellationPolicyWithNavigationPropertiesDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: CancellationPolicyService,
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

    const setData = (list: PagedResultDto<CancellationPolicyWithNavigationPropertiesDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetCancellationPoliciesInput;
  }

  buildForm() {
    const {
      nameString,
      operatorName,
      policyName,
    } = this.selected?.cancellationPolicy || {};

    this.form = this.fb.group({
      nameString: [nameString ?? null, [Validators.required]],
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
      ? this.service.update(this.selected.cancellationPolicy.id, this.form.value)
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

  update(record: CancellationPolicyWithNavigationPropertiesDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: CancellationPolicyWithNavigationPropertiesDto) {
    this.confirmation.warn(
      'Ccm::DeleteConfirmationMessage',
      'Ccm::AreYouSure',
      { messageLocalizationParams: [] }
    ).pipe(
      filter(status => status === Confirmation.Status.confirm),
      switchMap(() => this.service.delete(record.cancellationPolicy.id)),
    ).subscribe(this.list.get);
  }
}
