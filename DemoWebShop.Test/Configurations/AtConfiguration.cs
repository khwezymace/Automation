using DemoWebShop.Test.WebAbstraction;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using UIAutomation.Core.Abstration;
using UIAutomation.Core.Runner;

namespace DemoWebShop.Test.Configurations
{
    public class AtConfiguration : IAtConfiguration
    {
        readonly IConfiguration _iconfiguration;
        public AtConfiguration()
        {
            IDefaultVariables idefaultVariables = SpecFlowRunner._iserviceProvider.GetRequiredService<IDefaultVariables>();
            _iconfiguration = new ConfigurationBuilder().AddJsonFile(idefaultVariables.GetApplicationConfigJson).Build();
        }
        public string GetConfiguration(string key)
        {
            return _iconfiguration[key];
        }
    }
}
