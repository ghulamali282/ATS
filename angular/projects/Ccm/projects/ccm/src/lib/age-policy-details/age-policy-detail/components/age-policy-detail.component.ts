import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetAgePolicyDetailsInput,
  AgePolicyDetailWithNavigationPropertiesDto,
} from '../../../proxy/age-policy-details/models';
import { AgePolicyDetailService } from '../../../proxy/age-policy-details/age-policy-detail.service';

@Component({
  selector: 'lib-age-policy-detail',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './age-policy-detail.component.html',
  styles: [],
})
export class AgePolicyDetailComponent implements OnInit {
  data: PagedResultDto<AgePolicyDetailWithNavigationPropertiesDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetAgePolicyDetailsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected?: AgePolicyDetailWithNavigationPropertiesDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: AgePolicyDetailService,
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

    const setData = (list: PagedResultDto<AgePolicyDetailWithNavigationPropertiesDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetAgePolicyDetailsInput;
  }

  buildForm() {
    const {
      ageFrom,
      agePolicy,
      ageTo,
      service,
    } = this.selected?.agePolicyDetail || {};

    this.form = this.fb.group({
      ageFrom: [ageFrom ?? null, [Validators.required]],
      agePolicy: [agePolicy ?? null, [Validators.required]],
      ageTo: [ageTo ?? null, [Validators.required]],
      service: [service ?? null, [Validators.required]],
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
      ? this.service.update(this.selected.agePolicyDetail.id, this.form.value)
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

  update(record: AgePolicyDetailWithNavigationPropertiesDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: AgePolicyDetailWithNavigationPropertiesDto) {
    this.confirmation.warn(
      'Ccm::DeleteConfirmationMessage',
      'Ccm::AreYouSure',
      { messageLocalizationParams: [] }
    ).pipe(
      filter(status => status === Confirmation.Status.confirm),
      switchMap(() => this.service.delete(record.agePolicyDetail.id)),
    ).subscribe(this.list.get);
  }
}
