using System.Collections.Generic;
using ConfigurationModules.ServiceLayer.Models;

namespace ConfigurationModules.ServiceLayer.Services
{
    /// <summary>
    /// Сервис конфигурации
    /// </summary>
    public interface IConfigurationService
    {
        /// <summary>
        /// Получить настройки приложения
        /// </summary>
        /// <param name="profileName">Имя профиля</param>
        /// <returns>Модель текущих настроек приложения</returns>
        ConfigSettingsDto GetApplicationSetting(string profileName);

        /// <summary>
        /// Сохранить профили
        /// </summary>
        /// <param name="profiles">Список профилей</param>
        void SaveProfiles(List<ConfigSettingsDto> profiles);

        /// <summary>
        /// Получить профили
        /// </summary>
        /// <returns>Список моделей профилей</returns>
        List<ConfigSettingsDto> GetProfiles();

        /// <summary>
        /// Удалить профиль
        /// </summary>
        /// <param name="profile"></param>
        void DeleteProfile(ConfigSettingsDto profile);
    }
}
