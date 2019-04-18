﻿using BlackJack.ViewModels.Models.Game;
using System.Collections.Generic;

namespace BlackJack.Services.Services.Interfaces
{
    public interface IGameService
    {
        bool HasUnfinishedGame();
        void NewGame(int neededBotCount);
        RoundInfoViewModel GetRoundsInfo();
        void Step();
        void EndRound();
        void NextRound();
        void EndGame();
    }
}
