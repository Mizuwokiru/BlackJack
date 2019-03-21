using BlackJack.DataAccess.Entities;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface ICardRepository : IRepository<Card>
    {
        Card GetCardOfRoundPlayerCard(int roundPlayerCard);
    }
}
