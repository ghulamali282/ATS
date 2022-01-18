import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetShipCabinTypesInput,
  ShipCabinTypeWithNavigationPropertiesDto,
} from '../../../proxy/ship-cabin-types/models';
import { ShipCabinTypeService } from '../../../proxy/ship-cabin-types/ship-cabin-type.service';

@Component({
  selector: 'lib-ship-cabin-type',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './ship-cabin-type.component.html',
  styles: [],
})
export class ShipCabinTypeComponent implements OnInit {
  data: PagedResultDto<ShipCabinTypeWithNavigationPropertiesDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetShipCabinTypesInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected?: ShipCabinTypeWithNavigationPropertiesDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: ShipCabinTypeService,
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

    const setData = (list: PagedResultDto<ShipCabinTypeWithNavigationPropertiesDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetShipCabinTypesInput;
  }

  buildForm() {
    const {
      ship,
      sortOrder,
      cabinCategory,
      deck,
      deckLocation,
      deckPosition,
    } = this.selected?.shipCabinType || {};

    this.form = this.fb.group({
      ship: [ship ?? null, [Validators.required]],
      sortOrder: [sortOrder ?? null, [Validators.required]],
      cabinCategory: [cabinCategory ?? null, [Validators.required]],
      deck: [deck ?? null, [Validators.required]],
      deckLocation: [deckLocation ?? null, [Validators.required]],
      deckPosition: [deckPosition ?? null, []],
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
      ? this.service.update(this.selected.shipCabinType.id, this.form.value)
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

  update(record: ShipCabinTypeWithNavigationPropertiesDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: ShipCabinTypeWithNavigationPropertiesDto) {
    this.confirmation.warn(
      'Amm::DeleteConfirmationMessage',
      'Amm::AreYouSure',
      { messageLocalizationParams: [] }
    ).pipe(
      filter(status => status === Confirmation.Status.confirm),
      switchMap(() => this.service.delete(record.shipCabinType.id)),
    ).subscribe(this.list.get);
  }
}
