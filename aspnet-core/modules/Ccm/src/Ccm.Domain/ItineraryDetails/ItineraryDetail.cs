using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Ccm.ItineraryDetails
{
    public class ItineraryDetail : Entity<Guid>
    {
        public virtual Guid Itinerary { get; set; }

        public virtual Guid Name { get; set; }

        public virtual int Day { get; set; }

        [NotNull]
        public virtual string Ports { get; set; }

        [CanBeNull]
        public virtual string AlternativePorts { get; set; }

        public virtual bool WelcomeDrink { get; set; }

        public virtual bool WelcomeSnack { get; set; }

        public virtual bool Breakfast { get; set; }

        public virtual bool Brunch { get; set; }

        public virtual bool Lunch { get; set; }

        public virtual bool AfternoonSnack { get; set; }

        public virtual bool Dinner { get; set; }

        public virtual bool CaptainDinner { get; set; }

        public virtual bool LiveMusic { get; set; }

        public virtual bool WineTasting { get; set; }

        public virtual bool OvernightOnAnchor { get; set; }

        public virtual bool OvernightAtMarina { get; set; }

        public ItineraryDetail()
        {

        }

        public ItineraryDetail(Guid id, Guid itinerary, Guid name, int day, string ports, bool welcomeDrink, bool welcomeSnack, bool breakfast, bool brunch, bool lunch, bool afternoonSnack, bool dinner, bool captainDinner, bool liveMusic, bool wineTasting, bool overnightOnAnchor, bool overnightAtMarina, string alternativePorts = null)
        {
            Id = id;
            Check.NotNull(ports, nameof(ports));
            Check.Length(ports, nameof(ports), ItineraryDetailConsts.PortsMaxLength, 0);
            Check.Length(alternativePorts, nameof(alternativePorts), ItineraryDetailConsts.AlternativePortsMaxLength, 0);
            Itinerary = itinerary;
            Name = name;
            Day = day;
            Ports = ports;
            WelcomeDrink = welcomeDrink;
            WelcomeSnack = welcomeSnack;
            Breakfast = breakfast;
            Brunch = brunch;
            Lunch = lunch;
            AfternoonSnack = afternoonSnack;
            Dinner = dinner;
            CaptainDinner = captainDinner;
            LiveMusic = liveMusic;
            WineTasting = wineTasting;
            OvernightOnAnchor = overnightOnAnchor;
            OvernightAtMarina = overnightAtMarina;
            AlternativePorts = alternativePorts;
        }
    }
}