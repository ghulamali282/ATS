using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Crm.EntityFrameworkCore;

namespace Crm.Passengers
{
    public class EfCorePassengerRepository : EfCoreRepository<CrmDbContext, Passenger, Guid>, IPassengerRepository
    {
        public EfCorePassengerRepository(IDbContextProvider<CrmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Passenger>> GetListAsync(
            string filterText = null,
            Guid? reservation = null,
            Guid? reservationDetail = null,
            bool? reservationHolder = null,
            Guid? title = null,
            string firstName = null,
            string lastName = null,
            string country = null,
            Guid? agePolicyDetail = null,
            DateTime? passengerDOBMin = null,
            DateTime? passengerDOBMax = null,
            Guid? documentType = null,
            string documentNo = null,
            DateTime? issueDateMin = null,
            DateTime? issueDateMax = null,
            DateTime? expirationMin = null,
            DateTime? expirationMax = null,
            string passengerNote = null,
            int? clientNoMin = null,
            int? clientNoMax = null,
            Guid? reduction = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, reservation, reservationDetail, reservationHolder, title, firstName, lastName, country, agePolicyDetail, passengerDOBMin, passengerDOBMax, documentType, documentNo, issueDateMin, issueDateMax, expirationMin, expirationMax, passengerNote, clientNoMin, clientNoMax, reduction);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? PassengerConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? reservation = null,
            Guid? reservationDetail = null,
            bool? reservationHolder = null,
            Guid? title = null,
            string firstName = null,
            string lastName = null,
            string country = null,
            Guid? agePolicyDetail = null,
            DateTime? passengerDOBMin = null,
            DateTime? passengerDOBMax = null,
            Guid? documentType = null,
            string documentNo = null,
            DateTime? issueDateMin = null,
            DateTime? issueDateMax = null,
            DateTime? expirationMin = null,
            DateTime? expirationMax = null,
            string passengerNote = null,
            int? clientNoMin = null,
            int? clientNoMax = null,
            Guid? reduction = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, reservation, reservationDetail, reservationHolder, title, firstName, lastName, country, agePolicyDetail, passengerDOBMin, passengerDOBMax, documentType, documentNo, issueDateMin, issueDateMax, expirationMin, expirationMax, passengerNote, clientNoMin, clientNoMax, reduction);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Passenger> ApplyFilter(
            IQueryable<Passenger> query,
            string filterText,
            Guid? reservation = null,
            Guid? reservationDetail = null,
            bool? reservationHolder = null,
            Guid? title = null,
            string firstName = null,
            string lastName = null,
            string country = null,
            Guid? agePolicyDetail = null,
            DateTime? passengerDOBMin = null,
            DateTime? passengerDOBMax = null,
            Guid? documentType = null,
            string documentNo = null,
            DateTime? issueDateMin = null,
            DateTime? issueDateMax = null,
            DateTime? expirationMin = null,
            DateTime? expirationMax = null,
            string passengerNote = null,
            int? clientNoMin = null,
            int? clientNoMax = null,
            Guid? reduction = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.FirstName.Contains(filterText) || e.LastName.Contains(filterText) || e.Country.Contains(filterText) || e.DocumentNo.Contains(filterText) || e.PassengerNote.Contains(filterText))
                    .WhereIf(reservation.HasValue, e => e.Reservation == reservation)
                    .WhereIf(reservationDetail.HasValue, e => e.ReservationDetail == reservationDetail)
                    .WhereIf(reservationHolder.HasValue, e => e.ReservationHolder == reservationHolder)
                    .WhereIf(title.HasValue, e => e.Title == title)
                    .WhereIf(!string.IsNullOrWhiteSpace(firstName), e => e.FirstName.Contains(firstName))
                    .WhereIf(!string.IsNullOrWhiteSpace(lastName), e => e.LastName.Contains(lastName))
                    .WhereIf(!string.IsNullOrWhiteSpace(country), e => e.Country.Contains(country))
                    .WhereIf(agePolicyDetail.HasValue, e => e.AgePolicyDetail == agePolicyDetail)
                    .WhereIf(passengerDOBMin.HasValue, e => e.PassengerDOB >= passengerDOBMin.Value)
                    .WhereIf(passengerDOBMax.HasValue, e => e.PassengerDOB <= passengerDOBMax.Value)
                    .WhereIf(documentType.HasValue, e => e.DocumentType == documentType)
                    .WhereIf(!string.IsNullOrWhiteSpace(documentNo), e => e.DocumentNo.Contains(documentNo))
                    .WhereIf(issueDateMin.HasValue, e => e.IssueDate >= issueDateMin.Value)
                    .WhereIf(issueDateMax.HasValue, e => e.IssueDate <= issueDateMax.Value)
                    .WhereIf(expirationMin.HasValue, e => e.Expiration >= expirationMin.Value)
                    .WhereIf(expirationMax.HasValue, e => e.Expiration <= expirationMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(passengerNote), e => e.PassengerNote.Contains(passengerNote))
                    .WhereIf(clientNoMin.HasValue, e => e.ClientNo >= clientNoMin.Value)
                    .WhereIf(clientNoMax.HasValue, e => e.ClientNo <= clientNoMax.Value)
                    .WhereIf(reduction.HasValue, e => e.Reduction == reduction);
        }
    }
}