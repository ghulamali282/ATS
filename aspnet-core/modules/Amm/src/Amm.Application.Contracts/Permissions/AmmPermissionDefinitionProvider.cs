using Amm.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Amm.Permissions
{
    public class AmmPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AmmPermissions.GroupName, L("Permission:Amm"));

            var appDefaultPermission = myGroup.AddPermission(AmmPermissions.AppDefaults.Default, L("Permission:AppDefaults"));
            appDefaultPermission.AddChild(AmmPermissions.AppDefaults.Create, L("Permission:Create"));
            appDefaultPermission.AddChild(AmmPermissions.AppDefaults.Edit, L("Permission:Edit"));
            appDefaultPermission.AddChild(AmmPermissions.AppDefaults.Delete, L("Permission:Delete"));

            var bookingStatusPermission = myGroup.AddPermission(AmmPermissions.BookingStatuses.Default, L("Permission:BookingStatuses"));
            bookingStatusPermission.AddChild(AmmPermissions.BookingStatuses.Create, L("Permission:Create"));
            bookingStatusPermission.AddChild(AmmPermissions.BookingStatuses.Edit, L("Permission:Edit"));
            bookingStatusPermission.AddChild(AmmPermissions.BookingStatuses.Delete, L("Permission:Delete"));

            var cruiseRegionPermission = myGroup.AddPermission(AmmPermissions.CruiseRegions.Default, L("Permission:CruiseRegions"));
            cruiseRegionPermission.AddChild(AmmPermissions.CruiseRegions.Create, L("Permission:Create"));
            cruiseRegionPermission.AddChild(AmmPermissions.CruiseRegions.Edit, L("Permission:Edit"));
            cruiseRegionPermission.AddChild(AmmPermissions.CruiseRegions.Delete, L("Permission:Delete"));

            var countryPermission = myGroup.AddPermission(AmmPermissions.Countries.Default, L("Permission:Countries"));
            countryPermission.AddChild(AmmPermissions.Countries.Create, L("Permission:Create"));
            countryPermission.AddChild(AmmPermissions.Countries.Edit, L("Permission:Edit"));
            countryPermission.AddChild(AmmPermissions.Countries.Delete, L("Permission:Delete"));

            var masterDataPermission = myGroup.AddPermission(AmmPermissions.MasterDatas.Default, L("Permission:MasterDatas"));
            masterDataPermission.AddChild(AmmPermissions.MasterDatas.Create, L("Permission:Create"));
            masterDataPermission.AddChild(AmmPermissions.MasterDatas.Edit, L("Permission:Edit"));
            masterDataPermission.AddChild(AmmPermissions.MasterDatas.Delete, L("Permission:Delete"));

            var destinationPermission = myGroup.AddPermission(AmmPermissions.Destinations.Default, L("Permission:Destinations"));
            destinationPermission.AddChild(AmmPermissions.Destinations.Create, L("Permission:Create"));
            destinationPermission.AddChild(AmmPermissions.Destinations.Edit, L("Permission:Edit"));
            destinationPermission.AddChild(AmmPermissions.Destinations.Delete, L("Permission:Delete"));

            var partnerPermission = myGroup.AddPermission(AmmPermissions.Partners.Default, L("Permission:Partners"));
            partnerPermission.AddChild(AmmPermissions.Partners.Create, L("Permission:Create"));
            partnerPermission.AddChild(AmmPermissions.Partners.Edit, L("Permission:Edit"));
            partnerPermission.AddChild(AmmPermissions.Partners.Delete, L("Permission:Delete"));

            var shipPermission = myGroup.AddPermission(AmmPermissions.Ships.Default, L("Permission:Ships"));
            shipPermission.AddChild(AmmPermissions.Ships.Create, L("Permission:Create"));
            shipPermission.AddChild(AmmPermissions.Ships.Edit, L("Permission:Edit"));
            shipPermission.AddChild(AmmPermissions.Ships.Delete, L("Permission:Delete"));

            var shipDeckPermission = myGroup.AddPermission(AmmPermissions.ShipDecks.Default, L("Permission:ShipDecks"));
            shipDeckPermission.AddChild(AmmPermissions.ShipDecks.Create, L("Permission:Create"));
            shipDeckPermission.AddChild(AmmPermissions.ShipDecks.Edit, L("Permission:Edit"));
            shipDeckPermission.AddChild(AmmPermissions.ShipDecks.Delete, L("Permission:Delete"));

            var shipCabinTypePermission = myGroup.AddPermission(AmmPermissions.ShipCabinTypes.Default, L("Permission:ShipCabinTypes"));
            shipCabinTypePermission.AddChild(AmmPermissions.ShipCabinTypes.Create, L("Permission:Create"));
            shipCabinTypePermission.AddChild(AmmPermissions.ShipCabinTypes.Edit, L("Permission:Edit"));
            shipCabinTypePermission.AddChild(AmmPermissions.ShipCabinTypes.Delete, L("Permission:Delete"));

            var shpCabinPermission = myGroup.AddPermission(AmmPermissions.ShpCabins.Default, L("Permission:ShpCabins"));
            shpCabinPermission.AddChild(AmmPermissions.ShpCabins.Create, L("Permission:Create"));
            shpCabinPermission.AddChild(AmmPermissions.ShpCabins.Edit, L("Permission:Edit"));
            shpCabinPermission.AddChild(AmmPermissions.ShpCabins.Delete, L("Permission:Delete"));

            var shipOperatorPermission = myGroup.AddPermission(AmmPermissions.ShipOperators.Default, L("Permission:ShipOperators"));
            shipOperatorPermission.AddChild(AmmPermissions.ShipOperators.Create, L("Permission:Create"));
            shipOperatorPermission.AddChild(AmmPermissions.ShipOperators.Edit, L("Permission:Edit"));
            shipOperatorPermission.AddChild(AmmPermissions.ShipOperators.Delete, L("Permission:Delete"));

            var marinaPermission = myGroup.AddPermission(AmmPermissions.Marinas.Default, L("Permission:Marinas"));
            marinaPermission.AddChild(AmmPermissions.Marinas.Create, L("Permission:Create"));
            marinaPermission.AddChild(AmmPermissions.Marinas.Edit, L("Permission:Edit"));
            marinaPermission.AddChild(AmmPermissions.Marinas.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AmmResource>(name);
        }
    }
}