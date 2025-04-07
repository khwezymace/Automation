using Microsoft.Extensions.Configuration;
using UIAutomation.Core.Abstration;

namespace UIAutomation.Core.Params
{
    public class GlobalProperties : IGlobalProperties
    {
        readonly IDefaultVariables _idefaultVariables;
        private readonly ILogging _ilogging;
        readonly IExtentFeatureReport _iextentFeatureReport;

        public string browsertype { get; set; }
        public string gridhuburl { get; set; }
        public bool stepscreenshot { get; set; }
        public string extentreportportalurl { get; set; }
        public bool extentreporttoportal { get; set; }
        public string loglevel { get; set; }
        public string datasetlocation { get; set; }
        public string downloadedlocation { get; set; }

        public GlobalProperties(IDefaultVariables idefaultVariables, ILogging ilogging, IExtentFeatureReport iextentFeatureReport)
        {
            _idefaultVariables = idefaultVariables;
            _ilogging = ilogging;
            _iextentFeatureReport = iextentFeatureReport;   
            Configuration();
        }
        public void Configuration()
        {
            var builder = (dynamic)null;
            try
            {
                builder = new ConfigurationBuilder().AddJsonFile(_idefaultVariables.GetFrameworkSettingsJson).Build();
            }
            catch (Exception ex)
            {
                _ilogging.Error("File does not exist" + ex.Message);
                System.Environment.Exit(0);
            }
            browsertype = string.IsNullOrEmpty(builder["BrowserType"]) ? "chrome" : builder["BrowserType"];
            gridhuburl = string.IsNullOrEmpty(builder["GridHubUrl"]) ? _idefaultVariables.Gridhuburl : builder["GridHubUrl"];
            stepscreenshot = builder["StepScreenShot"].ToLower().Equals("on") ? true : false;
            extentreportportalurl = builder["ExtentReportPortalUrl"];
            extentreporttoportal = builder["ExtentReportToPortal"].ToLower().Equals("On") ? true : false;
            loglevel = builder["LogLevel"];
            datasetlocation = string.IsNullOrEmpty(builder["DataSetLocation"]) ? _idefaultVariables.DataSetlocation : builder["DataSetLocation"];
            downloadedlocation = string.IsNullOrEmpty(builder["Dawnloadedlocation"]) ? _idefaultVariables.Downloadedlocation : builder["Dawnloadedlocation"];
            _iextentFeatureReport.InitializeExtentReport();
            _ilogging.LogLevel(loglevel);

            _ilogging.Debug("****************************************************************");
            _ilogging.Information("**********************************************************");
            _ilogging.Information("Configuration | RUN PARAMETERS");
            _ilogging.Information("**********************************************************");
            _ilogging.Information("Configuration | BROWSERTYPE" + browsertype);
            _ilogging.Information("Configuration | GRID HUB URL" + gridhuburl);
            _ilogging.Information("Configuration | STEP SCREENSHOT" + stepscreenshot);
            _ilogging.Information("Configuration | EXTENT REPORT PORTAL URL" + extentreportportalurl);
            _ilogging.Information("Configuration | EXTENT REPORT LOCALLY" + extentreporttoportal);
            _ilogging.Information("Configuration | LOG LEVEL" + loglevel);
            _ilogging.Information("Configuration | DATA SET LOCATION" + datasetlocation);
            _ilogging.Information("Configuration | DOWNLOADED LOCATION" + downloadedlocation);
            _ilogging.Information("**********************************************************");
            _ilogging.Information("**********************************************************");
        }
    }
}
