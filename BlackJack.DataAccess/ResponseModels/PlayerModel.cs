using BlackJack.Shared.Enums;

namespace BlackJack.DataAccess.ResponseModels
{
    public class PlayerModel
    {
        public string Name { get; set; }

        public PlayerType Type { get; set; }
    }
}
