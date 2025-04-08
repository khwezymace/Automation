﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWebShop.Test.WebAbstraction
{
    public interface IHomePageObjects
    {
        void UserClicksComputersTab();
        void UserSelectsDesktopOption();
        void ValidateLandingpageTitle(string expectedTitle);

    }
}
