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

        IAtBy ByRegisterTab => GetBy(LocatorType.Xpath, "//a[@class='ico-register']");
        IAtWebElement RegisterTab => _idrivers.FindElement(ByRegisterTab);
        IAtBy ByGender => GetBy(LocatorType.Xpath, "//input[@id='gender-female']");
        IAtWebElement GenderRadioButton => _idrivers.FindElement(ByGender);
        IAtBy ByFirstName => GetBy(LocatorType.Xpath, "//input[@id='FirstName']");
        IAtWebElement FirstNameTxt => _idrivers.FindElement(ByFirstName);

        IAtBy ByLastName => GetBy(LocatorType.Xpath, "//input[@id='LastName']");
        IAtWebElement LastNameTxt => _idrivers.FindElement(ByLastName);
        IAtBy ByEmailAddress => GetBy(LocatorType.Xpath, "//input[@id='Email']");
        IAtWebElement EmailAddressTxt => _idrivers.FindElement(ByEmailAddress);
        IAtBy ByPassword => GetBy(LocatorType.Xpath, "//input[@id='Password']");
        IAtWebElement PasswordTxt => _idrivers.FindElement(ByPassword);
        IAtBy ByPasswordConfirm => GetBy(LocatorType.Xpath, "//input[@id='ConfirmPassword']");
        IAtWebElement PasswordConfirmTxt => _idrivers.FindElement(ByPasswordConfirm);
        IAtBy ByRegisterButton => GetBy(LocatorType.Xpath, "//input[@id='register-button']");
        IAtWebElement RegisterButton => _idrivers.FindElement(ByRegisterButton);

        public void NavigateToSiteUrl()
        {
            _idrivers.NavigateTo(_iatConfiguration.GetConfiguration("SiteUrl"));
        }

        public void Click_RegisterTab()
        {
            RegisterTab.Click_EventHandler();
            Thread.Sleep(1000); 
        }
        public void CreateUserRegistration()
        {
            GenderRadioButton.Click_EventHandler();
            FirstNameTxt.ClearText();
            FirstNameTxt.SendKeys(_iatConfiguration.GetConfiguration("FirstName"));
            LastNameTxt.ClearText();
            LastNameTxt.SendKeys(_iatConfiguration.GetConfiguration("LastName"));
            EmailAddressTxt.ClearText();
            EmailAddressTxt.SendKeys(_iatConfiguration.GetConfiguration("EmailAddress"));
            PasswordTxt.ClearText();
            PasswordTxt.SendKeys(_iatConfiguration.GetConfiguration("Password"));
            PasswordConfirmTxt.ClearText();
            PasswordConfirmTxt.SendKeys(_iatConfiguration.GetConfiguration("ConfirmPassword"));
            Thread.Sleep(1000);

        }
        public void Click_RegisterButton()
        {
            RegisterButton.Click_EventHandler();
            Thread.Sleep(1000);
        }
    }
}

