using Autofac;
using BlackJack.DataAccess.EF;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.DataAccess
{
    public class DataAccessModule : Module
    {
        private readonly string _connectionString;

        public DataAccessModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(type => type.Namespace == "BlackJack.DataAccess.Repositories")
                .AsImplementedInterfaces();

            builder.Register(context => new GameContext(_connectionString)).As<DbContext>();
        }
    }
}
