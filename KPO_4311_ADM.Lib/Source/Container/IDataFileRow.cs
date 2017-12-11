using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPO_4311_ADM.Lib.Source.Container
{
    public interface IDataFileRow
    {
        int[] format { get; set; }
        string fromArrayToString(string[] array);
        string[] fromStringToArray(string str);
    }
    public class DataFileRow : IDataFileRow
    {
        public int[] format
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string fromArrayToString(string[] array)
        {
            throw new NotImplementedException();
        }

        public string[] fromStringToArray(string str)
        {
            throw new NotImplementedException();
        }
    }
}
