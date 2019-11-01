using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolentHealth_Contact_App.Utilities
{
    public interface ILogManager
    {
        void LogInfo(string message);
        void LogError(string message);
        void LogWarn(string message);
    }
}
