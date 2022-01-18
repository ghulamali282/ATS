import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetCruiseRegionsInput,
  CruiseRegionWithNavigationPropertiesDto,
} from '../../../proxy/cruise-regions/models';
import { CruiseRegionService } from '../../../proxy/cruise-regions/cruise-region.service';

@Component({
  selector: 'lib-cruise-region',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './cruise-region.component.html',
  styles: [],
})
export class CruiseRegionComponent implements OnInit {
  data: PagedResultDto<CruiseRegionWithNavigationPropertiesDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetCruiseRegionsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected?: CruiseRegionWithNavigationPropertiesDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: CruiseRegionService,
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

    const setData = (list: PagedResultDto<CruiseRegionWithNavigationPropertiesDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetCruiseRegionsInput;
  }

  buildForm() {
    const {
      freeEntry,
      cruiseRegionName,
    } = this.selected?.cruiseRegion || {};

    this.form = this.fb.group({
      freeEntry: [freeEntry ?? null, []],
      cruiseRegionName: [cruiseRegionName ?? null, [Validators.required]],
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
      ? this.service.update(this.selected.cruiseRegion.id, this.form.value)
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

  update(record: CruiseRegionWithNavigationPropertiesDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: CruiseRegionWithNavigationPropertiesDto) {
    this.confirmation.warn(
      'Amm::DeleteConfirmationMessage',
      'Amm::AreYouSure',
      { messageLocalizationParams: [] }
    ).pipe(
      filter(status => status === Confirmation.Status.confirm),
      switchMap(() => this.service.delete(record.cruiseRegion.id)),
    ).subscribe(this.list.get);
  }
}
