import { ABP, ListService, PagedResultDto, SessionStateService, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type { GetMasterDatasInput, MasterDataDto } from '../../../proxy/master-datas/models';
import { MasterDataService } from '../../../proxy/master-datas/master-data.service';

@Component({
  selector: 'lib-master-data',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './master-data.component.html',
  styles: [],
})
export class MasterDataComponent implements OnInit {
  data: PagedResultDto<MasterDataDto> = {
    items: [],
    totalCount: 0,
  };
  levelOneData: MasterDataDto[] = [];
  activeTab = 1;
  selectedPill:string;

  filters = {} as GetMasterDatasInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected?: MasterDataDto;

  isHost:boolean;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: MasterDataService,
    private confirmation: ConfirmationService,
    private sessionService:SessionStateService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    const tenant=this.sessionService.getTenant();
    this.isHost=tenant.id===null;
    const getData = (query: ABP.PageQueryParams) =>
      this.service.getList({
        ...query,
        ...this.filters,
        filterText: query.filter,
      });

    const setData = (list: PagedResultDto<MasterDataDto>) => {
      this.data = list;
      this.levelOneData = this.data.items.filter(x => x.parentId === null);
    };

    this.list.hookToQuery(getData).subscribe(setData);
  }

  getChildItems(id: string): MasterDataDto[] {
    return this.data.items.filter(x => x.parentId == id);
  }

  getPillChildItems(id:string){
    const items=this.data.items.filter(x => x.parentId == id);
    return items;
  }

  setSelectedPill(id:string){
    this.selectedPill=id;
  }

  clearFilters() {
    this.filters = {} as GetMasterDatasInput;
  }

  buildForm() {
    const {
      parentId,
      name,
      value,
      inlineValue,
      visibleToTenant,
      isSection,
      isRadio,
      isExportable,
      icon,
      cultureName,
      sortOrder,
    } = this.selected || {};

    this.form = this.fb.group({
      parentId: [parentId ?? null, []],
      name: [name ?? null, [Validators.required, Validators.maxLength(100)]],
      value: [value ?? null, []],
      inlineValue: [inlineValue ?? false, []],
      visibleToTenant: [visibleToTenant ?? false, []],
      isSection: [isSection ?? false, []],
      isRadio: [isRadio ?? false, []],
      isExportable: [isExportable ?? false, []],
      icon: [icon ?? null, [Validators.maxLength(50)]],
      cultureName: [cultureName ?? null, [Validators.required, Validators.maxLength(10)]],
      sortOrder: [sortOrder ?? null, [Validators.required]],
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
        tap(() => this.hideForm())
      )
      .subscribe(this.list.get);
  }

  create() {
    this.selected = undefined;
    this.showForm();
  }

  update(record: MasterDataDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: MasterDataDto) {
    this.confirmation
      .warn('Ccm::DeleteConfirmationMessage', 'Ccm::AreYouSure', { messageLocalizationParams: [] })
      .pipe(
        filter(status => status === Confirmation.Status.confirm),
        switchMap(() => this.service.delete(record.id))
      )
      .subscribe(this.list.get);
  }
}
