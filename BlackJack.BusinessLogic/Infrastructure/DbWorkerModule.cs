using Autofac;
using BlackJack.DataAccess;
using BlackJack.DataAccess.Interfaces;

namespace BlackJack.BusinessLogic.Infrastructure
{
    public class DbWorkerModule : Module
    {
        private string _connectionString;

        public DbWorkerModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(worker => new DbWorker(_connectionString)).As<IDbWorker>();
        }
    }
}
