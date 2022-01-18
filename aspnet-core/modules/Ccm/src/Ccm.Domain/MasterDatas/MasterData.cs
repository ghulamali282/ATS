using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Ccm.MasterDatas
{
    public class MasterData : Entity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid? ParentId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public virtual string Value { get; set; }

        public virtual bool? InlineValue { get; set; }

        public virtual bool VisibleToTenant { get; set; }

        public virtual bool IsSection { get; set; }

        public virtual bool IsRadio { get; set; }

        public virtual bool IsExportable { get; set; }

        [CanBeNull]
        public virtual string Icon { get; set; }

        [NotNull]
        public virtual string CultureName { get; set; }

        public virtual int SortOrder { get; set; }

        public MasterData()
        {

        }

        public MasterData(Guid id, string name, string value, bool visibleToTenant, bool isSection, bool isRadio, bool isExportable, string cultureName, int sortOrder, Guid? parentId = null, bool? inlineValue = null, string icon = null)
        {
            Id = id;
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), MasterDataConsts.NameMaxLength, 0);
            Check.NotNull(cultureName, nameof(cultureName));
            Check.Length(cultureName, nameof(cultureName), MasterDataConsts.CultureNameMaxLength, 0);
            Check.Length(icon, nameof(icon), MasterDataConsts.IconMaxLength, 0);
            Name = name;
            Value = value;
            VisibleToTenant = visibleToTenant;
            IsSection = isSection;
            IsRadio = isRadio;
            IsExportable = isExportable;
            CultureName = cultureName;
            SortOrder = sortOrder;
            ParentId = parentId;
            InlineValue = inlineValue;
            Icon = icon;
        }
    }
}