﻿using BlackJack.BusinessLogic.Models;
using System.Collections.Generic;

namespace BlackJack.Web.Models
{
    public class LoginViewModel
    {
        public string PlayerName { get; set; }

        public IEnumerable<PlayerViewModel> Players { get; set; }
    }
}
