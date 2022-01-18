using Ccm.Shared;
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
using Ccm.PaymentPolicies;

namespace Ccm.PaymentPolicies
{

    [Authorize(CcmPermissions.PaymentPolicies.Default)]
    public class PaymentPoliciesAppService : ApplicationService, IPaymentPoliciesAppService
    {
        private readonly IPaymentPolicyRepository _paymentPolicyRepository;
        private readonly IRepository<Partner, Guid> _partnerRepository;
        private readonly IRepository<MasterData, Guid> _masterDataRepository;

        public PaymentPoliciesAppService(IPaymentPolicyRepository paymentPolicyRepository, IRepository<Partner, Guid> partnerRepository, IRepository<MasterData, Guid> masterDataRepository)
        {
            _paymentPolicyRepository = paymentPolicyRepository; _partnerRepository = partnerRepository;
            _masterDataRepository = masterDataRepository;
        }

        public virtual async Task<PagedResultDto<PaymentPolicyWithNavigationPropertiesDto>> GetListAsync(GetPaymentPoliciesInput input)
        {
            var totalCount = await _paymentPolicyRepository.GetCountAsync(input.FilterText, input.DelayedDepositAt, input.DepositMin, input.DepositMax, input.DepositAtReservation, input.DepositType, input.FinalPaymentDueDaysMin, input.FinalPaymentDueDaysMax, input.FullPaymentRequiredDaysMin, input.FullPaymentRequiredDaysMax, input.PolicyString, input.OperatorName, input.PolicyName);
            var items = await _paymentPolicyRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.DelayedDepositAt, input.DepositMin, input.DepositMax, input.DepositAtReservation, input.DepositType, input.FinalPaymentDueDaysMin, input.FinalPaymentDueDaysMax, input.FullPaymentRequiredDaysMin, input.FullPaymentRequiredDaysMax, input.PolicyString, input.OperatorName, input.PolicyName, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<PaymentPolicyWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<PaymentPolicyWithNavigationProperties>, List<PaymentPolicyWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<PaymentPolicyWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<PaymentPolicyWithNavigationProperties, PaymentPolicyWithNavigationPropertiesDto>
                (await _paymentPolicyRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<PaymentPolicyDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<PaymentPolicy, PaymentPolicyDto>(await _paymentPolicyRepository.GetAsync(id));
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

        [Authorize(CcmPermissions.PaymentPolicies.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _paymentPolicyRepository.DeleteAsync(id);
        }

        [Authorize(CcmPermissions.PaymentPolicies.Create)]
        public virtual async Task<PaymentPolicyDto> CreateAsync(PaymentPolicyCreateDto input)
        {
            if (input.OperatorName == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Partner"]]);
            }
            if (input.PolicyName == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }

            var paymentPolicy = ObjectMapper.Map<PaymentPolicyCreateDto, PaymentPolicy>(input);
            paymentPolicy.TenantId = CurrentTenant.Id;
            paymentPolicy = await _paymentPolicyRepository.InsertAsync(paymentPolicy, autoSave: true);
            return ObjectMapper.Map<PaymentPolicy, PaymentPolicyDto>(paymentPolicy);
        }

        [Authorize(CcmPermissions.PaymentPolicies.Edit)]
        public virtual async Task<PaymentPolicyDto> UpdateAsync(Guid id, PaymentPolicyUpdateDto input)
        {
            if (input.OperatorName == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Partner"]]);
            }
            if (input.PolicyName == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }

            var paymentPolicy = await _paymentPolicyRepository.GetAsync(id);
            ObjectMapper.Map(input, paymentPolicy);
            paymentPolicy = await _paymentPolicyRepository.UpdateAsync(paymentPolicy, autoSave: true);
            return ObjectMapper.Map<PaymentPolicy, PaymentPolicyDto>(paymentPolicy);
        }
    }
}