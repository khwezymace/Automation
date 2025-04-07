namespace UIAutomation.Core.Abstration
{
    public interface IExtentFeatureReport
    {
        void InitializeExtentReport();
        AventStack.ExtentReports.ExtentReports GetExtentReport();
        void FlushExtentReport();
    }
}
