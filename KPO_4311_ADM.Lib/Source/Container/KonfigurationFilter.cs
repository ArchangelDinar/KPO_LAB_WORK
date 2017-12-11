using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPO_4311_ADM.Lib
{
    public class KonfigurationFilter
    {
        private List<Konfiguration> _konfigurationList;
        private DateTime _after, _before;
        public KonfigurationFilter() {
            _konfigurationList = new List<Konfiguration>();
            _after = DateTime.MinValue;
            _before = DateTime.MaxValue;
        }
        public List<Konfiguration> KonfigurationList{
            get { return _konfigurationList; }
            set { _konfigurationList = value; }
        }
        public DateTime After
        {
            get { return _after; }
            set { _after = value; }
        }
        public DateTime Before
        {
            get { return _before; }
            set { _before = value; }
        }
        public List<Konfiguration> Filter()
        {
            //throw new NotImplementedException();
            List<Konfiguration> filtredList = new List<Konfiguration>();
            for (int ix = 0; ix < _konfigurationList.Count; ix++)
                if (_konfigurationList[ix].CREATETIME >= _after &&
                                _konfigurationList[ix].CREATETIME <= _before)
                    filtredList.Add(_konfigurationList[ix]);
            return filtredList;
        }
    }
}
