using OpenQA.Selenium;

namespace UIAutomation.Core.Abstration
{
    public interface IAtWebElement
    {
        void Set(IWebDriver webDriver, IAtBy iatBy);
        void Click_EventHandler();
        void SendKeys(string text);
        void ClearText();
        string GetText();
        string GetAttribute(string attributeName);
        void MouseHover();
        bool IsDisplayed();
        void DoubleClick();
        void ClickWithJS();
        IWebElement GetElement();
        void ScrollUntiElementIsVisible();




    }
}
