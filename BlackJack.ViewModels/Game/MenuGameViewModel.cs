﻿using BlackJack.Shared.Helpers;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.ViewModels.Game
{
    public class MenuGameViewModel
    {
        public bool HasUnfinishedGame { get; set; }

        [Range(0, Constants.MaxBotCount)]
        public int BotCount { get; set; }
    }
}
