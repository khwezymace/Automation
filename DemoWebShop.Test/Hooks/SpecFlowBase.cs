using BoDi;
using Microsoft.Extensions.DependencyInjection;
using UIAutomation.Core.Abstration;
using UIAutomation.Core.Runner;

namespace DemoWebShop.Test.Hooks
{
    [Binding]
    public class SpecFlowBase
    {
        IChromeWebDriver _ichromeWebDriver;
        IFirefoxWebDriver _foxWebDriver;
        IDrivers _idrivers;
        ScenarioContext _scenarioContext;
        public SpecFlowBase(IChromeWebDriver ichromeWebDriver, IFirefoxWebDriver ifirefoxWebDriver, IDrivers idrivers)
        {
            _ichromeWebDriver = ichromeWebDriver;
            _foxWebDriver = ifirefoxWebDriver;
            _idrivers = idrivers;
        }
        [BeforeScenario(Order = 2)]
        public void BeforeScenario(IObjectContainer iobjectContainer, ScenarioContext scenarioContext, FeatureContext fs)
        {
            _idrivers = iobjectContainer.Resolve<IDrivers>();
            _scenarioContext = scenarioContext;
            IExtentReport extentReport = (IExtentReport)fs["iextentreport"];
            extentReport.CreateScenario(scenarioContext.ScenarioInfo.Title);
        }
        [AfterStep]
        public void AfterSteps(ScenarioContext sc, FeatureContext fs)
        {
            IGlobalProperties _iglobalProperties = SpecFlowRunner._iserviceProvider.GetRequiredService<IGlobalProperties>();
            IExtentReport extentReport = (IExtentReport)fs["iextentreport"];

            if (sc.TestError != null)
            {
                string base64 = null;
                base64 = _idrivers.GetScreenShot();
                extentReport.Fail(sc.StepContext.StepInfo.Text, base64);
            }
            else
            {
                string base64 = null;
                if (_iglobalProperties.stepscreenshot)
                {
                    base64 = _idrivers.GetScreenShot();
                }
                extentReport.Pass(sc.StepContext.StepInfo.Text, base64);
            }
        }
        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext, FeatureContext fs)
        {
            IExtentFeatureReport iextentfeatureReport = SpecFlowRunner._iserviceProvider.GetRequiredService<IExtentFeatureReport>();
            iextentfeatureReport.FlushExtentReport();
            Thread.Sleep(5000);
            _idrivers.CloseBrowser();
        }
    }
}
