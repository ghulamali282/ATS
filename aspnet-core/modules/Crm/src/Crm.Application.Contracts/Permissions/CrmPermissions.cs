using Volo.Abp.Reflection;

namespace Crm.Permissions
{
    public class CrmPermissions
    {
        public const string GroupName = "Crm";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(CrmPermissions));
        }

        public class Contracts
        {
            public const string Default = GroupName + ".Contracts";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Clients
        {
            public const string Default = GroupName + ".Clients";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Passengers
        {
            public const string Default = GroupName + ".Passengers";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}