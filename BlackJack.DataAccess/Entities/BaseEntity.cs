using System;

namespace BlackJack.DataAccess.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public BaseEntity()
        {
            CreationDate = DateTime.Now;
        }
    }
}
