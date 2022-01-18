using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Ccm.EntityFrameworkCore;

namespace Ccm.Destinations
{
    public class EfCoreDestinationRepository : EfCoreRepository<CcmDbContext, Destination, Guid>, IDestinationRepository
    {
        public EfCoreDestinationRepository(IDbContextProvider<CcmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Destination>> GetListAsync(
            string filterText = null,
            string city = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, city);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? DestinationConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string city = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, city);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Destination> ApplyFilter(
            IQueryable<Destination> query,
            string filterText,
            string city = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.City.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(city), e => e.City.Contains(city));
        }
    }
}