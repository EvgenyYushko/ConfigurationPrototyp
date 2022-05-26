using Autofac;
using ConfigurationModules.BusinessLogicLayer.Services;
using ConfigurationModules.DataAccessLayer.Repositories;
using ConfigurationModules.DomainLayer.Repositories;
using ConfigurationModules.ServiceLayer.Services;

namespace ConfigurationModules
{
    public class InjectModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConfigurationRepository>().As<IConfigurationRepository>();
            builder.RegisterType<ConfigurationService>().As<IConfigurationService>();
        }
    }
}
