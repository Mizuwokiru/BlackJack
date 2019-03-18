using BlackJack.DataAccess;
using BlackJack.DataAccess.Interfaces;
using Ninject.Modules;

namespace BlackJack.BusinessLogic.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string _connectionString;

        public ServiceModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IDbWorker>().To<DbWorker>().WithConstructorArgument(_connectionString);
        }
    }
}
