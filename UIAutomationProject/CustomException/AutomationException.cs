﻿namespace UIAutomation.Core.CustomException
{
    public class AutomationException : Exception
    {

        public AutomationException(string message) : base(message) { }

        public AutomationException(ErrorItems errorItems) : base($"{errorItems}") { }

        public AutomationException(ErrorItems errorItems, string message) : base($"{errorItems} : {message}")
        {
        }

    }
}
