using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPO_4311_ADM.Lib
{
    public static class AppGlobalSettings
    {
        private static string _logPath = "error.log";
        private static string _dataFileName = "konfigurations.xml";
        private static string _rowDataFileName = "KonfigurationsRows.txt";
        public static string logPath => _logPath;
        public static string dataFileName => _dataFileName;
        public static string rowDataFileName => _rowDataFileName;
        private static IKonfigurationFactory konfigurationFactory = new KonfigurationFactoryFile();

        static AppGlobalSettings()
        {
            /*AppConfigUtility conf = new AppConfigUtility();
            _logPath = conf.AppSettings("logPath");
            _dataFileName = conf.AppSettings("dataFileName");*/
        }        

        public static void Initialize()
        {
           /* AppConfigUtility conf = new AppConfigUtility();
            _logPath = conf.AppSettings("logPath");
            _dataFileName = conf.AppSettings("dataFilePath");*/
        }
        public static IKonfigurationLoader getLoader()
        {
            return konfigurationFactory.CreateKonfigurationLoader();
        }
        public static IKonfigurationSaver getSaver()
        {
            return konfigurationFactory.CreateKonfigurationSaver();
        }
    }
}