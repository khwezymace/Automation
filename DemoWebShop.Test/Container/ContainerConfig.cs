using BoDi;
using UIAutomation.Core.DIContainer;
using DemoWebShop.Test.Configurations;
using DemoWebShop.Test.WebAbstraction;

namespace DemoWebShop.Test.Container
{
    [Binding]
    public class ContainerConfig
    {
        [BeforeScenario(Order = 1)]
        public static void BeforeScenario(IObjectContainer iobjectContainer)
        {
            iobjectContainer.RegisterTypeAs<AtConfiguration, IAtConfiguration>();
            iobjectContainer = CoreContainerConfig.SetContainer(iobjectContainer);

        }
    }
}
