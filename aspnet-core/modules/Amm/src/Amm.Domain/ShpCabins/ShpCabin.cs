using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Amm.ShpCabins
{
    public class ShpCabin : Entity<Guid>
    {
        public virtual Guid Ship { get; set; }

        public virtual Guid CabinCategory { get; set; }

        [NotNull]
        public virtual string CabinNo { get; set; }

        public virtual int CabinNoNumeric { get; set; }

        public virtual Guid BedLayout { get; set; }

        public virtual int StandardCapacity { get; set; }

        public virtual int MaxCapacity { get; set; }

        public virtual bool Portohole { get; set; }

        public virtual bool Window { get; set; }

        public virtual decimal CabinArea { get; set; }

        public virtual bool Balcon { get; set; }

        public virtual decimal BalconArea { get; set; }

        public virtual bool IsDisabled { get; set; }

        public ShpCabin()
        {

        }

        public ShpCabin(Guid id, Guid ship, Guid cabinCategory, string cabinNo, int cabinNoNumeric, Guid bedLayout, int standardCapacity, int maxCapacity, bool portohole, bool window, decimal cabinArea, bool balcon, decimal balconArea, bool isDisabled)
        {
            Id = id;
            Check.NotNull(cabinNo, nameof(cabinNo));
            Check.Length(cabinNo, nameof(cabinNo), ShpCabinConsts.CabinNoMaxLength, 0);
            Ship = ship;
            CabinCategory = cabinCategory;
            CabinNo = cabinNo;
            CabinNoNumeric = cabinNoNumeric;
            BedLayout = bedLayout;
            StandardCapacity = standardCapacity;
            MaxCapacity = maxCapacity;
            Portohole = portohole;
            Window = window;
            CabinArea = cabinArea;
            Balcon = balcon;
            BalconArea = balconArea;
            IsDisabled = isDisabled;
        }
    }
}