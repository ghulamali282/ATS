import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetShipsInput,
  ShipWithNavigationPropertiesDto,
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
  data: PagedResultDto<ShipWithNavigationPropertiesDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetShipsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected?: ShipWithNavigationPropertiesDto;

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

    const setData = (list: PagedResultDto<ShipWithNavigationPropertiesDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetShipsInput;
  }

  buildForm() {
    const {
      shipName,
      yearBuild,
      yearRefurbished,
      ensuitedCabins,
      sharedToilets,
      sharedShowers,
      crewNo,
      lenght,
      beam,
      draft,
      cruiseSpeed,
      maxSpeed,
      videoUrl,
      useCabinDeckPosition,
      useDeckLocation,
      shipEnabled,
      homePort,
      flag,
      shipCategory,
      shipOperator,
    } = this.selected?.ship || {};

    this.form = this.fb.group({
      shipName: [shipName ?? null, [Validators.required, Validators.maxLength(50)]],
      yearBuild: [yearBuild ?? null, [Validators.required]],
      yearRefurbished: [yearRefurbished ?? null, []],
      ensuitedCabins: [ensuitedCabins ?? false, [Validators.required]],
      sharedToilets: [sharedToilets ?? null, []],
      sharedShowers: [sharedShowers ?? null, []],
      crewNo: [crewNo ?? null, [Validators.required]],
      lenght: [lenght ?? null, [Validators.required]],
      beam: [beam ?? null, [Validators.required]],
      draft: [draft ?? null, [Validators.required]],
      cruiseSpeed: [cruiseSpeed ?? null, [Validators.required]],
      maxSpeed: [maxSpeed ?? null, [Validators.required]],
      videoUrl: [videoUrl ?? null, [Validators.maxLength(500)]],
      useCabinDeckPosition: [useCabinDeckPosition ?? false, [Validators.required]],
      useDeckLocation: [useDeckLocation ?? false, [Validators.required]],
      shipEnabled: [shipEnabled ?? false, []],
      homePort: [homePort ?? null, [Validators.required]],
      flag: [flag ?? null, [Validators.required]],
      shipCategory: [shipCategory ?? null, [Validators.required]],
      shipOperator: [shipOperator ?? null, []],
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
      ? this.service.update(this.selected.ship.id, this.form.value)
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

  update(record: ShipWithNavigationPropertiesDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: ShipWithNavigationPropertiesDto) {
    this.confirmation.warn(
      'Amm::DeleteConfirmationMessage',
      'Amm::AreYouSure',
      { messageLocalizationParams: [] }
    ).pipe(
      filter(status => status === Confirmation.Status.confirm),
      switchMap(() => this.service.delete(record.ship.id)),
    ).subscribe(this.list.get);
  }
}
