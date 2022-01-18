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

namespace Amm.Partners
{
    public class EfCorePartnerRepository : EfCoreRepository<AmmDbContext, Partner, Guid>, IPartnerRepository
    {
        public EfCorePartnerRepository(IDbContextProvider<AmmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Partner>> GetListAsync(
            string filterText = null,
            string partnerName = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, partnerName);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? PartnerConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string partnerName = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, partnerName);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Partner> ApplyFilter(
            IQueryable<Partner> query,
            string filterText,
            string partnerName = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.PartnerName.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(partnerName), e => e.PartnerName.Contains(partnerName));
        }
    }
}