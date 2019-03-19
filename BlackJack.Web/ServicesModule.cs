using Autofac;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.BusinessLogic.Services;
using BlackJack.DataAccess.Interfaces;
using System.Reflection;

namespace BlackJack.Web
{
    public class ServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<CardService>().As<ICardService>();
            builder.RegisterAssemblyTypes(Assembly.Load("BlackJack.BusinessLogic"))
                .AsImplementedInterfaces();
        }
    }
}
