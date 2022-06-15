using System.Reflection;
using Autofac;
using AutoMapper;
using ConfigurationModules.BusinessLogicLayer.Services;
using ConfigurationModules.DataAccessLayer.Repositories;
using ConfigurationModules.DomainLayer.Repositories;
using ConfigurationModules.ServiceLayer.Services;
using Module = Autofac.Module;

namespace ConfigurationModules
{
    public class InjectModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(r =>
            {
                return new Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.AddMaps(Assembly.GetExecutingAssembly());
                }));
            }).As<IMapper>();

            builder.RegisterType<ConfigurationRepository>().As<IConfigurationRepository>();
            builder.RegisterType<ConfigurationService>().As<IConfigurationService>();
        }
    }
}
