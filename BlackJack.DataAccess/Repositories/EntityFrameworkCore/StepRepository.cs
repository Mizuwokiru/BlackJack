using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using System.Data.Common;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class StepRepository : BaseRepository<Step>, IStepRepository
    {
        public StepRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
