using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject_Application_2.Utilities.Logging
{
    public interface ILogging
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message);
    }
}
