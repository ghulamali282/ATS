using Crm.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Crm.Permissions
{
    public class CrmPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(CrmPermissions.GroupName, L("Permission:Crm"));

            var contractPermission = myGroup.AddPermission(CrmPermissions.Contracts.Default, L("Permission:Contracts"));
            contractPermission.AddChild(CrmPermissions.Contracts.Create, L("Permission:Create"));
            contractPermission.AddChild(CrmPermissions.Contracts.Edit, L("Permission:Edit"));
            contractPermission.AddChild(CrmPermissions.Contracts.Delete, L("Permission:Delete"));

            var clientPermission = myGroup.AddPermission(CrmPermissions.Clients.Default, L("Permission:Clients"));
            clientPermission.AddChild(CrmPermissions.Clients.Create, L("Permission:Create"));
            clientPermission.AddChild(CrmPermissions.Clients.Edit, L("Permission:Edit"));
            clientPermission.AddChild(CrmPermissions.Clients.Delete, L("Permission:Delete"));

            var passengerPermission = myGroup.AddPermission(CrmPermissions.Passengers.Default, L("Permission:Passengers"));
            passengerPermission.AddChild(CrmPermissions.Passengers.Create, L("Permission:Create"));
            passengerPermission.AddChild(CrmPermissions.Passengers.Edit, L("Permission:Edit"));
            passengerPermission.AddChild(CrmPermissions.Passengers.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CrmResource>(name);
        }
    }
}