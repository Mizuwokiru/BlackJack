using System;

namespace BlackJack.BusinessLogic.Models
{
    public class GameModel : BaseModel
    {
        public DateTime CreationTime { get; set; }

        public int UserId { get; set; }
    }
}
