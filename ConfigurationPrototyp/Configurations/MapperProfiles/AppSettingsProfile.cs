using AutoMapper;
using ConfigurationModules.DomainLayer.Models.Base;
using ConfigurationModules.ServiceLayer.Models;
using ConfigurationModules.ServiceLayer.Models.Base;

namespace ConfigurationPrototyp.Configurations.MapperProfiles
{
    public class AppSettingsProfile : Profile
    {
        public AppSettingsProfile()
        {
            CreateMap<Config, ConfigBaseDto>().ReverseMap();
            CreateMap<ApplicationConfigSettings, ConfigSettingsDto>().ReverseMap();
            CreateMap<Config, ConfigSettingsDto>()
                .ForMember(x => x.Config, y => y.MapFrom(source => source));
        }
    }
}
