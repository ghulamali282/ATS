import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetMarinasInput,
  MarinaWithNavigationPropertiesDto,
} from '../../../proxy/marinas/models';
import { MarinaService } from '../../../proxy/marinas/marina.service';

@Component({
  selector: 'lib-marina',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './marina.component.html',
  styles: [],
})
export class MarinaComponent implements OnInit {
  data: PagedResultDto<MarinaWithNavigationPropertiesDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetMarinasInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected?: MarinaWithNavigationPropertiesDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: MarinaService,
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

    const setData = (list: PagedResultDto<MarinaWithNavigationPropertiesDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetMarinasInput;
  }

  buildForm() {
    const {
      marinaNameString,
      latitude,
      longitude,
      marinaName,
      destination,
    } = this.selected?.marina || {};

    this.form = this.fb.group({
      marinaNameString: [marinaNameString ?? null, [Validators.maxLength(50)]],
      latitude: [latitude ?? null, [Validators.required, Validators.maxLength(50)]],
      longitude: [longitude ?? null, [Validators.required, Validators.maxLength(50)]],
      marinaName: [marinaName ?? null, [Validators.required]],
      destination: [destination ?? null, [Validators.required]],
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
      ? this.service.update(this.selected.marina.id, this.form.value)
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

  update(record: MarinaWithNavigationPropertiesDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: MarinaWithNavigationPropertiesDto) {
    this.confirmation.warn(
      'Amm::DeleteConfirmationMessage',
      'Amm::AreYouSure',
      { messageLocalizationParams: [] }
    ).pipe(
      filter(status => status === Confirmation.Status.confirm),
      switchMap(() => this.service.delete(record.marina.id)),
    ).subscribe(this.list.get);
  }
}
