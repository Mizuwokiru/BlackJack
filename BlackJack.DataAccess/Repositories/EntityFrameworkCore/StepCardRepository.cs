using System.Data.Common;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class StepCardRepository : BaseRepository<StepCard>, IStepCardRepository
    {
        public StepCardRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
