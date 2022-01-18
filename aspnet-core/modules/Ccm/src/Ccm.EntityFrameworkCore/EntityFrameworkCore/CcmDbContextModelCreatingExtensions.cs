using Ccm.Ships;
using Ccm.PaymentPolicies;
using Ccm.CancellationPolicies;
using Ccm.Destinations;
using Ccm.CharterShips;
using Ccm.Cruises;
using Ccm.ItineraryDetails;
using Ccm.Itineraries;
using Ccm.Companies;
using Ccm.Countries;
using Ccm.AgePolicyDetails;
using Ccm.AgePolicies;
using Ccm.Departures;
using Ccm.DepartureSeasons;
using Ccm.Partners;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Ccm.MasterDatas;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Ccm.EntityFrameworkCore
{
    public static class CcmDbContextModelCreatingExtensions
    {
        public static void ConfigureCcm(
            this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(CcmDbProperties.DbTablePrefix + "Questions", CcmDbProperties.DbSchema);

                b.ConfigureByConvention();

                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */
            builder.Entity<MasterData>(b =>
    {
        b.ToTable(CcmDbProperties.DbTablePrefix + "MasterData", CcmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(MasterData.TenantId));
        b.Property(x => x.ParentId).HasColumnName(nameof(MasterData.ParentId));
        b.Property(x => x.Name).HasColumnName(nameof(MasterData.Name)).IsRequired().HasMaxLength(MasterDataConsts.NameMaxLength);
        b.Property(x => x.Value).HasColumnName(nameof(MasterData.Value));
        b.Property(x => x.InlineValue).HasColumnName(nameof(MasterData.InlineValue));
        b.Property(x => x.VisibleToTenant).HasColumnName(nameof(MasterData.VisibleToTenant));
        b.Property(x => x.IsSection).HasColumnName(nameof(MasterData.IsSection));
        b.Property(x => x.IsRadio).HasColumnName(nameof(MasterData.IsRadio));
        b.Property(x => x.IsExportable).HasColumnName(nameof(MasterData.IsExportable));
        b.Property(x => x.Icon).HasColumnName(nameof(MasterData.Icon)).HasMaxLength(MasterDataConsts.IconMaxLength);
        b.Property(x => x.CultureName).HasColumnName(nameof(MasterData.CultureName)).IsRequired().HasMaxLength(MasterDataConsts.CultureNameMaxLength);
        b.Property(x => x.SortOrder).HasColumnName(nameof(MasterData.SortOrder)).IsRequired();
    });
            if (builder.IsHostDatabase())
            {

            }

            if (builder.IsHostDatabase())
            {

            }

            builder.Entity<Departure>(b =>
    {
        b.ToTable(CcmDbProperties.DbTablePrefix + "Departures", CcmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(Departure.TenantId));
        b.Property(x => x.DeparturesArray).HasColumnName(nameof(Departure.DeparturesArray)).IsRequired();
        b.Property(x => x.SeasonGroup).HasColumnName(nameof(Departure.SeasonGroup)).IsRequired().HasMaxLength(DepartureConsts.SeasonGroupMaxLength);
        b.HasOne<Partner>().WithMany().IsRequired().HasForeignKey(x => x.Partner);
        b.HasOne<DepartureSeason>().WithMany().IsRequired().HasForeignKey(x => x.SeasonName);
    });

            builder.Entity<AgePolicyDetail>(b =>
    {
        b.ToTable(CcmDbProperties.DbTablePrefix + "AgePolicyDetails", CcmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(AgePolicyDetail.TenantId));
        b.Property(x => x.AgeFrom).HasColumnName(nameof(AgePolicyDetail.AgeFrom)).IsRequired();
        b.Property(x => x.AgePolicy).HasColumnName(nameof(AgePolicyDetail.AgePolicy)).IsRequired();
        b.Property(x => x.AgeTo).HasColumnName(nameof(AgePolicyDetail.AgeTo)).IsRequired();
        b.HasOne<MasterData>().WithMany().IsRequired().HasForeignKey(x => x.Service);
    });

            builder.Entity<Country>(b =>
    {
        b.ToTable(CcmDbProperties.DbTablePrefix + "CountryList", CcmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(Country.TenantId));
        b.Property(x => x.CountryName).HasColumnName(nameof(Country.CountryName)).IsRequired().HasMaxLength(CountryConsts.CountryNameMaxLength);
        b.Property(x => x.CultureName).HasColumnName(nameof(Country.CultureName)).IsRequired().HasMaxLength(CountryConsts.CultureNameMaxLength);
    });

            builder.Entity<Partner>(b =>
    {
        b.ToTable(CcmDbProperties.DbTablePrefix + "Partners", CcmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(Partner.TenantId));
        b.Property(x => x.PartnerName).HasColumnName(nameof(Partner.PartnerName)).IsRequired().HasMaxLength(PartnerConsts.PartnerNameMaxLength);
        b.Property(x => x.Address).HasColumnName(nameof(Partner.Address)).IsRequired();
        b.Property(x => x.TaxNo).HasColumnName(nameof(Partner.TaxNo)).IsRequired().HasMaxLength(PartnerConsts.TaxNoMaxLength);
        b.Property(x => x.BookingEmail).HasColumnName(nameof(Partner.BookingEmail)).IsRequired().HasMaxLength(PartnerConsts.BookingEmailMaxLength);
        b.Property(x => x.BookingCellPhone).HasColumnName(nameof(Partner.BookingCellPhone)).IsRequired().HasMaxLength(PartnerConsts.BookingCellPhoneMaxLength);
        b.Property(x => x.BookingEmailConfirmed).HasColumnName(nameof(Partner.BookingEmailConfirmed));
        b.Property(x => x.BookingPhoneConfirmed).HasColumnName(nameof(Partner.BookingPhoneConfirmed));
        b.Property(x => x.Email).HasColumnName(nameof(Partner.Email)).HasMaxLength(PartnerConsts.EmailMaxLength);
        b.Property(x => x.Phone).HasColumnName(nameof(Partner.Phone)).HasMaxLength(PartnerConsts.PhoneMaxLength);
        b.HasOne<Country>().WithMany().IsRequired().HasForeignKey(x => x.CountryName);
    });

            builder.Entity<DepartureSeason>(b =>
    {
        b.ToTable(CcmDbProperties.DbTablePrefix + "DepartureSeasons", CcmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(DepartureSeason.TenantId));
        b.Property(x => x.Season).HasColumnName(nameof(DepartureSeason.Season)).IsRequired();
        b.Property(x => x.SeasonName).HasColumnName(nameof(DepartureSeason.SeasonName)).IsRequired();
        b.HasOne<Partner>().WithMany().IsRequired().HasForeignKey(x => x.Partner);
    });
            builder.Entity<AgePolicy>(b =>
    {
        b.ToTable(CcmDbProperties.DbTablePrefix + "AgePolicies", CcmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(AgePolicy.TenantId));
        b.Property(x => x.DemoField).HasColumnName(nameof(AgePolicy.DemoField));
        b.HasOne<MasterData>().WithMany().IsRequired().HasForeignKey(x => x.Name);
        b.HasOne<Partner>().WithMany().IsRequired().HasForeignKey(x => x.OperatorName);
    });
            builder.Entity<Company>(b =>
    {
        b.ToTable(CcmDbProperties.DbTablePrefix + "Company", CcmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(Company.TenantId));
        b.Property(x => x.LegalName).HasColumnName(nameof(Company.LegalName)).IsRequired().HasMaxLength(CompanyConsts.LegalNameMaxLength);
        b.Property(x => x.CompanyCode).HasColumnName(nameof(Company.CompanyCode)).IsRequired().HasMaxLength(CompanyConsts.CompanyCodeMaxLength);
        b.Property(x => x.Street).HasColumnName(nameof(Company.Street)).IsRequired().HasMaxLength(CompanyConsts.StreetMaxLength);
        b.Property(x => x.StreetNumber).HasColumnName(nameof(Company.StreetNumber)).IsRequired().HasMaxLength(CompanyConsts.StreetNumberMaxLength);
        b.Property(x => x.ZipCode).HasColumnName(nameof(Company.ZipCode)).IsRequired().HasMaxLength(CompanyConsts.ZipCodeMaxLength);
        b.Property(x => x.City).HasColumnName(nameof(Company.City)).IsRequired().HasMaxLength(CompanyConsts.CityMaxLength);
        b.Property(x => x.StateRegion).HasColumnName(nameof(Company.StateRegion)).HasMaxLength(CompanyConsts.StateRegionMaxLength);
        b.Property(x => x.Country).HasColumnName(nameof(Company.Country)).IsRequired().HasMaxLength(CompanyConsts.CountryMaxLength);
        b.Property(x => x.InEU).HasColumnName(nameof(Company.InEU));
        b.Property(x => x.TaxNo).HasColumnName(nameof(Company.TaxNo)).IsRequired().HasMaxLength(CompanyConsts.TaxNoMaxLength);
        b.Property(x => x.TravelAgencyCode).HasColumnName(nameof(Company.TravelAgencyCode)).HasMaxLength(CompanyConsts.TravelAgencyCodeMaxLength);
        b.Property(x => x.InvoicePrefix).HasColumnName(nameof(Company.InvoicePrefix)).HasMaxLength(CompanyConsts.InvoicePrefixMaxLength);
        b.Property(x => x.InvoiceLegal1).HasColumnName(nameof(Company.InvoiceLegal1));
        b.Property(x => x.InvoiceLegal2).HasColumnName(nameof(Company.InvoiceLegal2));
        b.Property(x => x.PaymentInfo).HasColumnName(nameof(Company.PaymentInfo));
        b.Property(x => x.WebSite).HasColumnName(nameof(Company.WebSite)).HasMaxLength(CompanyConsts.WebSiteMaxLength);
        b.Property(x => x.CompanyEmail).HasColumnName(nameof(Company.CompanyEmail)).IsRequired().HasMaxLength(CompanyConsts.CompanyEmailMaxLength);
        b.Property(x => x.Telephone).HasColumnName(nameof(Company.Telephone)).HasMaxLength(CompanyConsts.TelephoneMaxLength);
        b.Property(x => x.Fax).HasColumnName(nameof(Company.Fax)).HasMaxLength(CompanyConsts.FaxMaxLength);
        b.Property(x => x.FacebookPage).HasColumnName(nameof(Company.FacebookPage)).HasMaxLength(CompanyConsts.FacebookPageMaxLength);
        b.Property(x => x.TwiterPage).HasColumnName(nameof(Company.TwiterPage)).HasMaxLength(CompanyConsts.TwiterPageMaxLength);
        b.Property(x => x.Instagram).HasColumnName(nameof(Company.Instagram)).HasMaxLength(CompanyConsts.InstagramMaxLength);
        b.Property(x => x.CeoName).HasColumnName(nameof(Company.CeoName)).HasMaxLength(CompanyConsts.CeoNameMaxLength);
        b.Property(x => x.CeoEmail).HasColumnName(nameof(Company.CeoEmail)).HasMaxLength(CompanyConsts.CeoEmailMaxLength);
        b.Property(x => x.BookingEmail).HasColumnName(nameof(Company.BookingEmail)).IsRequired();
        b.Property(x => x.BookingEmailConfirmed).HasColumnName(nameof(Company.BookingEmailConfirmed)).IsRequired();
        b.Property(x => x.BookingCellPhone).HasColumnName(nameof(Company.BookingCellPhone)).IsRequired();
        b.Property(x => x.BookingPhoneConfirmed).HasColumnName(nameof(Company.BookingPhoneConfirmed));
        b.Property(x => x.WorkingYear).HasColumnName(nameof(Company.WorkingYear));
        b.Property(x => x.TenantCurrency).HasColumnName(nameof(Company.TenantCurrency)).HasMaxLength(CompanyConsts.TenantCurrencyMaxLength);
        b.Property(x => x.RoundingAfterExchange).HasColumnName(nameof(Company.RoundingAfterExchange));
        b.Property(x => x.DefaultCruiseDeposit).HasColumnName(nameof(Company.DefaultCruiseDeposit)).IsRequired();
        b.Property(x => x.DefaultCharterDeposit).HasColumnName(nameof(Company.DefaultCharterDeposit)).IsRequired();
        b.Property(x => x.DefaultCruiseDepositType).HasColumnName(nameof(Company.DefaultCruiseDepositType)).IsRequired().HasMaxLength(CompanyConsts.DefaultCruiseDepositTypeMaxLength);
        b.Property(x => x.DefautCharterDepositType).HasColumnName(nameof(Company.DefautCharterDepositType)).IsRequired().HasMaxLength(CompanyConsts.DefautCharterDepositTypeMaxLength);
        b.Property(x => x.RequestDurationCruise).HasColumnName(nameof(Company.RequestDurationCruise)).IsRequired();
        b.Property(x => x.RequestDurationCharter).HasColumnName(nameof(Company.RequestDurationCharter)).IsRequired();
        b.Property(x => x.OptionDurationCruise).HasColumnName(nameof(Company.OptionDurationCruise));
        b.Property(x => x.OptionDurationCharter).HasColumnName(nameof(Company.OptionDurationCharter)).IsRequired();
        b.Property(x => x.CruiseFinalPaymentDueDays).HasColumnName(nameof(Company.CruiseFinalPaymentDueDays));
        b.Property(x => x.CharterFinalPaymentDueDays).HasColumnName(nameof(Company.CharterFinalPaymentDueDays)).IsRequired();
        b.Property(x => x.CruiseFullPaymentRequiredDays).HasColumnName(nameof(Company.CruiseFullPaymentRequiredDays)).IsRequired();
        b.Property(x => x.CharterFullPaymentRequiredDays).HasColumnName(nameof(Company.CharterFullPaymentRequiredDays));
    });

            if (builder.IsHostDatabase())
            {
                builder.Entity<ItineraryDetail>(b =>
    {
        b.ToTable(CcmDbProperties.DbTablePrefix + "ItineraryDetails", CcmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.Itinerary).HasColumnName(nameof(ItineraryDetail.Itinerary)).IsRequired();
        b.Property(x => x.Name).HasColumnName(nameof(ItineraryDetail.Name)).IsRequired();
        b.Property(x => x.Day).HasColumnName(nameof(ItineraryDetail.Day)).IsRequired();
        b.Property(x => x.Ports).HasColumnName(nameof(ItineraryDetail.Ports)).IsRequired().HasMaxLength(ItineraryDetailConsts.PortsMaxLength);
        b.Property(x => x.AlternativePorts).HasColumnName(nameof(ItineraryDetail.AlternativePorts)).HasMaxLength(ItineraryDetailConsts.AlternativePortsMaxLength);
        b.Property(x => x.WelcomeDrink).HasColumnName(nameof(ItineraryDetail.WelcomeDrink)).IsRequired();
        b.Property(x => x.WelcomeSnack).HasColumnName(nameof(ItineraryDetail.WelcomeSnack)).IsRequired();
        b.Property(x => x.Breakfast).HasColumnName(nameof(ItineraryDetail.Breakfast)).IsRequired();
        b.Property(x => x.Brunch).HasColumnName(nameof(ItineraryDetail.Brunch)).IsRequired();
        b.Property(x => x.Lunch).HasColumnName(nameof(ItineraryDetail.Lunch)).IsRequired();
        b.Property(x => x.AfternoonSnack).HasColumnName(nameof(ItineraryDetail.AfternoonSnack)).IsRequired();
        b.Property(x => x.Dinner).HasColumnName(nameof(ItineraryDetail.Dinner)).IsRequired();
        b.Property(x => x.CaptainDinner).HasColumnName(nameof(ItineraryDetail.CaptainDinner)).IsRequired();
        b.Property(x => x.LiveMusic).HasColumnName(nameof(ItineraryDetail.LiveMusic)).IsRequired();
        b.Property(x => x.WineTasting).HasColumnName(nameof(ItineraryDetail.WineTasting)).IsRequired();
        b.Property(x => x.OvernightOnAnchor).HasColumnName(nameof(ItineraryDetail.OvernightOnAnchor)).IsRequired();
        b.Property(x => x.OvernightAtMarina).HasColumnName(nameof(ItineraryDetail.OvernightAtMarina)).IsRequired();
    });

            }

            builder.Entity<CharterShip>(b =>
    {
        b.ToTable(CcmDbProperties.DbTablePrefix + "CharterShips", CcmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(CharterShip.TenantId));
        b.Property(x => x.OperatorName).HasColumnName(nameof(CharterShip.OperatorName)).IsRequired();
        b.Property(x => x.Season).HasColumnName(nameof(CharterShip.Season)).IsRequired();
        b.Property(x => x.ShipNamePrefix).HasColumnName(nameof(CharterShip.ShipNamePrefix));
        b.Property(x => x.Ship).HasColumnName(nameof(CharterShip.Ship)).IsRequired();
        b.Property(x => x.Itinerary).HasColumnName(nameof(CharterShip.Itinerary)).IsRequired();
        b.Property(x => x.Tabs).HasColumnName(nameof(CharterShip.Tabs)).IsRequired().HasMaxLength(CharterShipConsts.TabsMaxLength);
        b.Property(x => x.Video).HasColumnName(nameof(CharterShip.Video)).HasMaxLength(CharterShipConsts.VideoMaxLength);
        b.Property(x => x.Featured).HasColumnName(nameof(CharterShip.Featured)).IsRequired();
        b.Property(x => x.FreeInternetOnBoard).HasColumnName(nameof(CharterShip.FreeInternetOnBoard)).IsRequired();
        b.Property(x => x.Internet).HasColumnName(nameof(CharterShip.Internet)).IsRequired();
        b.Property(x => x.TransferIncluded).HasColumnName(nameof(CharterShip.TransferIncluded)).IsRequired();
        b.Property(x => x.EnabledByUser).HasColumnName(nameof(CharterShip.EnabledByUser)).IsRequired();
        b.Property(x => x.DisabledBySystem).HasColumnName(nameof(CharterShip.DisabledBySystem));
        b.Property(x => x.B2B).HasColumnName(nameof(CharterShip.B2B)).IsRequired();
        b.Property(x => x.B2C).HasColumnName(nameof(CharterShip.B2C)).IsRequired();
        b.Property(x => x.B2B_Agent).HasColumnName(nameof(CharterShip.B2B_Agent)).IsRequired();
        b.Property(x => x.B2C_Agent).HasColumnName(nameof(CharterShip.B2C_Agent)).IsRequired();
        b.Property(x => x.ShipAmenities).HasColumnName(nameof(CharterShip.ShipAmenities));
        b.Property(x => x.ShipArticles).HasColumnName(nameof(CharterShip.ShipArticles));
        b.Property(x => x.ShipPhotos).HasColumnName(nameof(CharterShip.ShipPhotos));
        b.Property(x => x.CabinAmenities).HasColumnName(nameof(CharterShip.CabinAmenities));
        b.Property(x => x.CabinArticles).HasColumnName(nameof(CharterShip.CabinArticles));
        b.Property(x => x.CabinPhotos).HasColumnName(nameof(CharterShip.CabinPhotos));
    });

            if (builder.IsHostDatabase())
            {

            }
            builder.Entity<CancellationPolicy>(b =>
    {
        b.ToTable(CcmDbProperties.DbTablePrefix + "CancellationPolicies", CcmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(CancellationPolicy.TenantId));
        b.Property(x => x.NameString).HasColumnName(nameof(CancellationPolicy.NameString)).IsRequired();
        b.HasOne<Partner>().WithMany().IsRequired().HasForeignKey(x => x.OperatorName);
        b.HasOne<MasterData>().WithMany().IsRequired().HasForeignKey(x => x.PolicyName);
    });

            builder.Entity<PaymentPolicy>(b =>
    {
        b.ToTable(CcmDbProperties.DbTablePrefix + "PaymentPolicies", CcmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(PaymentPolicy.TenantId));
        b.Property(x => x.DelayedDepositAt).HasColumnName(nameof(PaymentPolicy.DelayedDepositAt)).HasMaxLength(PaymentPolicyConsts.DelayedDepositAtMaxLength);
        b.Property(x => x.Deposit).HasColumnName(nameof(PaymentPolicy.Deposit)).IsRequired();
        b.Property(x => x.DepositAtReservation).HasColumnName(nameof(PaymentPolicy.DepositAtReservation)).IsRequired();
        b.Property(x => x.DepositType).HasColumnName(nameof(PaymentPolicy.DepositType)).IsRequired().HasMaxLength(PaymentPolicyConsts.DepositTypeMaxLength);
        b.Property(x => x.FinalPaymentDueDays).HasColumnName(nameof(PaymentPolicy.FinalPaymentDueDays)).IsRequired();
        b.Property(x => x.FullPaymentRequiredDays).HasColumnName(nameof(PaymentPolicy.FullPaymentRequiredDays)).IsRequired();
        b.Property(x => x.PolicyString).HasColumnName(nameof(PaymentPolicy.PolicyString)).IsRequired();
        b.HasOne<Partner>().WithMany().IsRequired().HasForeignKey(x => x.OperatorName);
        b.HasOne<MasterData>().WithMany().IsRequired().HasForeignKey(x => x.PolicyName);
    });

            builder.Entity<Destination>(b =>
    {
        b.ToTable(CcmDbProperties.DbTablePrefix + "Destinations", CcmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(Destination.TenantId));
        b.Property(x => x.City).HasColumnName(nameof(Destination.City)).IsRequired().HasMaxLength(DestinationConsts.CityMaxLength);
    });
            builder.Entity<Ship>(b =>
    {
        b.ToTable(CcmDbProperties.DbTablePrefix + "Ships", CcmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(Ship.TenantId));
        b.Property(x => x.ShipName).HasColumnName(nameof(Ship.ShipName)).IsRequired().HasMaxLength(ShipConsts.ShipNameMaxLength);
        b.Property(x => x.ShipCategory).HasColumnName(nameof(Ship.ShipCategory)).IsRequired();
        b.Property(x => x.ShipOperator).HasColumnName(nameof(Ship.ShipOperator));
        b.Property(x => x.Type).HasColumnName(nameof(Ship.Type));
        b.Property(x => x.Flag).HasColumnName(nameof(Ship.Flag)).IsRequired().HasMaxLength(ShipConsts.FlagMaxLength);
        b.Property(x => x.HomePort).HasColumnName(nameof(Ship.HomePort)).IsRequired();
        b.Property(x => x.Manufacturer).HasColumnName(nameof(Ship.Manufacturer));
        b.Property(x => x.Model).HasColumnName(nameof(Ship.Model));
        b.Property(x => x.YearBuild).HasColumnName(nameof(Ship.YearBuild)).IsRequired();
    });

            builder.Entity<Cruise>(b =>
    {
        b.ToTable(CcmDbProperties.DbTablePrefix + "Cruises", CcmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(Cruise.TenantId));
        b.Property(x => x.Season).HasColumnName(nameof(Cruise.Season)).IsRequired();
        b.Property(x => x.CruiseEnabled).HasColumnName(nameof(Cruise.CruiseEnabled)).IsRequired();
        b.Property(x => x.Featured).HasColumnName(nameof(Cruise.Featured)).IsRequired();
        b.Property(x => x.FreeInternetOnBoard).HasColumnName(nameof(Cruise.FreeInternetOnBoard)).IsRequired();
        b.Property(x => x.InternetOnBoard).HasColumnName(nameof(Cruise.InternetOnBoard)).IsRequired();
        b.Property(x => x.Video).HasColumnName(nameof(Cruise.Video)).HasMaxLength(CruiseConsts.VideoMaxLength);
        b.Property(x => x.B2B).HasColumnName(nameof(Cruise.B2B)).IsRequired();
        b.Property(x => x.B2C).HasColumnName(nameof(Cruise.B2C)).IsRequired();
        b.Property(x => x.B2B_Agent).HasColumnName(nameof(Cruise.B2B_Agent)).IsRequired();
        b.Property(x => x.B2C_Agent).HasColumnName(nameof(Cruise.B2C_Agent)).IsRequired();
        b.Property(x => x.CruiseDescriptions).HasColumnName(nameof(Cruise.CruiseDescriptions));
        b.Property(x => x.ShipAmenities).HasColumnName(nameof(Cruise.ShipAmenities));
        b.Property(x => x.ShipArticles).HasColumnName(nameof(Cruise.ShipArticles));
        b.Property(x => x.ShipPhotos).HasColumnName(nameof(Cruise.ShipPhotos));
        b.Property(x => x.CabinAmenities).HasColumnName(nameof(Cruise.CabinAmenities));
        b.Property(x => x.CabinArticles).HasColumnName(nameof(Cruise.CabinArticles));
        b.Property(x => x.CabinPhotos).HasColumnName(nameof(Cruise.CabinPhotos));
        b.HasOne<Ship>().WithMany().IsRequired().HasForeignKey(x => x.Ship);
        b.HasOne<Itinerary>().WithMany().IsRequired().HasForeignKey(x => x.Itinerary);
    });

            builder.Entity<Itinerary>(b =>
    {
        b.ToTable(CcmDbProperties.DbTablePrefix + "Itineraries", CcmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(Itinerary.TenantId));
        b.Property(x => x.ItineraryNameString).HasColumnName(nameof(Itinerary.ItineraryNameString)).IsRequired();
        b.Property(x => x.ItineraryCode).HasColumnName(nameof(Itinerary.ItineraryCode)).IsRequired().HasMaxLength(ItineraryConsts.ItineraryCodeMaxLength);
        b.Property(x => x.GoogleMapLink).HasColumnName(nameof(Itinerary.GoogleMapLink)).HasMaxLength(ItineraryConsts.GoogleMapLinkMaxLength);
        b.Property(x => x.Duration).HasColumnName(nameof(Itinerary.Duration)).IsRequired();
        b.Property(x => x.ExtendedItinerary).HasColumnName(nameof(Itinerary.ExtendedItinerary)).IsRequired();
        b.Property(x => x.Marina).HasColumnName(nameof(Itinerary.Marina));
        b.Property(x => x.EmbarcationLatitude).HasColumnName(nameof(Itinerary.EmbarcationLatitude)).IsRequired().HasMaxLength(ItineraryConsts.EmbarcationLatitudeMaxLength);
        b.Property(x => x.EmbarcationLongitude).HasColumnName(nameof(Itinerary.EmbarcationLongitude)).IsRequired().HasMaxLength(ItineraryConsts.EmbarcationLongitudeMaxLength);
        b.Property(x => x.DisembarkationLatitude).HasColumnName(nameof(Itinerary.DisembarkationLatitude)).IsRequired().HasMaxLength(ItineraryConsts.DisembarkationLatitudeMaxLength);
        b.Property(x => x.DisembarkationLongitude).HasColumnName(nameof(Itinerary.DisembarkationLongitude)).IsRequired().HasMaxLength(ItineraryConsts.DisembarkationLongitudeMaxLength);
        b.Property(x => x.CheckInTime).HasColumnName(nameof(Itinerary.CheckInTime)).IsRequired().HasMaxLength(ItineraryConsts.CheckInTimeMaxLength);
        b.Property(x => x.CheckOutTime).HasColumnName(nameof(Itinerary.CheckOutTime)).IsRequired().HasMaxLength(ItineraryConsts.CheckOutTimeMaxLength);
        b.Property(x => x.TransferIncluded).HasColumnName(nameof(Itinerary.TransferIncluded)).IsRequired();
        b.Property(x => x.Video).HasColumnName(nameof(Itinerary.Video)).HasMaxLength(ItineraryConsts.VideoMaxLength);
        b.Property(x => x.RequestDuration).HasColumnName(nameof(Itinerary.RequestDuration)).IsRequired();
        b.Property(x => x.OptionDuration).HasColumnName(nameof(Itinerary.OptionDuration)).IsRequired();
        b.HasOne<Partner>().WithMany().IsRequired().HasForeignKey(x => x.OperatorName);
        b.HasOne<MasterData>().WithMany().IsRequired().HasForeignKey(x => x.Themes);
        b.HasOne<MasterData>().WithMany().IsRequired().HasForeignKey(x => x.Boarding);
        b.HasOne<AgePolicy>().WithMany().IsRequired().HasForeignKey(x => x.AgePolicyId);
        b.HasOne<Destination>().WithMany().IsRequired().HasForeignKey(x => x.EmbarcationPort);
        b.HasOne<Destination>().WithMany().IsRequired().HasForeignKey(x => x.DisembarkationPort);
        b.HasOne<CancellationPolicy>().WithMany().IsRequired().HasForeignKey(x => x.CancellationPolicy);
        b.HasOne<PaymentPolicy>().WithMany().IsRequired().HasForeignKey(x => x.PaymentPolicy);
        b.HasOne<MasterData>().WithMany().IsRequired().HasForeignKey(x => x.ItineraryName);
    });
        }
    }
}