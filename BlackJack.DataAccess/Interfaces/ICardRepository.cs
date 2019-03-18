using BlackJack.DataAccess.Entities;

namespace BlackJack.DataAccess.Interfaces
{
    public interface ICardRepository
    {
        Card GetCardOfRoundPlayerCard(int roundPlayerCard);
    }
}
