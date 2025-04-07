using DemoWebShop.Test.WebAbstraction;
using System;
using TechTalk.SpecFlow;

namespace DemoWebShop.Test.StepDefinitions
{
    [Binding]
    public class UserOnBoardingStepDefinitions(ILoginPageObjects iloginPageObjects)
    {
        ILoginPageObjects _iloginPageObjects = iloginPageObjects;

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

        [When(@"the user clicks on the register button")]
        public void WhenTheUserClicksOnTheRegisterButton()
        {
            _iloginPageObjects.Click_RegisterButton();  
            
        }

        [Then(@"the user should be successfully registered\.")]
        public void ThenTheUserShouldBeSuccessfullyRegistered_()
        {
            
        }

        [When(@"the user clicks on the login tab")]
        public void WhenTheUserClicksOnTheLoginTab()
        {
            
        }

        [When(@"the user enters login details")]
        public void WhenTheUserEntersLoginDetails()
        {
            
        }

        [When(@"the user clicks on the login button")]
        public void WhenTheUserClicksOnTheLoginButton()
        {
            
        }

        [Then(@"the user should be successfully logged in")]
        public void ThenTheUserShouldBeSuccessfullyLoggedIn()
        {
            
        }
    }
}
