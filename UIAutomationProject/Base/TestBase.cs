using BoDi;
using OpenQA.Selenium;
using UIAutomation.Core.Abstration;

namespace UIAutomation.Core.Base
{
    public class TestBase
    {
        private readonly IObjectContainer _iobjectContainer;
        public TestBase(IObjectContainer iobjectContainer)
        {
            _iobjectContainer = iobjectContainer;
        }
        public IAtBy GetBy(LocatorType type, string value)
        {
            By by;
            IAtBy iatBy = _iobjectContainer.Resolve<IAtBy>();
            switch (type)
            {
                case LocatorType.Xpath:
                    by = By.XPath(value);
                    break; 
                case LocatorType.Name:
                    by = By.Name(value);
                    break;
                case LocatorType.Id:
                    by = By.Id(value);
                    break;
                case LocatorType.LinkText:
                    by = By.LinkText(value);
                    break;
                case LocatorType.TagName:
                    by = By.TagName(value);
                    break;
                case LocatorType.PartialLinkText:
                    by = By.PartialLinkText(value);
                    break;
                case LocatorType.ClassName:
                    by = By.ClassName(value);
                    break;

                default:
                    by = By.XPath(value);
                    break;
            }
            iatBy.By = by;  
            return iatBy;
        }
    }
}
