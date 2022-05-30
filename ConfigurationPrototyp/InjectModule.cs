using Autofac;
using Module = Autofac.Module;

namespace ConfigurationPrototyp
{
    public class InjectModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppCustomForm>().AsSelf();
            builder.RegisterModule<ConfigurationModules.InjectModule>();
        }
    }
}
