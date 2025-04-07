namespace UIAutomation.Core.Abstration
{
    public interface IDefaultVariables
    {
        string GetLog { get; }
        string GetExtentReport { get; }
        string GetFrameworkSettingsJson { get; }
        string Gridhuburl { get; }
        string DataSetlocation { get; }
        string Downloadedlocation { get; }
        string GetApplicationConfigJson { get; }
    }
}
