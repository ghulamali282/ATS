import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetCountriesInput,
  CountryDto,
} from '../../../proxy/countries/models';
import { CountryService } from '../../../proxy/countries/country.service';

@Component({
  selector: 'lib-country',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './country.component.html',
  styles: [],
})
export class CountryComponent implements OnInit {
  data: PagedResultDto<CountryDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetCountriesInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected?: CountryDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: CountryService,
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

    const setData = (list: PagedResultDto<CountryDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetCountriesInput;
  }

  buildForm() {
    const {
      countryName,
      cultureName,
      currency,
      currencyCode,
      currencySymbol,
      languageName,
      placeId,
    } = this.selected || {};

    this.form = this.fb.group({
      countryName: [countryName ?? null, [Validators.required]],
      cultureName: [cultureName ?? null, [Validators.required, Validators.maxLength(10)]],
      currency: [currency ?? null, [Validators.required, Validators.maxLength(50)]],
      currencyCode: [currencyCode ?? null, [Validators.required, Validators.maxLength(3)]],
      currencySymbol: [currencySymbol ?? null, [Validators.required, Validators.maxLength(10)]],
      languageName: [languageName ?? null, [Validators.required, Validators.maxLength(50)]],
      placeId: [placeId ?? null, [Validators.maxLength(50)]],
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

  update(record: CountryDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: CountryDto) {
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
