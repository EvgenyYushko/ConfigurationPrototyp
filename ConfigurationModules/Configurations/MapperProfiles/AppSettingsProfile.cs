using AutoMapper;
using ConfigurationModules.DomainLayer.Models.Base;
using ConfigurationModules.ServiceLayer.Models;
using ConfigurationModules.ServiceLayer.Models.Base;
using Profile = ConfigurationModules.DomainLayer.Models.Profiles.Profile;

namespace ConfigurationModules.Configurations.MapperProfiles
{
    public class AppSettingsProfile : AutoMapper.Profile
    {
        public AppSettingsProfile()
        {
            CreateMap<Config, ConfigBaseDto>().ReverseMap();
            CreateMap<Profile, ConfigSettingsDto>().ReverseMap();
            CreateMap<Config, ConfigSettingsDto>()
                .ForMember(x => x.Config, y => y.MapFrom(source => source));
        }
    }
}
