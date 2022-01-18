using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Amm.EntityFrameworkCore;

namespace Amm.ShipOperators
{
    public class EfCoreShipOperatorRepository : EfCoreRepository<AmmDbContext, ShipOperator, Guid>, IShipOperatorRepository
    {
        public EfCoreShipOperatorRepository(IDbContextProvider<AmmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<ShipOperator>> GetListAsync(
            string filterText = null,
            string operatorName = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, operatorName);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ShipOperatorConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string operatorName = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, operatorName);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ShipOperator> ApplyFilter(
            IQueryable<ShipOperator> query,
            string filterText,
            string operatorName = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.OperatorName.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(operatorName), e => e.OperatorName.Contains(operatorName));
        }
    }
}