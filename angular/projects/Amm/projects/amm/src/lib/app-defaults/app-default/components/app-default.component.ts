import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetAppDefaultsInput,
  AppDefaultDto,
} from '../../../proxy/app-defaults/models';
import { AppDefaultService } from '../../../proxy/app-defaults/app-default.service';

@Component({
  selector: 'lib-app-default',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './app-default.component.html',
  styles: [],
})
export class AppDefaultComponent implements OnInit {
  data: PagedResultDto<AppDefaultDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetAppDefaultsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected?: AppDefaultDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: AppDefaultService,
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

    const setData = (list: PagedResultDto<AppDefaultDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetAppDefaultsInput;
  }

  buildForm() {
    const {
      settingsName,
      settingsValue,
    } = this.selected || {};

    this.form = this.fb.group({
      settingsName: [settingsName ?? null, [Validators.required, Validators.maxLength(50)]],
      settingsValue: [settingsValue ?? null, [Validators.required, Validators.maxLength(128)]],
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

  update(record: AppDefaultDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: AppDefaultDto) {
    this.confirmation.warn(
      'Amm::DeleteConfirmationMessage',
      'Amm::AreYouSure',
      { messageLocalizationParams: [] }
    ).pipe(
      filter(status => status === Confirmation.Status.confirm),
      switchMap(() => this.service.delete(record.id)),
    ).subscribe(this.list.get);
  }
}
