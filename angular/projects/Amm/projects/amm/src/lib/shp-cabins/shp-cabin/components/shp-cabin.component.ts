import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetShpCabinsInput,
  ShpCabinDto,
} from '../../../proxy/shp-cabins/models';
import { ShpCabinService } from '../../../proxy/shp-cabins/shp-cabin.service';

@Component({
  selector: 'lib-shp-cabin',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './shp-cabin.component.html',
  styles: [],
})
export class ShpCabinComponent implements OnInit {
  data: PagedResultDto<ShpCabinDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetShpCabinsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected?: ShpCabinDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: ShpCabinService,
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

    const setData = (list: PagedResultDto<ShpCabinDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetShpCabinsInput;
  }

  buildForm() {
    const {
      ship,
      cabinCategory,
      cabinNo,
      cabinNoNumeric,
      bedLayout,
      standardCapacity,
      maxCapacity,
      portohole,
      window,
      cabinArea,
      balcon,
      balconArea,
      isDisabled,
    } = this.selected || {};

    this.form = this.fb.group({
      ship: [ship ?? null, [Validators.required]],
      cabinCategory: [cabinCategory ?? null, [Validators.required]],
      cabinNo: [cabinNo ?? null, [Validators.required, Validators.maxLength(10)]],
      cabinNoNumeric: [cabinNoNumeric ?? null, [Validators.required]],
      bedLayout: [bedLayout ?? null, [Validators.required]],
      standardCapacity: [standardCapacity ?? null, [Validators.required]],
      maxCapacity: [maxCapacity ?? null, [Validators.required]],
      portohole: [portohole ?? false, [Validators.required]],
      window: [window ?? false, [Validators.required]],
      cabinArea: [cabinArea ?? null, [Validators.required]],
      balcon: [balcon ?? false, [Validators.required]],
      balconArea: [balconArea ?? null, [Validators.required]],
      isDisabled: [isDisabled ?? false, [Validators.required]],
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

  update(record: ShpCabinDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: ShpCabinDto) {
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
