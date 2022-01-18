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

namespace Amm.Marinas
{
    public class EfCoreMarinaRepository : EfCoreRepository<AmmDbContext, Marina, Guid>, IMarinaRepository
    {
        public EfCoreMarinaRepository(IDbContextProvider<AmmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<MarinaWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryForNavigationPropertiesAsync())
                .FirstOrDefaultAsync(e => e.Marina.Id == id, GetCancellationToken(cancellationToken));
        }

        public async Task<List<MarinaWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string marinaNameString = null,
            string latitude = null,
            string longitude = null,
            Guid? marinaName = null,
            Guid? destination = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, marinaNameString, latitude, longitude, marinaName, destination);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? MarinaConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<MarinaWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from marina in (await GetDbSetAsync())
                   join masterData in (await GetDbContextAsync()).MasterDatas on marina.MarinaName equals masterData.Id into masterDatas
                   from masterData in masterDatas.DefaultIfEmpty()
                   join destination in (await GetDbContextAsync()).Destinations on marina.Destination equals destination.Id into destinations
                   from destination in destinations.DefaultIfEmpty()

                   select new MarinaWithNavigationProperties
                   {
                       Marina = marina,
                       MasterData = masterData,
                       Destination = destination
                   };
        }

        protected virtual IQueryable<MarinaWithNavigationProperties> ApplyFilter(
            IQueryable<MarinaWithNavigationProperties> query,
            string filterText,
            string marinaNameString = null,
            string latitude = null,
            string longitude = null,
            Guid? marinaName = null,
            Guid? destination = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Marina.MarinaNameString.Contains(filterText) || e.Marina.Latitude.Contains(filterText) || e.Marina.Longitude.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(marinaNameString), e => e.Marina.MarinaNameString.Contains(marinaNameString))
                    .WhereIf(!string.IsNullOrWhiteSpace(latitude), e => e.Marina.Latitude.Contains(latitude))
                    .WhereIf(!string.IsNullOrWhiteSpace(longitude), e => e.Marina.Longitude.Contains(longitude))
                    .WhereIf(marinaName != null && marinaName != Guid.Empty, e => e.MasterData != null && e.MasterData.Id == marinaName)
                    .WhereIf(destination != null && destination != Guid.Empty, e => e.Destination != null && e.Destination.Id == destination);
        }

        public async Task<List<Marina>> GetListAsync(
            string filterText = null,
            string marinaNameString = null,
            string latitude = null,
            string longitude = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, marinaNameString, latitude, longitude);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? MarinaConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string marinaNameString = null,
            string latitude = null,
            string longitude = null,
            Guid? marinaName = null,
            Guid? destination = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, marinaNameString, latitude, longitude, marinaName, destination);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Marina> ApplyFilter(
            IQueryable<Marina> query,
            string filterText,
            string marinaNameString = null,
            string latitude = null,
            string longitude = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.MarinaNameString.Contains(filterText) || e.Latitude.Contains(filterText) || e.Longitude.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(marinaNameString), e => e.MarinaNameString.Contains(marinaNameString))
                    .WhereIf(!string.IsNullOrWhiteSpace(latitude), e => e.Latitude.Contains(latitude))
                    .WhereIf(!string.IsNullOrWhiteSpace(longitude), e => e.Longitude.Contains(longitude));
        }
    }
}