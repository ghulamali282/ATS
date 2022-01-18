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

namespace Amm.MasterDatas
{
    public class EfCoreMasterDataRepository : EfCoreRepository<AmmDbContext, MasterData, Guid>, IMasterDataRepository
    {
        public EfCoreMasterDataRepository(IDbContextProvider<AmmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<MasterData>> GetListAsync(
            string filterText = null,
            Guid? parentId = null,
            string name = null,
            int? sortOrderMin = null,
            int? sortOrderMax = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, parentId, name, sortOrderMin, sortOrderMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? MasterDataConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? parentId = null,
            string name = null,
            int? sortOrderMin = null,
            int? sortOrderMax = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, parentId, name, sortOrderMin, sortOrderMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<MasterData> ApplyFilter(
            IQueryable<MasterData> query,
            string filterText,
            Guid? parentId = null,
            string name = null,
            int? sortOrderMin = null,
            int? sortOrderMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText))
                    .WhereIf(parentId.HasValue, e => e.ParentId == parentId)
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(sortOrderMin.HasValue, e => e.SortOrder >= sortOrderMin.Value)
                    .WhereIf(sortOrderMax.HasValue, e => e.SortOrder <= sortOrderMax.Value);
        }
    }
}