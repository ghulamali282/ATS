using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Ccm.EntityFrameworkCore;

namespace Ccm.Partners
{
    public class EfCorePartnerRepository : EfCoreRepository<CcmDbContext, Partner, Guid>, IPartnerRepository
    {
        public EfCorePartnerRepository(IDbContextProvider<CcmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<PartnerWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryForNavigationPropertiesAsync())
                .FirstOrDefaultAsync(e => e.Partner.Id == id, GetCancellationToken(cancellationToken));
        }

        public async Task<List<PartnerWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string partnerName = null,
            string address = null,
            string taxNo = null,
            string bookingEmail = null,
            string bookingCellPhone = null,
            bool? bookingEmailConfirmed = null,
            bool? bookingPhoneConfirmed = null,
            string email = null,
            string phone = null,
            string countryName = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, partnerName, address, taxNo, bookingEmail, bookingCellPhone, bookingEmailConfirmed, bookingPhoneConfirmed, email, phone, countryName);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? PartnerConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<PartnerWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from partner in (await GetDbSetAsync())
                   join country in (await GetDbContextAsync()).Countries on partner.CountryName equals country.Id into countries
                   from country in countries.DefaultIfEmpty()

                   select new PartnerWithNavigationProperties
                   {
                       Partner = partner,
                       Country = country
                   };
        }

        protected virtual IQueryable<PartnerWithNavigationProperties> ApplyFilter(
            IQueryable<PartnerWithNavigationProperties> query,
            string filterText,
            string partnerName = null,
            string address = null,
            string taxNo = null,
            string bookingEmail = null,
            string bookingCellPhone = null,
            bool? bookingEmailConfirmed = null,
            bool? bookingPhoneConfirmed = null,
            string email = null,
            string phone = null,
            string countryName = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Partner.PartnerName.Contains(filterText) || e.Partner.Address.Contains(filterText) || e.Partner.TaxNo.Contains(filterText) || e.Partner.BookingEmail.Contains(filterText) || e.Partner.BookingCellPhone.Contains(filterText) || e.Partner.Email.Contains(filterText) || e.Partner.Phone.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(partnerName), e => e.Partner.PartnerName.Contains(partnerName))
                    .WhereIf(!string.IsNullOrWhiteSpace(address), e => e.Partner.Address.Contains(address))
                    .WhereIf(!string.IsNullOrWhiteSpace(taxNo), e => e.Partner.TaxNo.Contains(taxNo))
                    .WhereIf(!string.IsNullOrWhiteSpace(bookingEmail), e => e.Partner.BookingEmail.Contains(bookingEmail))
                    .WhereIf(!string.IsNullOrWhiteSpace(bookingCellPhone), e => e.Partner.BookingCellPhone.Contains(bookingCellPhone))
                    .WhereIf(bookingEmailConfirmed.HasValue, e => e.Partner.BookingEmailConfirmed == bookingEmailConfirmed)
                    .WhereIf(bookingPhoneConfirmed.HasValue, e => e.Partner.BookingPhoneConfirmed == bookingPhoneConfirmed)
                    .WhereIf(!string.IsNullOrWhiteSpace(email), e => e.Partner.Email.Contains(email))
                    .WhereIf(!string.IsNullOrWhiteSpace(phone), e => e.Partner.Phone.Contains(phone))
                    .WhereIf(countryName != null && countryName != "", e => e.Country != null && e.Country.Id == countryName);
        }

        public async Task<List<Partner>> GetListAsync(
            string filterText = null,
            string partnerName = null,
            string address = null,
            string taxNo = null,
            string bookingEmail = null,
            string bookingCellPhone = null,
            bool? bookingEmailConfirmed = null,
            bool? bookingPhoneConfirmed = null,
            string email = null,
            string phone = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, partnerName, address, taxNo, bookingEmail, bookingCellPhone, bookingEmailConfirmed, bookingPhoneConfirmed, email, phone);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? PartnerConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string partnerName = null,
            string address = null,
            string taxNo = null,
            string bookingEmail = null,
            string bookingCellPhone = null,
            bool? bookingEmailConfirmed = null,
            bool? bookingPhoneConfirmed = null,
            string email = null,
            string phone = null,
            string countryName = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, partnerName, address, taxNo, bookingEmail, bookingCellPhone, bookingEmailConfirmed, bookingPhoneConfirmed, email, phone, countryName);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Partner> ApplyFilter(
            IQueryable<Partner> query,
            string filterText,
            string partnerName = null,
            string address = null,
            string taxNo = null,
            string bookingEmail = null,
            string bookingCellPhone = null,
            bool? bookingEmailConfirmed = null,
            bool? bookingPhoneConfirmed = null,
            string email = null,
            string phone = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.PartnerName.Contains(filterText) || e.Address.Contains(filterText) || e.TaxNo.Contains(filterText) || e.BookingEmail.Contains(filterText) || e.BookingCellPhone.Contains(filterText) || e.Email.Contains(filterText) || e.Phone.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(partnerName), e => e.PartnerName.Contains(partnerName))
                    .WhereIf(!string.IsNullOrWhiteSpace(address), e => e.Address.Contains(address))
                    .WhereIf(!string.IsNullOrWhiteSpace(taxNo), e => e.TaxNo.Contains(taxNo))
                    .WhereIf(!string.IsNullOrWhiteSpace(bookingEmail), e => e.BookingEmail.Contains(bookingEmail))
                    .WhereIf(!string.IsNullOrWhiteSpace(bookingCellPhone), e => e.BookingCellPhone.Contains(bookingCellPhone))
                    .WhereIf(bookingEmailConfirmed.HasValue, e => e.BookingEmailConfirmed == bookingEmailConfirmed)
                    .WhereIf(bookingPhoneConfirmed.HasValue, e => e.BookingPhoneConfirmed == bookingPhoneConfirmed)
                    .WhereIf(!string.IsNullOrWhiteSpace(email), e => e.Email.Contains(email))
                    .WhereIf(!string.IsNullOrWhiteSpace(phone), e => e.Phone.Contains(phone));
        }
    }
}