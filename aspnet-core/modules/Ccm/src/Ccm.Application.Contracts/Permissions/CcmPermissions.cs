using Volo.Abp.Reflection;

namespace Ccm.Permissions
{
    public class CcmPermissions
    {
        public const string GroupName = "Ccm";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(CcmPermissions));
        }

        public class MasterDatas
        {
            public const string Default = GroupName + ".MasterDatas";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Countries
        {
            public const string Default = GroupName + ".Countries";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Partners
        {
            public const string Default = GroupName + ".Partners";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class DepartureSeasons
        {
            public const string Default = GroupName + ".DepartureSeasons";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Departures
        {
            public const string Default = GroupName + ".Departures";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class AgePolicies
        {
            public const string Default = GroupName + ".AgePolicies";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class AgePolicyDetails
        {
            public const string Default = GroupName + ".AgePolicyDetails";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Companies
        {
            public const string Default = GroupName + ".Companies";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Itineraries
        {
            public const string Default = GroupName + ".Itineraries";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class ItineraryDetails
        {
            public const string Default = GroupName + ".ItineraryDetails";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Cruises
        {
            public const string Default = GroupName + ".Cruises";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class CharterShips
        {
            public const string Default = GroupName + ".CharterShips";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Destinations
        {
            public const string Default = GroupName + ".Destinations";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class CancellationPolicies
        {
            public const string Default = GroupName + ".CancellationPolicies";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class PaymentPolicies
        {
            public const string Default = GroupName + ".PaymentPolicies";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Ships
        {
            public const string Default = GroupName + ".Ships";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}