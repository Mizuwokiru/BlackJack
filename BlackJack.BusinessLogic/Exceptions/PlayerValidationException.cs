using System;

namespace BlackJack.BusinessLogic.Exceptions
{
    public class PlayerValidationException : Exception
    {
        public PlayerValidationException(string message) : base(message)
        {
        }
    }
}
