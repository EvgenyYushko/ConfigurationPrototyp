using System.Reflection;
using Autofac;
using AutoMapper;
using Module = Autofac.Module;

namespace ConfigurationPrototyp
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

            builder.RegisterType<AppCustomForm>().AsSelf();
            builder.RegisterModule<ConfigurationModules.InjectModule>();
        }
    }
}
