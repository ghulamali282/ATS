using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ccm.Partners
{
    public interface IPartnerRepository : IRepository<Partner, Guid>
    {
        Task<PartnerWithNavigationProperties> GetWithNavigationPropertiesAsync(
    Guid id,
    CancellationToken cancellationToken = default
);

        Task<List<PartnerWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
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
            CancellationToken cancellationToken = default
        );

        Task<List<Partner>> GetListAsync(
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
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default);
    }
}