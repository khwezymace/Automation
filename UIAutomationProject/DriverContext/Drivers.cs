using BoDi;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using UIAutomation.Core.Abstration;
using UIAutomation.Core.Runner;

namespace UIAutomation.Core.DriverContext
{
    [Binding]
    public class Drivers(IChromeWebDriver ichromeWebDriver, IFirefoxWebDriver ifirefoxWebDriver, IObjectContainer iobjectContainer) : IDrivers
    {
        IGlobalProperties _iglobalProperties;
        readonly IChromeWebDriver _ichromeWebDriver = ichromeWebDriver;
        readonly IFirefoxWebDriver _foxWebDriver = ifirefoxWebDriver;
        readonly IObjectContainer _iobjectContainer = iobjectContainer;
        IWebDriver iwebdriver;

        public IWebDriver GetWebDriver()
        {
            if (iwebdriver == null)
            {
                GetNewWebDriver();
            }
            return iwebdriver;
        }
        public IAtWebElement FindElement(IAtBy atBy)
        {
            IAtWebElement iatWebElement = _iobjectContainer.Resolve<IAtWebElement>();
            iatWebElement.Set(GetWebDriver(), atBy);
            return iatWebElement;
        }
        public void GetNewWebDriver()
        {
            _iglobalProperties = SpecFlowRunner._iserviceProvider.GetRequiredService<IGlobalProperties>();
            switch (_iglobalProperties.browsertype.ToLower())
            {
                case "chrome":
                    iwebdriver = _ichromeWebDriver.GetChromeWebDriver();
                    break;

                default:
                    iwebdriver = _foxWebDriver.GetFirefoxWebDriver();
                    break;
            }
        }
        public void NavigateTo(string url)
        {
            GetWebDriver().Navigate().GoToUrl(url);
        }
        public void CloseBrowser()
        {
            GetWebDriver().Quit();
        }
        public string GetPageTitle()
        {
            return GetWebDriver().Title;
        }
        public string GetPageTitleWithExpectedValue(string titleExpectValue)
        {
            WebDriverWait wait = new(GetWebDriver(), TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TitleContains(titleExpectValue));
            return GetWebDriver().Title;
        }
        public void GetNewTab()
        {
            GetWebDriver().SwitchTo().NewWindow(WindowType.Tab);
        }
        public void CloseCurrentBrowser()
        {
            GetWebDriver().Close();
        }
        public void SwitchToWindowWithHandle(string handle)
        {
            GetWebDriver().SwitchTo().Window(handle);
        }
        public void SwitchToWindowWithTitle(string title)
        {
            IList<string> windowhandles = GetWebDriver().WindowHandles;
            foreach (string handle in windowhandles)
            {
                if (GetWebDriver().SwitchTo().Window(handle).Title.Contains(title))
                {
                    break;
                }
            }
        }
        public void SwitchToFrameWithTheName(string frameName)
        {
            GetWebDriver().SwitchTo().Frame(frameName);
        }
        public void Maximize()
        {
            GetWebDriver().Manage().Window.Maximize();
        }
        public void ExecuteJavaScript(string script)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)GetWebDriver();
            js.ExecuteScript(script);
        }
        public void ScrollToWithPixel()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)(GetWebDriver());
            js.ExecuteScript("window.scrollBy(0, 500)");
        }
        public void ScrollToByHeight()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)(GetWebDriver());
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }
        public void ScrollIntoView(IAtWebElement iatWebElement)
        {
            IWebElement iwebElement = iatWebElement.GetElement();
            IJavaScriptExecutor js = (IJavaScriptExecutor)(GetWebDriver());
            js.ExecuteScript("arguments[0].scrollIntoView", iwebElement);
        }
        public void ScrollToTheTopPage()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)(GetWebDriver());
            js.ExecuteScript("window.scrollTo(0, 0)");

        }
        public string GetScreenShot()
        {

            return ((ITakesScreenshot)GetWebDriver()).GetScreenshot().AsBase64EncodedString;
        }
        public void SelectDropdownList(IAtWebElement iatWebElement, string text)
        {
            IWebElement iwebElement = iatWebElement.GetElement();
            SelectElement drop = new(iwebElement);
            drop.SelectByText(text);

        }
        public void SelectStoreChoice(IAtWebElement iatWebElement)
        {
            IWebElement iwebElement = iatWebElement.GetElement();
            Actions actions = new Actions(GetWebDriver());
            actions.MoveToElement(iwebElement);
            actions.Click();
            actions.Perform();
        }
    }
}
