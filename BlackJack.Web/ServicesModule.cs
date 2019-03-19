using Autofac;
using BlackJack.BusinessLogic.Services;
using System.Reflection;

namespace BlackJack.Web
{
    public class ServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("BlackJack.BusinessLogic"))
                .Where(type => type.Name != nameof(BaseService) && type.Namespace.Equals("BlackJack.BusinessLogic.Services"))
                .AsImplementedInterfaces();
        }
    }
}
