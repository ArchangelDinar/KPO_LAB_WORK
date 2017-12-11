using KPO_4311_ADM.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPO_4311_ADM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _konfigurationList = new List<Konfiguration>();
            filtrating = false;
        }
        private List<Konfiguration> _konfigurationList;
        private bool filtrating;
        private void ShowMessageWindow(string row)
        {
            MessageBox.Show(row);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var loader = AppGlobalSettings.getLoader();
            loader.Execute();
            _konfigurationList = loader.konfigurationList;
            dataGridViewKonfigurationList.DataSource = new BindingSource { DataSource = _konfigurationList };
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filtrating) {
                dataGridViewKonfigurationList.DataSource = new BindingSource { DataSource = _konfigurationList };
                filtrating = !filtrating;
            }
            var saver = AppGlobalSettings.getSaver();
            saver.konfigurationList = ((dataGridViewKonfigurationList.DataSource as BindingSource).DataSource as List<Konfiguration>);
            saver.Execute();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KonfigurationForm kf = new KonfigurationForm(((dataGridViewKonfigurationList.DataSource as BindingSource).Current as Konfiguration));
            kf.ShowDialog();
        }

        private void dateTimePickerAfter_ValueChanged(object sender, EventArgs e)
        {
            filtrating = true;
            dataGridViewKonfigurationList.DataSource = new BindingSource { DataSource = 
                (new KonfigurationFilter {
                    KonfigurationList = _konfigurationList,
                    After = dateTimePickerAfter.Value,
                    Before = dateTimePickerBefore.Value
                }).Filter() };
        }

        private void dateTimePickerBefore_ValueChanged(object sender, EventArgs e)
        {
            filtrating = true;
            dataGridViewKonfigurationList.DataSource = new BindingSource
            {
                DataSource =
                (new KonfigurationFilter
                {
                    KonfigurationList = _konfigurationList,
                    After = dateTimePickerAfter.Value,
                    Before = dateTimePickerBefore.Value
                }).Filter()
            };
        }

        private void dataGridViewKonfigurationList_Click(object sender, EventArgs e)
        {
            if (filtrating)
            {
                dataGridViewKonfigurationList.DataSource = new BindingSource { DataSource = _konfigurationList };
                filtrating = !filtrating;
            }
        }
        
    }
}
