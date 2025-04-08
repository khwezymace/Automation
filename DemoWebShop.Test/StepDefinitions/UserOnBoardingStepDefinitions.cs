using DemoWebShop.Test.WebAbstraction;
using System;
using TechTalk.SpecFlow;

namespace DemoWebShop.Test.StepDefinitions
{
    [Binding]
    public class UserOnBoardingStepDefinitions(ILoginPageObjects iloginPageObjects,IDesktopPageObjects idesktopPageObjects, IHomePageObjects ihomePageObjects)
    {
        ILoginPageObjects _iloginPageObjects = iloginPageObjects;
        IHomePageObjects _ihomePageObjects = ihomePageObjects;
        IDesktopPageObjects _idesktopPageObjects = idesktopPageObjects;  

        [Given(@"the user navigates to the site")]
        public void GivenTheUserNavigatesToTheSite()
        {
            _iloginPageObjects.NavigateToSiteUrl();
        }

        [When(@"the user clicks on the register tab")]
        public void WhenTheUserClicksOnTheRegisterTab()
        {
            _iloginPageObjects.Click_RegisterTab();
        }

        [When(@"the user enters registration details")]
        public void WhenTheUserEntersRegistrationDetails()
        {
            _iloginPageObjects.CreateUserRegistration();
            
        }
        [Then(@"the user clicks on the register button")]
        public void ThenTheUserClicksOnTheRegisterButton()
        {
            _iloginPageObjects.Click_RegisterButton();

        }

        [When(@"the user clicks on the login tab")]
        public void WhenTheUserClicksOnTheLoginTab()
        {
            _iloginPageObjects.Click_LoginTab();
            
        }

        [When(@"the user enters login details")]
        public void WhenTheUserEntersLoginDetails()
        {
            _iloginPageObjects.UserEntersLoginDetails();
        }

        [When(@"the user clicks on the login button")]
        public void WhenTheUserClicksOnTheLoginButton()
        {
            _iloginPageObjects.Click_LoginButton();
        }

        [Then(@"the user should be successfully logged in")]
        public void ThenTheUserShouldBeSuccessfullyLoggedIn()
        {
            _iloginPageObjects.VerifyUserLogged();
        }
        [When(@"the user clicks on the computers tab")]
        public void WhenTheUserClicksOnTheComputersTab()
        {
            _ihomePageObjects.UserClicksComputersTab();
        }


        [When(@"the user clicks on the desktop option from the dropdown\.")]
        public void WhenTheUserClicksOnTheDesktopOptionFromTheDropdown_()
        {
            _ihomePageObjects.UserSelectsDesktopOption();
        }

        [Then(@"the user should be redirected to the deskstop option page\.")]
        public void ThenTheUserShouldBeRedirectedToTheDeskstopOptionPage_()
        {
            _ihomePageObjects.ValidateLandingpageTitle("Demo Web Shop. Desktops");
        }
        [When(@"the user selects the sortBy dropdown using all options")]
        public void WhenTheUserSelectsTheSortByDropdownUsingAllOptions()
        {
            _idesktopPageObjects.UserSortByProductsDropdownUsingAllOptions();
        }

        [Then(@"the desktop products should be orderby the given options\.")]
        public void ThenTheDesktopProductsShouldBeOrderbyTheGivenOptions_()
        {
            throw new PendingStepException();
        }



    }
}
