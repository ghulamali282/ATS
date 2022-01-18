using Volo.Abp.Reflection;

namespace Amm.Permissions
{
    public class AmmPermissions
    {
        public const string GroupName = "Amm";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(AmmPermissions));
        }

        public class AppDefaults
        {
            public const string Default = GroupName + ".AppDefaults";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class BookingStatuses
        {
            public const string Default = GroupName + ".BookingStatuses";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class CruiseRegions
        {
            public const string Default = GroupName + ".CruiseRegions";
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

        public class MasterDatas
        {
            public const string Default = GroupName + ".MasterDatas";
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

        public class Partners
        {
            public const string Default = GroupName + ".Partners";
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

        public class ShipDecks
        {
            public const string Default = GroupName + ".ShipDecks";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class ShipCabinTypes
        {
            public const string Default = GroupName + ".ShipCabinTypes";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class ShpCabins
        {
            public const string Default = GroupName + ".ShpCabins";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class ShipOperators
        {
            public const string Default = GroupName + ".ShipOperators";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Marinas
        {
            public const string Default = GroupName + ".Marinas";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}