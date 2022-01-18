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

namespace Crm.Contracts
{
    public class EfCoreContractRepository : EfCoreRepository<CrmDbContext, Contract, Guid>, IContractRepository
    {
        public EfCoreContractRepository(IDbContextProvider<CrmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Contract>> GetListAsync(
            string filterText = null,
            Guid? operatorName = null,
            int? seasonMin = null,
            int? seasonMax = null,
            bool? isEnabledAgent = null,
            bool? isEnabledOperator = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, operatorName, seasonMin, seasonMax, isEnabledAgent, isEnabledOperator);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ContractConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? operatorName = null,
            int? seasonMin = null,
            int? seasonMax = null,
            bool? isEnabledAgent = null,
            bool? isEnabledOperator = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, operatorName, seasonMin, seasonMax, isEnabledAgent, isEnabledOperator);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Contract> ApplyFilter(
            IQueryable<Contract> query,
            string filterText,
            Guid? operatorName = null,
            int? seasonMin = null,
            int? seasonMax = null,
            bool? isEnabledAgent = null,
            bool? isEnabledOperator = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
                    .WhereIf(operatorName.HasValue, e => e.OperatorName == operatorName)
                    .WhereIf(seasonMin.HasValue, e => e.Season >= seasonMin.Value)
                    .WhereIf(seasonMax.HasValue, e => e.Season <= seasonMax.Value)
                    .WhereIf(isEnabledAgent.HasValue, e => e.IsEnabledAgent == isEnabledAgent)
                    .WhereIf(isEnabledOperator.HasValue, e => e.IsEnabledOperator == isEnabledOperator);
        }
    }
}