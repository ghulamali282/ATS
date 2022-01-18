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

namespace Ccm.MasterDatas
{
    public class EfCoreMasterDataRepository : EfCoreRepository<CcmDbContext, MasterData, Guid>, IMasterDataRepository
    {
        public EfCoreMasterDataRepository(IDbContextProvider<CcmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<MasterData>> GetListAsync(
            string filterText = null,
            Guid? parentId = null,
            string name = null,
            string value = null,
            bool? inlineValue = null,
            bool? visibleToTenant = null,
            bool? isSection = null,
            bool? isRadio = null,
            bool? isExportable = null,
            string icon = null,
            string cultureName = null,
            int? sortOrderMin = null,
            int? sortOrderMax = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, parentId, name, value, inlineValue, visibleToTenant, isSection, isRadio, isExportable, icon, cultureName, sortOrderMin, sortOrderMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? MasterDataConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? parentId = null,
            string name = null,
            string value = null,
            bool? inlineValue = null,
            bool? visibleToTenant = null,
            bool? isSection = null,
            bool? isRadio = null,
            bool? isExportable = null,
            string icon = null,
            string cultureName = null,
            int? sortOrderMin = null,
            int? sortOrderMax = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, parentId, name, value, inlineValue, visibleToTenant, isSection, isRadio, isExportable, icon, cultureName, sortOrderMin, sortOrderMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<MasterData> ApplyFilter(
            IQueryable<MasterData> query,
            string filterText,
            Guid? parentId = null,
            string name = null,
            string value = null,
            bool? inlineValue = null,
            bool? visibleToTenant = null,
            bool? isSection = null,
            bool? isRadio = null,
            bool? isExportable = null,
            string icon = null,
            string cultureName = null,
            int? sortOrderMin = null,
            int? sortOrderMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText) || e.Value.Contains(filterText) || e.Icon.Contains(filterText) || e.CultureName.Contains(filterText))
                    .WhereIf(parentId.HasValue, e => e.ParentId == parentId)
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(value), e => e.Value.Contains(value))
                    .WhereIf(inlineValue.HasValue, e => e.InlineValue == inlineValue)
                    .WhereIf(visibleToTenant.HasValue, e => e.VisibleToTenant == visibleToTenant)
                    .WhereIf(isSection.HasValue, e => e.IsSection == isSection)
                    .WhereIf(isRadio.HasValue, e => e.IsRadio == isRadio)
                    .WhereIf(isExportable.HasValue, e => e.IsExportable == isExportable)
                    .WhereIf(!string.IsNullOrWhiteSpace(icon), e => e.Icon.Contains(icon))
                    .WhereIf(!string.IsNullOrWhiteSpace(cultureName), e => e.CultureName.Contains(cultureName))
                    .WhereIf(sortOrderMin.HasValue, e => e.SortOrder >= sortOrderMin.Value)
                    .WhereIf(sortOrderMax.HasValue, e => e.SortOrder <= sortOrderMax.Value);
        }
    }
}