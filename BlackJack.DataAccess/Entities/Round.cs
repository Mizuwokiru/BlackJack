﻿using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJack.DataAccess.Entities
{
    public class Round : IIdentifiable
    {
        public int Id { get; set; }

        public Game Game { get; set; }

        public int PlayerForeignKey { get; set; }

        [ForeignKey("PlayerForeignKey")]
        public Player Player { get; set; }

        public int Index { get; set; }
    }
}
