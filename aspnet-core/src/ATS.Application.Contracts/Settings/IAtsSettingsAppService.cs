using ATS.Settings.Dto;
using System;
using System.Threading.Tasks;

namespace ATS.Settings
{
    public interface IAtsSettingsAppService
    {
        Task<UserProfileSettingDto> GetUserProfileSetting(Guid userId);
        Task UpdateUserProfileSettings(Guid userId, UserProfileSettingDto settings);
    }
}
