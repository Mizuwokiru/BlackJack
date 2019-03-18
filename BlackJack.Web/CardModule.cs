using BlackJack.BusinessLogic.Interfaces;
using BlackJack.BusinessLogic.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.Web
{
    public class CardModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICardService>().To<CardService>();
        }
    }
}
