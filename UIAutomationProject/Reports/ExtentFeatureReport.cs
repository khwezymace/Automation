using AventStack.ExtentReports.Reporter;
using UIAutomation.Core.Abstration;

namespace UIAutomation.Core.Reports
{
    public class ExtentFeatureReport(IDefaultVariables idefaultVariables) : IExtentFeatureReport
    {
        AventStack.ExtentReports.ExtentReports extentReports;

        public void InitializeExtentReport()
        {
            ExtentHtmlReporter extentHtmlReporter = new(idefaultVariables.GetExtentReport);
            extentReports = new AventStack.ExtentReports.ExtentReports();
            extentReports.AttachReporter(extentHtmlReporter);
        }
        public AventStack.ExtentReports.ExtentReports GetExtentReport()
        {
            return extentReports;
        }
        public void FlushExtentReport()
        {
            extentReports.Flush();
        }

    }
}
