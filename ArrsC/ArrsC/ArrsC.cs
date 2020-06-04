using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrsC
{
    public partial class ArrsC : Form
    {
        public ArrsC()
        {
            InitializeComponent();
        }

        SortsClass s = new SortsClass();
        private void btnCreate_Click(object sender, EventArgs e)
        {
            s.Init(tbN.Text, tbB.Text);
        }

        private void btnShell_Click(object sender, EventArgs e)
        {
            s.Shell();
        }

        private void btnBubble_Click(object sender, EventArgs e)
        {
            s.BubbleSort(1);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            s.InsertSort();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            s.Save(dgArr);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            s.Show(dgArr);
        }

        private void btnF1_Click(object sender, EventArgs e)
        {
            int res = s.FindFirst(tbSearch.Text);
            if (res != -1)
                MessageBox.Show(string.Format(@"Индекс элемента {0}", res));
            else
                MessageBox.Show("Не найдено");
        }

        private void btnF2_Click(object sender, EventArgs e)
        {
            int res = s.DSearch(tbSearch.Text);
            if (res != -1)
                MessageBox.Show(string.Format(@"Индекс элемента {0}", res));
            else
                MessageBox.Show("Не найдено");
        }

        private void btnSum1_Click(object sender, EventArgs e)
        {
            String res, _dt;
            s.SeqSum(out res, out _dt);
            lblSum.Text = res;
        }

        private void btnSum2_Click(object sender, EventArgs e)
        {
            String res, _dt;
            s.ParSum(out res, out _dt);
            lblSum.Text = res;
        }
    }
}
