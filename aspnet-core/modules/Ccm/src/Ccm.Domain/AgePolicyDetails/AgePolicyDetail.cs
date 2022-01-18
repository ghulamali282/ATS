using Ccm.MasterDatas;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Ccm.AgePolicyDetails
{
    public class AgePolicyDetail : Entity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual int AgeFrom { get; set; }

        public virtual Guid AgePolicy { get; set; }

        public virtual int AgeTo { get; set; }
        public Guid Service { get; set; }

        public AgePolicyDetail()
        {

        }

        public AgePolicyDetail(Guid id, int ageFrom, Guid agePolicy, int ageTo, Guid service)
        {
            Id = id;
            AgeFrom = ageFrom;
            AgePolicy = agePolicy;
            AgeTo = ageTo;
            Service = service;
        }
    }
}