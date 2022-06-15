using System.Collections.Generic;
using ConfigurationModules.DomainLayer.Models.Base;
using ConfigurationModules.DomainLayer.Models.Profiles;

namespace ConfigurationModules.DomainLayer.Repositories
{
    /// <summary>
    /// Репозиторий конфигурации
    /// </summary>
    public interface IConfigurationRepository
    {
        /// <summary>
        /// Получить дефолтные настройки приложения
        /// </summary>
        /// <returns>Дефолтная модель настроек приложения</returns>
        Config GetDefaultApplicationSettings();

        /// <summary>
        /// Получить профиль по имения
        /// </summary>
        /// <param name="profileName">Имя профиля</param>
        /// <returns>Модель настроек профиля</returns>
        Profile GetProfile(string profileName);

        /// <summary>
        /// Получить все профили
        /// </summary>
        /// <returns>Модель настроек профилей</returns>
        List<Profile> GetProfiles();

        /// <summary>
        /// Добавить профиль
        /// </summary>
        /// <param name="newProfile">Имя добавляемого профиля</param>
        void AddProfile(Profile newProfile);

        /// <summary>
        /// Удалить профиль
        /// </summary>
        /// <param name="newProfile">Имя удаляемого профиля</param>
        void DeleteProfile(string newProfile);

        /// <summary>
        /// Сохранить текущее состояние настроек профилей
        /// </summary>
        void Save();
    }
}
