using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Crm.Clients
{
    public interface IClientRepository : IRepository<Client, Guid>
    {
        Task<List<Client>> GetListAsync(
            string filterText = null,
            Guid? title = null,
            string firstName = null,
            string secondName = null,
            Guid? gender = null,
            DateTime? clientDOBMin = null,
            DateTime? clientDOBMax = null,
            Guid? agePolicy = null,
            string email = null,
            bool? emailConfirmed = null,
            string country = null,
            string nacionality = null,
            string state = null,
            string zipCode = null,
            string city = null,
            string cellPhone = null,
            bool? cellPhoneConfirmed = null,
            Guid? documentType = null,
            string documentNo = null,
            DateTime? issueDateMin = null,
            DateTime? issueDateMax = null,
            DateTime? expirationMin = null,
            DateTime? expirationMax = null,
            bool? mailingList = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            Guid? title = null,
            string firstName = null,
            string secondName = null,
            Guid? gender = null,
            DateTime? clientDOBMin = null,
            DateTime? clientDOBMax = null,
            Guid? agePolicy = null,
            string email = null,
            bool? emailConfirmed = null,
            string country = null,
            string nacionality = null,
            string state = null,
            string zipCode = null,
            string city = null,
            string cellPhone = null,
            bool? cellPhoneConfirmed = null,
            Guid? documentType = null,
            string documentNo = null,
            DateTime? issueDateMin = null,
            DateTime? issueDateMax = null,
            DateTime? expirationMin = null,
            DateTime? expirationMax = null,
            bool? mailingList = null,
            CancellationToken cancellationToken = default);
    }
}