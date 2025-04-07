namespace UIAutomation.Core.Abstration
{
    public interface IExtentReport
    {
        void CreateFeature(string featureName);
        void CreateScenario(string scenarioName);
        void Pass(string msg, string base64);
        void Fail(string msg, string base64);
        void Warning(string msg, string base64);
        void Error(string msg, string base64);
    }
}
