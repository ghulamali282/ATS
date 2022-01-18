using Ccm.Shared;
using Ccm.PaymentPolicies;
using Ccm.CancellationPolicies;
using Ccm.Destinations;
using Ccm.AgePolicies;
using Ccm.MasterDatas;
using Ccm.Partners;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Ccm.Permissions;
using Ccm.Itineraries;

namespace Ccm.Itineraries
{

    [Authorize(CcmPermissions.Itineraries.Default)]
    public class ItinerariesAppService : ApplicationService, IItinerariesAppService
    {
        private readonly IItineraryRepository _itineraryRepository;
        private readonly IRepository<Partner, Guid> _partnerRepository;
        private readonly IRepository<MasterData, Guid> _masterDataRepository;
        private readonly IRepository<AgePolicy, Guid> _agePolicyRepository;
        private readonly IRepository<Destination, Guid> _destinationRepository;
        private readonly IRepository<CancellationPolicy, Guid> _cancellationPolicyRepository;
        private readonly IRepository<PaymentPolicy, Guid> _paymentPolicyRepository;

        public ItinerariesAppService(IItineraryRepository itineraryRepository, IRepository<Partner, Guid> partnerRepository, IRepository<MasterData, Guid> masterDataRepository, IRepository<AgePolicy, Guid> agePolicyRepository, IRepository<Destination, Guid> destinationRepository, IRepository<CancellationPolicy, Guid> cancellationPolicyRepository, IRepository<PaymentPolicy, Guid> paymentPolicyRepository)
        {
            _itineraryRepository = itineraryRepository; _partnerRepository = partnerRepository;
            _masterDataRepository = masterDataRepository;
            _agePolicyRepository = agePolicyRepository;
            _destinationRepository = destinationRepository;
            _cancellationPolicyRepository = cancellationPolicyRepository;
            _paymentPolicyRepository = paymentPolicyRepository;
        }

        public virtual async Task<PagedResultDto<ItineraryWithNavigationPropertiesDto>> GetListAsync(GetItinerariesInput input)
        {
            var totalCount = await _itineraryRepository.GetCountAsync(input.FilterText, input.ItineraryNameString, input.ItineraryCode, input.GoogleMapLink, input.DurationMin, input.DurationMax, input.ExtendedItinerary, input.Marina, input.EmbarcationLatitude, input.EmbarcationLongitude, input.DisembarkationLatitude, input.DisembarkationLongitude, input.CheckInTime, input.CheckOutTime, input.TransferIncluded, input.Video, input.RequestDurationMin, input.RequestDurationMax, input.OptionDurationMin, input.OptionDurationMax, input.OperatorName, input.Themes, input.Boarding, input.AgePolicyId, input.EmbarcationPort, input.DisembarkationPort, input.CancellationPolicy, input.PaymentPolicy, input.ItineraryName);
            var items = await _itineraryRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.ItineraryNameString, input.ItineraryCode, input.GoogleMapLink, input.DurationMin, input.DurationMax, input.ExtendedItinerary, input.Marina, input.EmbarcationLatitude, input.EmbarcationLongitude, input.DisembarkationLatitude, input.DisembarkationLongitude, input.CheckInTime, input.CheckOutTime, input.TransferIncluded, input.Video, input.RequestDurationMin, input.RequestDurationMax, input.OptionDurationMin, input.OptionDurationMax, input.OperatorName, input.Themes, input.Boarding, input.AgePolicyId, input.EmbarcationPort, input.DisembarkationPort, input.CancellationPolicy, input.PaymentPolicy, input.ItineraryName, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ItineraryWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ItineraryWithNavigationProperties>, List<ItineraryWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<ItineraryWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<ItineraryWithNavigationProperties, ItineraryWithNavigationPropertiesDto>
                (await _itineraryRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<ItineraryDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Itinerary, ItineraryDto>(await _itineraryRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetPartnerLookupAsync(LookupRequestDto input)
        {
            var query = (await _partnerRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.PartnerName != null &&
                         x.PartnerName.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<Partner>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Partner>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetMasterDataLookupAsync(LookupRequestDto input)
        {
            var query = (await _masterDataRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.Name != null &&
                         x.Name.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<MasterData>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<MasterData>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetAgePolicyLookupAsync(LookupRequestDto input)
        {
            var query = (await _agePolicyRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.DemoField != null &&
                         x.DemoField.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<AgePolicy>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<AgePolicy>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetDestinationLookupAsync(LookupRequestDto input)
        {
            var query = (await _destinationRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.City != null &&
                         x.City.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<Destination>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Destination>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetCancellationPolicyLookupAsync(LookupRequestDto input)
        {
            var query = (await _cancellationPolicyRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.NameString != null &&
                         x.NameString.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<CancellationPolicy>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CancellationPolicy>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetPaymentPolicyLookupAsync(LookupRequestDto input)
        {
            var query = (await _paymentPolicyRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.PolicyString != null &&
                         x.PolicyString.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<PaymentPolicy>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<PaymentPolicy>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        [Authorize(CcmPermissions.Itineraries.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _itineraryRepository.DeleteAsync(id);
        }

        [Authorize(CcmPermissions.Itineraries.Create)]
        public virtual async Task<ItineraryDto> CreateAsync(ItineraryCreateDto input)
        {
            if (input.OperatorName == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Partner"]]);
            }
            if (input.Themes == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }
            if (input.Boarding == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }
            if (input.AgePolicyId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["AgePolicy"]]);
            }
            if (input.EmbarcationPort == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Destination"]]);
            }
            if (input.DisembarkationPort == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Destination"]]);
            }
            if (input.CancellationPolicy == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["CancellationPolicy"]]);
            }
            if (input.PaymentPolicy == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["PaymentPolicy"]]);
            }
            if (input.ItineraryName == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }

            var itinerary = ObjectMapper.Map<ItineraryCreateDto, Itinerary>(input);
            itinerary.TenantId = CurrentTenant.Id;
            itinerary = await _itineraryRepository.InsertAsync(itinerary, autoSave: true);
            return ObjectMapper.Map<Itinerary, ItineraryDto>(itinerary);
        }

        [Authorize(CcmPermissions.Itineraries.Edit)]
        public virtual async Task<ItineraryDto> UpdateAsync(Guid id, ItineraryUpdateDto input)
        {
            if (input.OperatorName == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Partner"]]);
            }
            if (input.Themes == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }
            if (input.Boarding == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }
            if (input.AgePolicyId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["AgePolicy"]]);
            }
            if (input.EmbarcationPort == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Destination"]]);
            }
            if (input.DisembarkationPort == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Destination"]]);
            }
            if (input.CancellationPolicy == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["CancellationPolicy"]]);
            }
            if (input.PaymentPolicy == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["PaymentPolicy"]]);
            }
            if (input.ItineraryName == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }

            var itinerary = await _itineraryRepository.GetAsync(id);
            ObjectMapper.Map(input, itinerary);
            itinerary = await _itineraryRepository.UpdateAsync(itinerary, autoSave: true);
            return ObjectMapper.Map<Itinerary, ItineraryDto>(itinerary);
        }
    }
}