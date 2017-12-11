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
        private int[] _format;
        public DataFileRow(int[] format)
        {
            _format = format;
        }
        public int[] format
        {
            get
            {
                return _format;
            }

            set
            {
                _format = value;
            }
        }

        public string fromArrayToString(string[] array)
        {
            string finalRow = "";
            for (int ix = 0; ix < _format.Length; ix++)
            {
                finalRow += addSpaces(array[ix], format[ix] - array[ix].Length);
            }
            return finalRow;

        }

        public string[] fromStringToArray(string str)
        {
            string[] stringArray = new string[format.Length];
            for (int ix = 0, pos = 0; ix < format.Length; pos += format[ix], ix++)
            {
                stringArray[ix] = str.Substring(pos, format[ix]).Trim(' ');
            }
            return stringArray;
        }

        public string addSpaces(string row, int spacesCount)
        {
            string spaces = "";
            while (spacesCount-- != 0)
            {
                spaces += " ";
            }
            return spaces + row;
        }
    }
}
