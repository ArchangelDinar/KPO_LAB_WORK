using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPO_4311_ADM.Lib
{
    public static class LogUtility
    {
        public static void ErrorLog(string message)
        {
            File.AppendAllText(AppGlobalSettings.logPath, DateTime.Today + " " + message);
        }
        public static void ErrorLog(Exception ex)
        {
            File.AppendAllText(AppGlobalSettings.logPath, DateTime.Today + " " + ex.Message);
        }
    }
}
