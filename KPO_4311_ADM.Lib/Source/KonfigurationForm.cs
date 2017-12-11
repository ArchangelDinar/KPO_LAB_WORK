using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPO_4311_ADM.Lib
{
    public partial class KonfigurationForm : Form
    {
        public KonfigurationForm(Konfiguration kon)
        {
            InitializeComponent();
            richTextBox.Text = "";
            richTextBox.Text += "OS: " + kon.OS;
            richTextBox.Text += "\nSUBD: " + kon.SUBD;
            richTextBox.Text += "\nHD: " + kon.HD;
            richTextBox.Text += "\nSD: " + kon.SD;
            richTextBox.Text += "\nPRICE: " + kon.PRICE;
        }
    }
}
