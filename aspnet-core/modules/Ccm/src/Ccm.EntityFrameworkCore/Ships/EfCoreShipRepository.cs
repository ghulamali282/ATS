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

namespace Ccm.Ships
{
    public class EfCoreShipRepository : EfCoreRepository<CcmDbContext, Ship, Guid>, IShipRepository
    {
        public EfCoreShipRepository(IDbContextProvider<CcmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Ship>> GetListAsync(
            string filterText = null,
            string shipName = null,
            Guid? shipCategory = null,
            Guid? shipOperator = null,
            Guid? type = null,
            string flag = null,
            Guid? homePort = null,
            Guid? manufacturer = null,
            Guid? model = null,
            int? yearBuildMin = null,
            int? yearBuildMax = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, shipName, shipCategory, shipOperator, type, flag, homePort, manufacturer, model, yearBuildMin, yearBuildMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ShipConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string shipName = null,
            Guid? shipCategory = null,
            Guid? shipOperator = null,
            Guid? type = null,
            string flag = null,
            Guid? homePort = null,
            Guid? manufacturer = null,
            Guid? model = null,
            int? yearBuildMin = null,
            int? yearBuildMax = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, shipName, shipCategory, shipOperator, type, flag, homePort, manufacturer, model, yearBuildMin, yearBuildMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Ship> ApplyFilter(
            IQueryable<Ship> query,
            string filterText,
            string shipName = null,
            Guid? shipCategory = null,
            Guid? shipOperator = null,
            Guid? type = null,
            string flag = null,
            Guid? homePort = null,
            Guid? manufacturer = null,
            Guid? model = null,
            int? yearBuildMin = null,
            int? yearBuildMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.ShipName.Contains(filterText) || e.Flag.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(shipName), e => e.ShipName.Contains(shipName))
                    .WhereIf(shipCategory.HasValue, e => e.ShipCategory == shipCategory)
                    .WhereIf(shipOperator.HasValue, e => e.ShipOperator == shipOperator)
                    .WhereIf(type.HasValue, e => e.Type == type)
                    .WhereIf(!string.IsNullOrWhiteSpace(flag), e => e.Flag.Contains(flag))
                    .WhereIf(homePort.HasValue, e => e.HomePort == homePort)
                    .WhereIf(manufacturer.HasValue, e => e.Manufacturer == manufacturer)
                    .WhereIf(model.HasValue, e => e.Model == model)
                    .WhereIf(yearBuildMin.HasValue, e => e.YearBuild >= yearBuildMin.Value)
                    .WhereIf(yearBuildMax.HasValue, e => e.YearBuild <= yearBuildMax.Value);
        }
    }
}