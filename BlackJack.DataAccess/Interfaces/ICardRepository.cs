using BlackJack.DataAccess.Entities;

namespace BlackJack.DataAccess.Interfaces
{
    public interface ICardRepository : IRepository<Card>
    {
        Card GetCardOfRoundPlayerCard(int roundPlayerCard);
    }
}
