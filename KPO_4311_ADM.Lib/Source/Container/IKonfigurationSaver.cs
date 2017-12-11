using System;
using System.Collections.Generic;
using System.IO;
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
        private List<Konfiguration> _konfigurationList;
        public List<Konfiguration> konfigurationList
        {
            set
            {
                _konfigurationList = value;

            }
        }

        public void Execute()
        {
            try
            {
                FileStream file = new FileStream(AppGlobalSettings.rowDataFileName, FileMode.Create);
                StreamWriter writer = new StreamWriter(file);
                for (int ix = 0; ix < _konfigurationList.Count; ix++)
                {
                    writer.WriteLine("{0, 20}{1, 20}{2, 8}{3, 8}{4, 8}{5, 19}",
                        _konfigurationList[ix].OS, _konfigurationList[ix].SUBD,
                        _konfigurationList[ix].HD.ToString(),
                        _konfigurationList[ix].SD.ToString(),
                        _konfigurationList[ix].PRICE.ToString(),
                        _konfigurationList[ix].CREATETIME.ToString());
                }
                writer.Close();
                file.Close();
            }
            catch (Exception ex)
            {
                LogUtility.ErrorLog(ex.Message);
            }
        }
    }

    public class KonfigurationModifiedPDRSaver : IKonfigurationSaver
    {
        private List<Konfiguration> _konfigurationList;
        private int[] format;
        public KonfigurationModifiedPDRSaver(int[] format)
        {
            this.format = format;
        }
        public List<Konfiguration> konfigurationList
        {
            set
            {
                _konfigurationList = value;
            }
        }

        public void Execute()
        {
            try
            {
                FileStream file = new FileStream(AppGlobalSettings.rowDataFileName, FileMode.Create);
                StreamWriter writer = new StreamWriter(file);
                DataFileRow dfr = new DataFileRow(format);
                for (int ix = 0; ix < _konfigurationList.Count; ix++)
                {
                    string[] properties = { _konfigurationList[ix].OS, _konfigurationList[ix].SUBD,
                                            _konfigurationList[ix].HD.ToString(),
                                            _konfigurationList[ix].SD.ToString(),
                                            _konfigurationList[ix].PRICE.ToString(),
                                            _konfigurationList[ix].CREATETIME.ToString() };
                    writer.WriteLine(dfr.fromArrayToString(properties));
                }
                writer.Close();
                file.Close();
            }
            catch (Exception ex)
            {
                LogUtility.ErrorLog(ex.Message);
            }
        }
    }
}
