using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Crm.Passengers
{
    public interface IPassengerRepository : IRepository<Passenger, Guid>
    {
        Task<List<Passenger>> GetListAsync(
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
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default);
    }
}