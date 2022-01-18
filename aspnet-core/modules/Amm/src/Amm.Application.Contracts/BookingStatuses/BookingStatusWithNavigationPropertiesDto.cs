using Amm.MasterDatas;

using System;
using Volo.Abp.Application.Dtos;

namespace Amm.BookingStatuses
{
    public class BookingStatusWithNavigationPropertiesDto
    {
        public BookingStatusDto BookingStatus { get; set; }

        public MasterDataDto MasterData { get; set; }

    }
}