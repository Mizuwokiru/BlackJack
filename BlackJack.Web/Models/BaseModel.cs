using System;

namespace BlackJack.Web.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
