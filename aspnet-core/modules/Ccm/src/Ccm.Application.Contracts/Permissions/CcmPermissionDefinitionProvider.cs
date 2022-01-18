using Ccm.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Ccm.Permissions
{
    public class CcmPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(CcmPermissions.GroupName, L("Permission:Ccm"));

            var masterDataPermission = myGroup.AddPermission(CcmPermissions.MasterDatas.Default, L("Permission:MasterDatas"));
            masterDataPermission.AddChild(CcmPermissions.MasterDatas.Create, L("Permission:Create"), MultiTenancySides.Host);
            masterDataPermission.AddChild(CcmPermissions.MasterDatas.Edit, L("Permission:Edit"));
            masterDataPermission.AddChild(CcmPermissions.MasterDatas.Delete, L("Permission:Delete"));

            var countryPermission = myGroup.AddPermission(CcmPermissions.Countries.Default, L("Permission:Countries"));
            countryPermission.AddChild(CcmPermissions.Countries.Create, L("Permission:Create"));
            countryPermission.AddChild(CcmPermissions.Countries.Edit, L("Permission:Edit"));
            countryPermission.AddChild(CcmPermissions.Countries.Delete, L("Permission:Delete"));

            var partnerPermission = myGroup.AddPermission(CcmPermissions.Partners.Default, L("Permission:Partners"));
            partnerPermission.AddChild(CcmPermissions.Partners.Create, L("Permission:Create"));
            partnerPermission.AddChild(CcmPermissions.Partners.Edit, L("Permission:Edit"));
            partnerPermission.AddChild(CcmPermissions.Partners.Delete, L("Permission:Delete"));

            var departureSeasonPermission = myGroup.AddPermission(CcmPermissions.DepartureSeasons.Default, L("Permission:DepartureSeasons"));
            departureSeasonPermission.AddChild(CcmPermissions.DepartureSeasons.Create, L("Permission:Create"));
            departureSeasonPermission.AddChild(CcmPermissions.DepartureSeasons.Edit, L("Permission:Edit"));
            departureSeasonPermission.AddChild(CcmPermissions.DepartureSeasons.Delete, L("Permission:Delete"));

            var departurePermission = myGroup.AddPermission(CcmPermissions.Departures.Default, L("Permission:Departures"));
            departurePermission.AddChild(CcmPermissions.Departures.Create, L("Permission:Create"));
            departurePermission.AddChild(CcmPermissions.Departures.Edit, L("Permission:Edit"));
            departurePermission.AddChild(CcmPermissions.Departures.Delete, L("Permission:Delete"));

            var agePolicyPermission = myGroup.AddPermission(CcmPermissions.AgePolicies.Default, L("Permission:AgePolicies"));
            agePolicyPermission.AddChild(CcmPermissions.AgePolicies.Create, L("Permission:Create"));
            agePolicyPermission.AddChild(CcmPermissions.AgePolicies.Edit, L("Permission:Edit"));
            agePolicyPermission.AddChild(CcmPermissions.AgePolicies.Delete, L("Permission:Delete"));

            var agePolicyDetailPermission = myGroup.AddPermission(CcmPermissions.AgePolicyDetails.Default, L("Permission:AgePolicyDetails"));
            agePolicyDetailPermission.AddChild(CcmPermissions.AgePolicyDetails.Create, L("Permission:Create"));
            agePolicyDetailPermission.AddChild(CcmPermissions.AgePolicyDetails.Edit, L("Permission:Edit"));
            agePolicyDetailPermission.AddChild(CcmPermissions.AgePolicyDetails.Delete, L("Permission:Delete"));

            var companyPermission = myGroup.AddPermission(CcmPermissions.Companies.Default, L("Permission:Companies"));
            companyPermission.AddChild(CcmPermissions.Companies.Create, L("Permission:Create"));
            companyPermission.AddChild(CcmPermissions.Companies.Edit, L("Permission:Edit"));
            companyPermission.AddChild(CcmPermissions.Companies.Delete, L("Permission:Delete"));

            var itineraryPermission = myGroup.AddPermission(CcmPermissions.Itineraries.Default, L("Permission:Itineraries"));
            itineraryPermission.AddChild(CcmPermissions.Itineraries.Create, L("Permission:Create"));
            itineraryPermission.AddChild(CcmPermissions.Itineraries.Edit, L("Permission:Edit"));
            itineraryPermission.AddChild(CcmPermissions.Itineraries.Delete, L("Permission:Delete"));

            var itineraryDetailPermission = myGroup.AddPermission(CcmPermissions.ItineraryDetails.Default, L("Permission:ItineraryDetails"));
            itineraryDetailPermission.AddChild(CcmPermissions.ItineraryDetails.Create, L("Permission:Create"));
            itineraryDetailPermission.AddChild(CcmPermissions.ItineraryDetails.Edit, L("Permission:Edit"));
            itineraryDetailPermission.AddChild(CcmPermissions.ItineraryDetails.Delete, L("Permission:Delete"));

            var cruisePermission = myGroup.AddPermission(CcmPermissions.Cruises.Default, L("Permission:Cruises"));
            cruisePermission.AddChild(CcmPermissions.Cruises.Create, L("Permission:Create"));
            cruisePermission.AddChild(CcmPermissions.Cruises.Edit, L("Permission:Edit"));
            cruisePermission.AddChild(CcmPermissions.Cruises.Delete, L("Permission:Delete"));

            var charterShipPermission = myGroup.AddPermission(CcmPermissions.CharterShips.Default, L("Permission:CharterShips"));
            charterShipPermission.AddChild(CcmPermissions.CharterShips.Create, L("Permission:Create"));
            charterShipPermission.AddChild(CcmPermissions.CharterShips.Edit, L("Permission:Edit"));
            charterShipPermission.AddChild(CcmPermissions.CharterShips.Delete, L("Permission:Delete"));

            var destinationPermission = myGroup.AddPermission(CcmPermissions.Destinations.Default, L("Permission:Destinations"));
            destinationPermission.AddChild(CcmPermissions.Destinations.Create, L("Permission:Create"));
            destinationPermission.AddChild(CcmPermissions.Destinations.Edit, L("Permission:Edit"));
            destinationPermission.AddChild(CcmPermissions.Destinations.Delete, L("Permission:Delete"));

            var cancellationPolicyPermission = myGroup.AddPermission(CcmPermissions.CancellationPolicies.Default, L("Permission:CancellationPolicies"));
            cancellationPolicyPermission.AddChild(CcmPermissions.CancellationPolicies.Create, L("Permission:Create"));
            cancellationPolicyPermission.AddChild(CcmPermissions.CancellationPolicies.Edit, L("Permission:Edit"));
            cancellationPolicyPermission.AddChild(CcmPermissions.CancellationPolicies.Delete, L("Permission:Delete"));

            var paymentPolicyPermission = myGroup.AddPermission(CcmPermissions.PaymentPolicies.Default, L("Permission:PaymentPolicies"));
            paymentPolicyPermission.AddChild(CcmPermissions.PaymentPolicies.Create, L("Permission:Create"));
            paymentPolicyPermission.AddChild(CcmPermissions.PaymentPolicies.Edit, L("Permission:Edit"));
            paymentPolicyPermission.AddChild(CcmPermissions.PaymentPolicies.Delete, L("Permission:Delete"));

            var shipPermission = myGroup.AddPermission(CcmPermissions.Ships.Default, L("Permission:Ships"));
            shipPermission.AddChild(CcmPermissions.Ships.Create, L("Permission:Create"));
            shipPermission.AddChild(CcmPermissions.Ships.Edit, L("Permission:Edit"));
            shipPermission.AddChild(CcmPermissions.Ships.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CcmResource>(name);
        }
    }
}