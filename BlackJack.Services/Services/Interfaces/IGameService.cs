﻿using BlackJack.ViewModels.Models;
using System.Collections.Generic;

namespace BlackJack.Services.Services.Interfaces
{
    public interface IGameService
    {
        bool HasUnfinishedGame();
        void NewGame(int botCount);
        List<RoundViewModel> GetRoundsInfo();
        void Step();
        void EndRound();
        void NextRound();
        void EndGame();
    }
}