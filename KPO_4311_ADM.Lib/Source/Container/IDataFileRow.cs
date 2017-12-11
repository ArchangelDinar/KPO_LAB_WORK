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
                //вернуть формат
            }

            set
            {
                throw new NotImplementedException();
                //установить формат в заданное значение
            }
        }

        public string fromArrayToString(string[] array)
        {
            throw new NotImplementedException();
            /*
             * объявить пустую строку стр1
             * (Количество атрибутов в формате) РАЗ
             *      Добавить недостоющее количество пробелов в i-тое свойство 
             *              --> Реализовать функцию добавления пробелов
             *      Добавить к строке стр1 i-тое свойство
             * Конец РАЗ
             * вернуть стр1
             */

        }

        public string[] fromStringToArray(string str)
        {
            throw new NotImplementedException();
            /*
             * Объявить массив строк мсСтр размеров с кол-вом аттрибутов в формате
             * (Количество аттрибутов в формате) РАЗ
             *      Взять подстроку из строки по позиции из i-того аттрибута формата
             *      Удалить лишние пробелы
             *      мсСтр i-тый установить равным полученной подстроке
             * Конец РАЗ
             * Вернуть мсСтр
             */
        }

        public string addSpaces(string row, int spacesCount)
        {
            throw new NotImplementedException();
            /*
             * Объявить пустую строку
             * Добавить в нее нужное количество пробелов
             * Добавить к строке пробелов исходную строку
             * Вернуть строку
             */
        }
    }
}
