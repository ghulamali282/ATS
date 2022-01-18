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

namespace Amm.AppDefaults
{
    public class EfCoreAppDefaultRepository : EfCoreRepository<AmmDbContext, AppDefault, Guid>, IAppDefaultRepository
    {
        public EfCoreAppDefaultRepository(IDbContextProvider<AmmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<AppDefault>> GetListAsync(
            string filterText = null,
            string settingsName = null,
            string settingsValue = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, settingsName, settingsValue);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? AppDefaultConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string settingsName = null,
            string settingsValue = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, settingsName, settingsValue);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<AppDefault> ApplyFilter(
            IQueryable<AppDefault> query,
            string filterText,
            string settingsName = null,
            string settingsValue = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.SettingsName.Contains(filterText) || e.SettingsValue.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(settingsName), e => e.SettingsName.Contains(settingsName))
                    .WhereIf(!string.IsNullOrWhiteSpace(settingsValue), e => e.SettingsValue.Contains(settingsValue));
        }
    }
}