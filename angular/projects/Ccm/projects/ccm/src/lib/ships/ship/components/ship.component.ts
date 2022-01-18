import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetShipsInput,
  ShipDto,
} from '../../../proxy/ships/models';
import { ShipService } from '../../../proxy/ships/ship.service';

@Component({
  selector: 'lib-ship',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './ship.component.html',
  styles: [],
})
export class ShipComponent implements OnInit {
  data: PagedResultDto<ShipDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetShipsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected?: ShipDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: ShipService,
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

    const setData = (list: PagedResultDto<ShipDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetShipsInput;
  }

  buildForm() {
    const {
      shipName,
      shipCategory,
      shipOperator,
      type,
      flag,
      homePort,
      manufacturer,
      model,
      yearBuild,
    } = this.selected || {};

    this.form = this.fb.group({
      shipName: [shipName ?? null, [Validators.required, Validators.maxLength(50)]],
      shipCategory: [shipCategory ?? null, [Validators.required]],
      shipOperator: [shipOperator ?? null, []],
      type: [type ?? null, []],
      flag: [flag ?? null, [Validators.required, Validators.maxLength(2)]],
      homePort: [homePort ?? null, [Validators.required]],
      manufacturer: [manufacturer ?? null, []],
      model: [model ?? null, []],
      yearBuild: [yearBuild ?? null, [Validators.required]],
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

  update(record: ShipDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: ShipDto) {
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
