using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Amm.ShpCabins
{
    public interface IShpCabinRepository : IRepository<ShpCabin, Guid>
    {
        Task<List<ShpCabin>> GetListAsync(
            string filterText = null,
            Guid? ship = null,
            Guid? cabinCategory = null,
            string cabinNo = null,
            int? cabinNoNumericMin = null,
            int? cabinNoNumericMax = null,
            Guid? bedLayout = null,
            int? standardCapacityMin = null,
            int? standardCapacityMax = null,
            int? maxCapacityMin = null,
            int? maxCapacityMax = null,
            bool? portohole = null,
            bool? window = null,
            decimal? cabinAreaMin = null,
            decimal? cabinAreaMax = null,
            bool? balcon = null,
            decimal? balconAreaMin = null,
            decimal? balconAreaMax = null,
            bool? isDisabled = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            Guid? ship = null,
            Guid? cabinCategory = null,
            string cabinNo = null,
            int? cabinNoNumericMin = null,
            int? cabinNoNumericMax = null,
            Guid? bedLayout = null,
            int? standardCapacityMin = null,
            int? standardCapacityMax = null,
            int? maxCapacityMin = null,
            int? maxCapacityMax = null,
            bool? portohole = null,
            bool? window = null,
            decimal? cabinAreaMin = null,
            decimal? cabinAreaMax = null,
            bool? balcon = null,
            decimal? balconAreaMin = null,
            decimal? balconAreaMax = null,
            bool? isDisabled = null,
            CancellationToken cancellationToken = default);
    }
}