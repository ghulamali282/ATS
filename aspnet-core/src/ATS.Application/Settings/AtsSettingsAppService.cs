using ATS.Settings.Dto;
using System;
using System.Threading.Tasks;
using Volo.Abp.SettingManagement;

namespace ATS.Settings
{
    public class AtsSettingsAppService : ATSAppService
    {
        private readonly ISettingManager _settingManager;

        public AtsSettingsAppService(ISettingManager settingManager)
        {
            _settingManager = settingManager; ;
        }

        public async Task<UserProfileSettingDto> GetUserProfileSetting(Guid userId)
        {
            return new UserProfileSettingDto
            {
                WorkingYear = await _settingManager.GetOrNullForUserAsync(ATSSettings.WorkingYear, userId)
            };
        }

        public async Task UpdateUserProfileSettings(Guid userId, UserProfileSettingDto settings)
        {
            await _settingManager.SetForUserAsync(userId, ATSSettings.WorkingYear, settings.WorkingYear, forceToSet: true);
        }

    }
}
