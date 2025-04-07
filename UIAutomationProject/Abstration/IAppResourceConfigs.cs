using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomation.Core.Abstration
{
    public interface IAppResourceConfigs
    {
        (string reportpath, string logPath, string downloadedFilepath) GetBDMExternalDir();
    }
}
