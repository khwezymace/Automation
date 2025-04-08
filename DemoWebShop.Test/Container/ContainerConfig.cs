using BoDi;
using UIAutomation.Core.DIContainer;
using DemoWebShop.Test.Configurations;
using DemoWebShop.Test.WebAbstraction;
using DemoWebShop.Test.PageObjects;

namespace DemoWebShop.Test.Container
{
    [Binding]
    public class ContainerConfig
    {
        [BeforeScenario(Order = 1)]
        public static void BeforeScenario(IObjectContainer iobjectContainer)
        {
            iobjectContainer.RegisterTypeAs<AtConfiguration, IAtConfiguration>();
            iobjectContainer.RegisterTypeAs<LoginPageObjects, ILoginPageObjects>();
            iobjectContainer.RegisterTypeAs<HomePageObjects, IHomePageObjects>();
            iobjectContainer.RegisterTypeAs<DesktopPageObjects, IDesktopPageObjects>(); 
            iobjectContainer = CoreContainerConfig.SetContainer(iobjectContainer);

        }
    }
}
