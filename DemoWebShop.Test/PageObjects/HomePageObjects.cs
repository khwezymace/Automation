using BoDi;
using DemoWebShop.Test.WebAbstraction;
using NUnit.Framework;
using UIAutomation.Core.Abstration;
using UIAutomation.Core.Base;

namespace DemoWebShop.Test.PageObjects
{
    public class HomePageObjects(IObjectContainer objectContainer,IAtConfiguration iatConfiguration, IDrivers idrivers): TestBase(objectContainer), IHomePageObjects
    {
        IDrivers _idrivers = idrivers;
        IAtConfiguration _iatConfiguration = iatConfiguration;

        IAtBy ByComputersTab => GetBy(LocatorType.Xpath, "/html/body/div[4]/div[1]/div[2]/ul[1]/li[2]/a");
        IAtWebElement ComputersTab => _idrivers.FindElement(ByComputersTab);

        IAtBy ByDesktopOption => GetBy(LocatorType.Xpath, "//img[@title='Show products in category Desktops']");
        IAtWebElement DeskTopOption => _idrivers.FindElement(ByDesktopOption);

        public void UserClicksComputersTab()
        {
            ComputersTab.Click_EventHandler();
            Thread.Sleep(1000); 
        }
        public void UserSelectsDesktopOption()
        {
            DeskTopOption.Click_EventHandler();
            Thread.Sleep(1000); 
        }
        public void ValidateLandingpageTitle(string expectedTitle)
        {
            string actualTitle = _idrivers.GetPageTitleWithExpectedValue(expectedTitle);
            Assert.AreEqual(expectedTitle, actualTitle);
            Thread.Sleep(5000);
        }

    }
}
