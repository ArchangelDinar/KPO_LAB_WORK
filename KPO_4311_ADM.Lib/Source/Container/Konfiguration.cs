using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPO_4311_ADM.Lib
{
    public class Konfiguration
    {
        private string os;
        private string subd;
        private int hd;
        private int sd;
        private int price;
        private DateTime createTime;

        public Konfiguration()
        {
            os = "NaN";
            subd = "NaN";
            hd = 0;
            sd = 0;
            price = 0;
            createTime = DateTime.Now;
        }
        public Konfiguration(string os, string subd, int hd, int sd, int price)
        {
            OS = os;
            SUBD = subd;
            HD = hd;
            SD = sd;
            PRICE = price;
            createTime = DateTime.Now;
        }
        public Konfiguration(string os, string subd, int hd, int sd, int price, DateTime createTime)
        {
            OS = os;
            SUBD = subd;
            HD = hd;
            SD = sd;
            PRICE = price;
            CREATETIME = createTime;
        }
        public string OS {
            get { return os; }
            set { os = value; }
        }
        public string SUBD {
            get { return subd; }
            set { subd = value; }
        }
        public int HD {
            get { return hd; }
            set { hd = value; }
        }
        public int SD {
            get { return sd; }
            set { sd = value; }
        }
        public int PRICE {
            get { return price; }
            set { price = value; ; }
        }
        public DateTime CREATETIME
        {
            get { return createTime; }
            set { createTime = value; }
        }
    }
}