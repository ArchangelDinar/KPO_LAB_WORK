using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KPO_4311_ADM.Lib
{
    public interface IKonfigurationSaver
    {
        List<Konfiguration> konfigurationList { set; }
        void Execute();
    }

    public class KonfigurationSaver : IKonfigurationSaver
    {
        private List<Konfiguration> _konfigurationList;
        public KonfigurationSaver(List<Konfiguration> konfigurationList = null)
        {
            _konfigurationList = konfigurationList;
        }
        public void Execute()
        {
            if (_konfigurationList == null) _konfigurationList = new List<Konfiguration>();
            try
            {
                XDocument doc = new XDocument();
                XElement klist = new XElement("List", new XAttribute("Title", "Konfigurations"));
                for (int ix = 0; ix < _konfigurationList.Count; ix++)
                {
                    XElement xKonfig = new XElement("Konfiguration", new XAttribute("OS", _konfigurationList[ix].OS),
                        new XAttribute("SUBD", _konfigurationList[ix].SUBD), new XAttribute("HD", _konfigurationList[ix].HD.ToString()),
                        new XAttribute("SD", _konfigurationList[ix].SD.ToString()), new XAttribute("PRICE", _konfigurationList[ix].PRICE.ToString()),
                        new XAttribute("CREATETIME", _konfigurationList[ix].CREATETIME.ToString()));
                    klist.Add(xKonfig);
                }
                doc.Add(klist);
                doc.Save(AppGlobalSettings.dataFileName);
            }
            catch(Exception ex)
            {
                LogUtility.ErrorLog(ex.Message);
            }
        }
        public List<Konfiguration> konfigurationList
        {
            set { _konfigurationList = value; }
        }
    }

    public class KonfigurationTestSaver : IKonfigurationSaver
    {
        private List<Konfiguration> _konfigurationList;
        public KonfigurationTestSaver(List<Konfiguration> konfigurationList = null)
        {
            _konfigurationList = konfigurationList;
        }
        public void Execute()
        {
            XDocument doc = new XDocument();
            XElement klist = new XElement("List", new XAttribute("Title", "Konfigurations"));
            {
                XElement xKonfig = new XElement("Konfiguration", new XAttribute("OS", "OS/2"), new XAttribute("SUBD", "DB2"),
                new XAttribute("HD", "130"), new XAttribute("SD", "22"), new XAttribute("PRICE", "3343"),
                new XAttribute("CREATETIME", DateTime.Now.ToString()));
                klist.Add(xKonfig);
            }
            {
                XElement xKonfig = new XElement("Konfiguration", new XAttribute("OS", "Windows/NT"), new XAttribute("SUBD", "SQLServer"),
                new XAttribute("HD", "230"), new XAttribute("SD", "24"), new XAttribute("PRICE", "2685"),
                new XAttribute("CREATETIME", DateTime.Now.ToString()));
                klist.Add(xKonfig);
            }
            {
                XElement xKonfig = new XElement("Konfiguration", new XAttribute("OS", "SCO/Unix"), new XAttribute("SUBD", "Oracle"),
                new XAttribute("HD", "110"), new XAttribute("SD", "48"), new XAttribute("PRICE", "3745"),
                new XAttribute("CREATETIME", DateTime.Now.ToString()));
                klist.Add(xKonfig);
            }
            doc.Add(klist);
            doc.Save(AppGlobalSettings.dataFileName);
        }
        public List<Konfiguration> konfigurationList
        {
           set { _konfigurationList = value; }
        }
    }

    public class KonfigurationPDRSaver : IKonfigurationSaver
    {
        public List<Konfiguration> konfigurationList
        {
            set
            {
                throw new NotImplementedException();
                //установить лист конфигураций в заданное значение
            }
        }

        public void Execute()
        {
            throw new NotImplementedException();
            /*
             * Открыть файл для записи
             * (Количиство элементов в листе конфигураций) раз
             *      Записать в файл строку с данными из конфигурации
             * Закрыть файл
             */
        }
    }
}
