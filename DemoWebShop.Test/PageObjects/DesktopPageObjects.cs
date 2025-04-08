using BoDi;
using DemoWebShop.Test.WebAbstraction;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomation.Core.Abstration;
using UIAutomation.Core.Base;

namespace DemoWebShop.Test.PageObjects
{

    public class DesktopPageObjects(IObjectContainer objectContainer, IDrivers idrivers, IAtConfiguration atConfiguration): TestBase(objectContainer), IDesktopPageObjects
    {
        IDrivers _idrivers = idrivers;
        IAtConfiguration _atConfiguration = atConfiguration;

        IAtBy BySortByDropdownList => GetBy(LocatorType.Xpath, "//select[@id='products-orderby']");
        IAtWebElement SortByDropdownList => _idrivers.FindElement(BySortByDropdownList);    

        public void UserSortByProductsDropdownUsingAllOptions()
        {

            var selectElement = new SelectElement((OpenQA.Selenium.IWebElement)SortByDropdownList);
            selectElement.SelectByText("Name: A to Z");
            Thread.Sleep(1000);


        }
    }
}
