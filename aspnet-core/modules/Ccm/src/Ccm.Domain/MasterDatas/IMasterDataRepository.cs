using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ccm.MasterDatas
{
    public interface IMasterDataRepository : IRepository<MasterData, Guid>
    {
        Task<List<MasterData>> GetListAsync(
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
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default);
    }
}