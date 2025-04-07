using BoDi;
using DemoWebShop.Test.WebAbstraction;
using UIAutomation.Core.Abstration;
using UIAutomation.Core.Base;

namespace DemoWebShop.Test.PageObjects
{
    public class LoginPageObjects(IDrivers idrivers, IObjectContainer objectContainer, IAtConfiguration iatConfiguration) : TestBase(objectContainer), ILoginPageObjects
    {
        IDrivers _idrivers = idrivers;
        IAtConfiguration _iatConfiguration = iatConfiguration;
        public void NavigateToSiteUrl()
        {
            _idrivers.NavigateTo(_iatConfiguration.GetConfiguration("SiteUrl"));
            Thread.Sleep(1000);
        }
    }
}

