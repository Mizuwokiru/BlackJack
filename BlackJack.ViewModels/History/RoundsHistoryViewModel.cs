﻿using BlackJack.Shared.Enums;
using System.Collections.Generic;

namespace BlackJack.ViewModels.History
{
    public class RoundsHistoryViewModel
    {
        public IEnumerable<RoundPlayerState> PlayerStates { get; set; }
    }
}
