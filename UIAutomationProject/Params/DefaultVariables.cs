using UIAutomation.Core.Abstration;

namespace UIAutomation.Core.Params
{
    public class DefaultVariables() : IDefaultVariables
    {

        public string GetReport
        {
            get
            {
                return System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../")
                    .FullName + "\\Result\\Report"
                 + DateTime.Now.ToString("yyyyMMdd HHmmss");
            }
        }

        public string GetLogFile
        {
            get
            {
                return GetReport + "\\log.txt";
            }
        }
        public string GetLog
        {
            get
            {
                return GetLogFile + "\\log.txt";
            }
        }
        public string GetExtentReport
        {
            get
            {
                return GetReport + "\\index.html";
            }
        }
        public string GetFrameworkSettingsJson
        {
            get
            {
                return Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName +
                    "\\Resources\\frameworkSettings.json";
            }
        }
        public string Gridhuburl
        {
            get
            {
                return "";
            }
        }
        public string DataSetlocation
        {
            get
            {
                return Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName +
                    "\\Resources\\TestData.json";
            }
        }
        public string Downloadedlocation
        {
            get
            {
             
                return "downloadedFilePath";
            }
        }
        public string GetApplicationConfigJson
        {
            get
            {
                return Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName +
                    "\\Resources\\ApplicationConfig.json";
            }
        }

    }
}
