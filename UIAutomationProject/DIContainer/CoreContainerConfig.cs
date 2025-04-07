using BoDi;
using Microsoft.Extensions.DependencyInjection;
using UIAutomation.Core.Abstration;
using UIAutomation.Core.Common;
using UIAutomation.Core.DriverContext;
using UIAutomation.Core.Params;
using UIAutomation.Core.Reports;
using UIAutomation.Core.Selenium.WebDrivers;
using UIAutomation.Core.WebElements;

namespace UIAutomation.Core.DIContainer
{
    public class CoreContainerConfig
    {
        public static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IDefaultVariables, DefaultVariables>();
            services.AddSingleton<ILogging, Logging>();
            services.AddSingleton<IGlobalProperties, GlobalProperties>();
            services.AddSingleton<IExtentFeatureReport, ExtentFeatureReport>();
            services.AddSingleton<IAppResourceConfigs, AppResourceConfigs>();
            services.AddTransient<IExtentReport, ExtentReport>();
            return services.BuildServiceProvider();
        }
        public static IObjectContainer SetContainer(IObjectContainer iobjectContainer)
        {
            iobjectContainer.RegisterTypeAs<ChromeWebDriver, IChromeWebDriver>();
            iobjectContainer.RegisterTypeAs<FirefoxWebDriver, IFirefoxWebDriver>();
            iobjectContainer.RegisterTypeAs<Drivers, IDrivers>();
            iobjectContainer.RegisterTypeAs<AtBy, IAtBy>();
            iobjectContainer.RegisterTypeAs<AtWebElement, IAtWebElement>();
            return iobjectContainer;
        }
    }
}
