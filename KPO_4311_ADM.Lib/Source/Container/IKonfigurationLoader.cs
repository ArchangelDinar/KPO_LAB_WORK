using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KPO_4311_ADM.Lib
{
    public interface IKonfigurationLoader
    {
        List<Konfiguration> konfigurationList { get; }
        void Execute(DataGridView dgv);
    }

    public class KonfigurationLoader : IKonfigurationLoader
    {
        private List<Konfiguration> _konfigurationList;
        public KonfigurationLoader(List<Konfiguration> konfigurationList = null)
        {
            _konfigurationList = konfigurationList;
        }
        public void Execute(DataGridView dgv)
        {
            if (_konfigurationList == null) _konfigurationList = new List<Konfiguration>();
            try
            {
                XDocument doc = XDocument.Load(AppGlobalSettings.dataFileName);
                foreach (XElement xkon in doc.Root.Elements("Konfiguration"))
                {
                    _konfigurationList.Add(new Konfiguration(xkon.Attribute("OS").Value, xkon.Attribute("SUBD").Value,
                        Convert.ToInt32(xkon.Attribute("HD").Value), Convert.ToInt32(xkon.Attribute("SD").Value),
                        Convert.ToInt32(xkon.Attribute("PRICE").Value), Convert.ToDateTime(xkon.Attribute("CREATETIME").Value)));
                }
                doc = null;
            }
            catch
            {

            }
        }
        public List<Konfiguration> konfigurationList
        {
            get { return _konfigurationList; }
            set { _konfigurationList = value; }
        }
    }

    public class KonfigurationTestLoader : IKonfigurationLoader
    {
        private List<Konfiguration> _konfigurationList;
        public KonfigurationTestLoader(List<Konfiguration> konfigurationList = null)
        {
            _konfigurationList = konfigurationList;
        }
        public void Execute(DataGridView dgv)
        {
            if (_konfigurationList == null) _konfigurationList = new List<Konfiguration>();

            {
                Konfiguration kon = new Konfiguration()
                {
                    OS = "OS/2",
                    SUBD = "DB2",
                    HD = 130,
                    SD = 22,
                    PRICE = 3343,
                    CREATETIME = DateTime.Now
                };
                _konfigurationList.Add(kon);
            }
            {
                Konfiguration kon = new Konfiguration()
                {
                    OS = "Windows/NT",
                    SUBD = "SQLServer",
                    HD = 230,
                    SD = 24,
                    PRICE = 2685,
                    CREATETIME = DateTime.Now
                };
                _konfigurationList.Add(kon);
            }
            {
                Konfiguration kon = new Konfiguration()
                {
                    OS = "SCO/Unix",
                    SUBD = "Oracle",
                    HD = 110,
                    SD = 48,
                    PRICE = 3745,
                    CREATETIME = DateTime.Now
                };
                _konfigurationList.Add(kon);
            }
        }
        public List<Konfiguration> konfigurationList
        {
            get { return _konfigurationList; }
            set { _konfigurationList = value; }
        }
    }

}