using BlackJack.DataAccess.Interfaces;

namespace BlackJack.BusinessLogic.Services
{
    public abstract class BaseService
    {
        protected IDbWorker _dbWorker;

        public BaseService(IDbWorker dbWorker)
        {
            _dbWorker = dbWorker;
        }
    }
}
