﻿using System;

namespace BlackJack.BusinessLogic.Exceptions
{
    public class ValidationException : Exception
    {
        public string Property { get; protected set; }

        public ValidationException(string message, string property) : base(message)
        {
            Property = property;
        }
    }
}
