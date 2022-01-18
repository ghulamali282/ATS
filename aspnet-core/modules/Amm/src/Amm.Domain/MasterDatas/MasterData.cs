using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Amm.MasterDatas
{
    public class MasterData : Entity<Guid>
    {
        public virtual Guid? ParentId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        public virtual int SortOrder { get; set; }

        public MasterData()
        {

        }

        public MasterData(Guid id, string name, int sortOrder, Guid? parentId = null)
        {
            Id = id;
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), MasterDataConsts.NameMaxLength, 0);
            Name = name;
            SortOrder = sortOrder;
            ParentId = parentId;
        }
    }
}