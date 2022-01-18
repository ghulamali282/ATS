using Amm.Marinas;
using Amm.ShipOperators;
using Amm.Ships;
using Amm.Partners;
using Amm.Destinations;
using Amm.ShipCabinTypes;
using Amm.ShipDecks;
using Amm.ShpCabins;
using Amm.MasterDatas;
using Amm.Countries;
using Amm.CruiseRegions;
using Amm.BookingStatuses;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Amm.AppDefaults;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Amm.EntityFrameworkCore
{
    public static class AmmDbContextModelCreatingExtensions
    {
        public static void ConfigureAmm(
            this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(AmmDbProperties.DbTablePrefix + "Questions", AmmDbProperties.DbSchema);

                b.ConfigureByConvention();

                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */
            if (builder.IsHostDatabase())
            {
                builder.Entity<AppDefault>(b =>
    {
        b.ToTable(AmmDbProperties.DbTablePrefix + "AppDefaults", AmmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.SettingsName).HasColumnName(nameof(AppDefault.SettingsName)).IsRequired().HasMaxLength(AppDefaultConsts.SettingsNameMaxLength);
        b.Property(x => x.SettingsValue).HasColumnName(nameof(AppDefault.SettingsValue)).IsRequired().HasMaxLength(AppDefaultConsts.SettingsValueMaxLength);
    });

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {
                builder.Entity<CruiseRegion>(b =>
    {
        b.ToTable(AmmDbProperties.DbTablePrefix + "CruiseRegions", AmmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.FreeEntry).HasColumnName(nameof(CruiseRegion.FreeEntry));
    });

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {

            }

            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {
                builder.Entity<BookingStatus>(b =>
    {
        b.ToTable(AmmDbProperties.DbTablePrefix + "BookingStatuses", AmmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.StatusColor).HasColumnName(nameof(BookingStatus.StatusColor)).IsRequired();
        b.HasOne<MasterData>().WithMany().IsRequired().HasForeignKey(x => x.BookingStatusName);
    });

            }
            if (builder.IsHostDatabase())
            {
                builder.Entity<MasterData>(b =>
    {
        b.ToTable(AmmDbProperties.DbTablePrefix + "MasterData", AmmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.ParentId).HasColumnName(nameof(MasterData.ParentId));
        b.Property(x => x.Name).HasColumnName(nameof(MasterData.Name)).IsRequired().HasMaxLength(MasterDataConsts.NameMaxLength);
        b.Property(x => x.SortOrder).HasColumnName(nameof(MasterData.SortOrder)).IsRequired();
    });

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {
                builder.Entity<ShipDeck>(b =>
    {
        b.ToTable(AmmDbProperties.DbTablePrefix + "ShpDecks", AmmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.ShipDeckNameTEMP).HasColumnName(nameof(ShipDeck.ShipDeckNameTEMP)).IsRequired();
        b.Property(x => x.SortOrder).HasColumnName(nameof(ShipDeck.SortOrder)).IsRequired();
        b.Property(x => x.Ship).HasColumnName(nameof(ShipDeck.Ship)).IsRequired();
        b.HasOne<MasterData>().WithMany().IsRequired().HasForeignKey(x => x.Deck);
    });

            }
            if (builder.IsHostDatabase())
            {
                builder.Entity<ShipCabinType>(b =>
    {
        b.ToTable(AmmDbProperties.DbTablePrefix + "ShpCabinTypes", AmmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.Ship).HasColumnName(nameof(ShipCabinType.Ship)).IsRequired();
        b.Property(x => x.SortOrder).HasColumnName(nameof(ShipCabinType.SortOrder)).IsRequired();
        b.HasOne<MasterData>().WithMany().IsRequired().HasForeignKey(x => x.CabinCategory);
        b.HasOne<ShipDeck>().WithMany().IsRequired().HasForeignKey(x => x.Deck);
        b.HasOne<MasterData>().WithMany().IsRequired().HasForeignKey(x => x.DeckLocation);
        b.HasOne<MasterData>().WithMany().HasForeignKey(x => x.DeckPosition);
    });

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {
                builder.Entity<ShpCabin>(b =>
    {
        b.ToTable(AmmDbProperties.DbTablePrefix + "ShpCabins", AmmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.Ship).HasColumnName(nameof(ShpCabin.Ship)).IsRequired();
        b.Property(x => x.CabinCategory).HasColumnName(nameof(ShpCabin.CabinCategory)).IsRequired();
        b.Property(x => x.CabinNo).HasColumnName(nameof(ShpCabin.CabinNo)).IsRequired().HasMaxLength(ShpCabinConsts.CabinNoMaxLength);
        b.Property(x => x.CabinNoNumeric).HasColumnName(nameof(ShpCabin.CabinNoNumeric)).IsRequired();
        b.Property(x => x.BedLayout).HasColumnName(nameof(ShpCabin.BedLayout)).IsRequired();
        b.Property(x => x.StandardCapacity).HasColumnName(nameof(ShpCabin.StandardCapacity)).IsRequired();
        b.Property(x => x.MaxCapacity).HasColumnName(nameof(ShpCabin.MaxCapacity)).IsRequired();
        b.Property(x => x.Portohole).HasColumnName(nameof(ShpCabin.Portohole)).IsRequired();
        b.Property(x => x.Window).HasColumnName(nameof(ShpCabin.Window)).IsRequired();
        b.Property(x => x.CabinArea).HasColumnName(nameof(ShpCabin.CabinArea)).IsRequired();
        b.Property(x => x.Balcon).HasColumnName(nameof(ShpCabin.Balcon)).IsRequired();
        b.Property(x => x.BalconArea).HasColumnName(nameof(ShpCabin.BalconArea)).IsRequired();
        b.Property(x => x.IsDisabled).HasColumnName(nameof(ShpCabin.IsDisabled)).IsRequired();
    });

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {
                builder.Entity<Country>(b =>
    {
        b.ToTable(AmmDbProperties.DbTablePrefix + "Countries", AmmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.CountryName).HasColumnName(nameof(Country.CountryName)).IsRequired();
        b.Property(x => x.CultureName).HasColumnName(nameof(Country.CultureName)).IsRequired().HasMaxLength(CountryConsts.CultureNameMaxLength);
        b.Property(x => x.Currency).HasColumnName(nameof(Country.Currency)).IsRequired().HasMaxLength(CountryConsts.CurrencyMaxLength);
        b.Property(x => x.CurrencyCode).HasColumnName(nameof(Country.CurrencyCode)).IsRequired().HasMaxLength(CountryConsts.CurrencyCodeMaxLength);
        b.Property(x => x.CurrencySymbol).HasColumnName(nameof(Country.CurrencySymbol)).IsRequired().HasMaxLength(CountryConsts.CurrencySymbolMaxLength);
        b.Property(x => x.LanguageName).HasColumnName(nameof(Country.LanguageName)).IsRequired().HasMaxLength(CountryConsts.LanguageNameMaxLength);
        b.Property(x => x.PlaceId).HasColumnName(nameof(Country.PlaceId)).HasMaxLength(CountryConsts.PlaceIdMaxLength);
    });

            }
            if (builder.IsHostDatabase())
            {
                builder.Entity<Destination>(b =>
    {
        b.ToTable(AmmDbProperties.DbTablePrefix + "Destinations", AmmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.City).HasColumnName(nameof(Destination.City)).IsRequired().HasMaxLength(DestinationConsts.CityMaxLength);
        b.Property(x => x.CityLocalName).HasColumnName(nameof(Destination.CityLocalName)).IsRequired().HasMaxLength(DestinationConsts.CityLocalNameMaxLength);
        b.Property(x => x.latitude).HasColumnName(nameof(Destination.latitude)).IsRequired();
        b.Property(x => x.longitude).HasColumnName(nameof(Destination.longitude)).IsRequired();
        b.Property(x => x.VideoUrl).HasColumnName(nameof(Destination.VideoUrl)).HasMaxLength(DestinationConsts.VideoUrlMaxLength);
        b.Property(x => x.PlaceId).HasColumnName(nameof(Destination.PlaceId)).IsRequired().HasMaxLength(DestinationConsts.PlaceIdMaxLength);
        b.HasOne<Country>().WithMany().IsRequired().HasForeignKey(x => x.DestCountry);
    });

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {
                builder.Entity<ShipOperator>(b =>
    {
        b.ToTable(AmmDbProperties.DbTablePrefix + "ShipOperators", AmmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.OperatorName).HasColumnName(nameof(ShipOperator.OperatorName)).IsRequired().HasMaxLength(ShipOperatorConsts.OperatorNameMaxLength);
    });

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {
                builder.Entity<Ship>(b =>
    {
        b.ToTable(AmmDbProperties.DbTablePrefix + "Ships", AmmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.ShipName).HasColumnName(nameof(Ship.ShipName)).IsRequired().HasMaxLength(ShipConsts.ShipNameMaxLength);
        b.Property(x => x.YearBuild).HasColumnName(nameof(Ship.YearBuild)).IsRequired();
        b.Property(x => x.YearRefurbished).HasColumnName(nameof(Ship.YearRefurbished));
        b.Property(x => x.EnsuitedCabins).HasColumnName(nameof(Ship.EnsuitedCabins)).IsRequired();
        b.Property(x => x.SharedToilets).HasColumnName(nameof(Ship.SharedToilets));
        b.Property(x => x.SharedShowers).HasColumnName(nameof(Ship.SharedShowers));
        b.Property(x => x.CrewNo).HasColumnName(nameof(Ship.CrewNo)).IsRequired();
        b.Property(x => x.Lenght).HasColumnName(nameof(Ship.Lenght)).IsRequired();
        b.Property(x => x.Beam).HasColumnName(nameof(Ship.Beam)).IsRequired();
        b.Property(x => x.Draft).HasColumnName(nameof(Ship.Draft)).IsRequired();
        b.Property(x => x.CruiseSpeed).HasColumnName(nameof(Ship.CruiseSpeed)).IsRequired();
        b.Property(x => x.MaxSpeed).HasColumnName(nameof(Ship.MaxSpeed)).IsRequired();
        b.Property(x => x.VideoUrl).HasColumnName(nameof(Ship.VideoUrl)).HasMaxLength(ShipConsts.VideoUrlMaxLength);
        b.Property(x => x.UseCabinDeckPosition).HasColumnName(nameof(Ship.UseCabinDeckPosition)).IsRequired();
        b.Property(x => x.UseDeckLocation).HasColumnName(nameof(Ship.UseDeckLocation)).IsRequired();
        b.Property(x => x.ShipEnabled).HasColumnName(nameof(Ship.ShipEnabled));
        b.HasOne<Destination>().WithMany().IsRequired().HasForeignKey(x => x.HomePort);
        b.HasOne<Country>().WithMany().IsRequired().HasForeignKey(x => x.Flag);
        b.HasOne<MasterData>().WithMany().IsRequired().HasForeignKey(x => x.ShipCategory);
        b.HasOne<ShipOperator>().WithMany().HasForeignKey(x => x.ShipOperator);
    });

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {
                builder.Entity<Marina>(b =>
    {
        b.ToTable(AmmDbProperties.DbTablePrefix + "Marinas", AmmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.MarinaNameString).HasColumnName(nameof(Marina.MarinaNameString)).HasMaxLength(MarinaConsts.MarinaNameStringMaxLength);
        b.Property(x => x.Latitude).HasColumnName(nameof(Marina.Latitude)).IsRequired().HasMaxLength(MarinaConsts.LatitudeMaxLength);
        b.Property(x => x.Longitude).HasColumnName(nameof(Marina.Longitude)).IsRequired().HasMaxLength(MarinaConsts.LongitudeMaxLength);
        b.HasOne<MasterData>().WithMany().IsRequired().HasForeignKey(x => x.MarinaName);
        b.HasOne<Destination>().WithMany().IsRequired().HasForeignKey(x => x.Destination);
    });

            }
        }
    }
}