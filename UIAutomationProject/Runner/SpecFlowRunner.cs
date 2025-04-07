using Microsoft.Extensions.DependencyInjection;
using UIAutomation.Core.Abstration;
using UIAutomation.Core.DIContainer;

namespace UIAutomation.Core.Runner
{
    [Binding]
    public class SpecFlowRunner
    {
        public static IServiceProvider _iserviceProvider;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _iserviceProvider = CoreContainerConfig.ConfigureServices();  
            _iserviceProvider.GetRequiredService<IGlobalProperties>();
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext fs)
        {
            IExtentReport iextentReport = _iserviceProvider.GetRequiredService<IExtentReport>();
            iextentReport.CreateFeature(fs.FeatureInfo.Title);
            fs["iextentreport"] = iextentReport;

        }

    }
}

