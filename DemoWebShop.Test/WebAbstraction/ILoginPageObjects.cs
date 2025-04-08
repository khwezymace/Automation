namespace DemoWebShop.Test.WebAbstraction
{
    public interface ILoginPageObjects
    {
        void NavigateToSiteUrl();
        void Click_RegisterTab();
        void CreateUserRegistration();
        void Click_RegisterButton();
        void Click_LoginTab();
        void UserEntersLoginDetails();
        void Click_LoginButton();
        void VerifyUserLogged();

    }
}

