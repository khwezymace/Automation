using OpenQA.Selenium;

namespace UIAutomation.Core.Abstration
{
    public interface IDrivers
    {
        IWebDriver GetWebDriver();
        IAtWebElement FindElement(IAtBy atBy);
        void CloseBrowser();
        void NavigateTo(string url);
        string GetPageTitle();
        void GetNewTab();
        void CloseCurrentBrowser();
        void SwitchToWindowWithHandle(string handle);
        void SwitchToWindowWithTitle(string title);
        void SwitchToFrameWithTheName(string frameName);
        void Maximize();
        void ExecuteJavaScript(string script);
        void ScrollToWithPixel();
        void ScrollToTheTopPage();
        void ScrollToByHeight();
        void ScrollIntoView(IAtWebElement iatWebElement);
        string GetScreenShot();
        string GetPageTitleWithExpectedValue(string titleExpectValue);
        void SelectDropdownList(IAtWebElement iatWebElement, string text);
        void SelectStoreChoice(IAtWebElement iatWebElement);


    }
}
