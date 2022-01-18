using Amm.MasterDatas;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Amm.CruiseRegions
{
    public class CruiseRegion : Entity<Guid>
    {
        [CanBeNull]
        public virtual string FreeEntry { get; set; }
        public Guid CruiseRegionName { get; set; }

        public CruiseRegion()
        {

        }

        public CruiseRegion(Guid id, string freeEntry, Guid cruiseRegionName)
        {
            Id = id;
            FreeEntry = freeEntry;
            CruiseRegionName = cruiseRegionName;
        }
    }
}