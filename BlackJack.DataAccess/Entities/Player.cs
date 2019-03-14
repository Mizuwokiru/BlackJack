﻿using System.ComponentModel.DataAnnotations;

namespace BlackJack.DataAccess.Entities
{
    public class Player : BaseEntity
    {
        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        public bool IsBot { get; set; }
    }
}
