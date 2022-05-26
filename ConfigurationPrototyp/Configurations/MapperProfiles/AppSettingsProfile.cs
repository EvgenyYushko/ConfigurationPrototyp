using AutoMapper;
using ConfigurationModules.DomainLayer.Models.Base;
using ConfigurationModules.ServiceLayer.Models;

namespace ConfigurationPrototyp.Configurations.MapperProfiles
{
    public class AppSettingsProfile : Profile
    {
        public AppSettingsProfile()
        {
            CreateMap<ApplicationConfigSettings, ConfigSettingsDto>().ReverseMap();
        }
    }
}
