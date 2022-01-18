using Amm.MasterDatas;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Amm.BookingStatuses
{
    public class BookingStatus : Entity<int>
    {
        [NotNull]
        public virtual string StatusColor { get; set; }
        public Guid BookingStatusName { get; set; }

        public BookingStatus()
        {

        }

        public BookingStatus(int id, string statusColor, Guid bookingStatusName)
        {
            Id = id;
            Check.NotNull(statusColor, nameof(statusColor));
            StatusColor = statusColor;
            BookingStatusName = bookingStatusName;
        }
    }
}