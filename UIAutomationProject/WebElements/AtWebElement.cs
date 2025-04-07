using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using UIAutomation.Core.Abstration;
using UIAutomation.Core.CustomException;
using UIAutomation.Core.Runner;

namespace UIAutomation.Core.WebElements
{
    public class AtWebElement : IAtWebElement
    {
        IWebDriver _webDriver;
        IAtBy _iatBy;
        readonly ILogging _ilogging;
        public AtWebElement()
        {
            _ilogging = SpecFlowRunner._iserviceProvider.GetRequiredService<ILogging>();
        }
        public void Set(IWebDriver webDriver, IAtBy iatBy)
        {
            _webDriver = webDriver;
            _iatBy = iatBy;
        }
        public IWebElement GetElement()
        {
            try
            {
                WebDriverWait wait = new(_webDriver, TimeSpan.FromSeconds(30));
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(ElementNotSelectableException),
                    typeof(ElementNotInteractableException), typeof(NoSuchElementException));
                return wait.Until<IWebElement>(ExpectedConditions.ElementToBeClickable(_iatBy.By));

            }
            catch (Exception ex)
            {
                _ilogging.Error("Error while clicking element" + ex.Message);
                throw new AutomationException("Error while clicking element" + ex.Message);
            }
        }
        public void Click_EventHandler()
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    IWebElement element = GetElement();
                    element.Click();
                    break;
                }
                catch (StaleElementReferenceException st) 
                {
                    _ilogging.Error("Stale Element Reference Exception occurred!" + st.Message);
                }
                catch (Exception ex)
                {
                    _ilogging.Error("Error while clicking element" + ex.Message);
                    throw new AutomationException("Error while clicking element" + ex.Message);
                }
            }
        }
        public void SendKeys(string text)
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    IWebElement element = GetElement();
                    element.SendKeys(text);
                    break;
                }
                catch (StaleElementReferenceException se)
                {
                    _ilogging.Error("Stale Element Reference Exception occurred!" + se.Message);
                }
                catch (Exception ex)
                {
                    _ilogging.Error("Error while searching for the element" + ex.Message);
                    throw new AutomationException("Error while searching for the element" + ex.Message);
                }
            }
        }
        public void ClearText()
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    IWebElement element = GetElement();
                    element.SendKeys(Keys.Control + "a");
                    element.SendKeys(Keys.Delete);
                    break;
                }
                catch (StaleElementReferenceException se)
                {
                    _ilogging.Error("Stale Element Reference Exception occurred!" + se.Message);
                }
                catch (Exception ex)
                {
                    _ilogging.Error("Error while clearing the content" + ex.Message);
                    throw new AutomationException("Error while clearing the content" + ex.Message);
                }
            }
        }
        public string GetText()
        {
            string text = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    IWebElement element = GetElement();
                    text = element.Text;
                    break;
                }
                catch (StaleElementReferenceException se) 
                {
                    _ilogging.Error("Stale Element Reference Exception occurred!" + se.Message);
                }
                catch (Exception ex)
                {
                    _ilogging.Error("Error while getting the content" + ex.Message);
                    throw new AutomationException("Error while getting the content" + ex.Message);
                }
            }
            return text;
        }
        public string GetAttribute(string attributeName)
        {
            string text = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    IWebElement element = GetElement();
                    text = element.GetDomAttribute(attributeName);
                    break;
                }
                catch (StaleElementReferenceException se) 
                {
                    _ilogging.Error("Stale Element Reference Exception occurred!" + se.Message);
                }
                catch (Exception ex)
                {
                    _ilogging.Error("Error while getting the attribute" + ex.Message);
                    throw new AutomationException("Error while getting the attribute" + ex.Message);
                }
            }
            return text;
        }
        public void MouseHover()
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    IWebElement element = GetElement();
                    Actions actions = new(_webDriver);
                    actions.MoveToElement(element).Build().Perform();
                    break;
                }
                catch (StaleElementReferenceException se) 
                {
                    _ilogging.Error("Stale Element Reference Exception occurred!" + se.Message);
                }
                catch (Exception ex)
                {
                    _ilogging.Error("Error while hovering mouse on the element" + ex.Message);
                    throw new AutomationException("Error while hovering mouse on the element" + ex.Message);
                }
            }
        }
        public bool IsDisplayed()
        {
            bool isDisplayed = false;
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    IWebElement element = GetElement();
                    isDisplayed = element.Displayed;
                    break;
                }
                catch (StaleElementReferenceException se) 
                {
                    _ilogging.Error("Stale Element Reference Exception occurred!" + se.Message);
                }
                catch (Exception ex)
                {
                    _ilogging.Error("Error while hovering mouse on the element" + ex.Message);
                    throw new AutomationException("Error while hovering mouse on the element" + ex.Message);
                }
            }
            return isDisplayed;
        }
        public void DoubleClick()
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    IWebElement element = GetElement();
                    Actions action = new(_webDriver);
                    action.ContextClick(element);
                    break;
                }
                catch (StaleElementReferenceException st) 
                {
                    _ilogging.Error("Stale Element Reference Exception occurred!" + st.Message);
                }
                catch (Exception ex)
                {
                    _ilogging.Error("Error while double clicking on the element" + ex.Message);
                    throw new AutomationException("Error while double clicking on the element" + ex.Message);
                }
            }
        }
        public void ClickWithJS()
        {
            try
            {
                IWebElement element = GetElement();
                IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)_webDriver;
                javaScriptExecutor.ExecuteScript("arguments[0].click();", element);
            }
            catch (Exception ex)
            {
                _ilogging.Error("Error while clicking with JavaScript" + ex.Message);
                throw new AutomationException("Error while clicking with JavaScript" + ex.Message);
            }
        }

        public void ScrollUntiElementIsVisible()
        {
            IWebElement element = GetElement();
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)_webDriver;
            javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView();", element);
        }
    }
}

