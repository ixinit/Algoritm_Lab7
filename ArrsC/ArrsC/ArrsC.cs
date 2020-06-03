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
            s.Show(dgArr);
        }

        private void btnShell_Click(object sender, EventArgs e)
        {
            s.Shell();
            s.Show(dgArr);
        }

        private void btnBubble_Click(object sender, EventArgs e)
        {
            s.BubbleSort(1);
            s.Show(dgArr);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            s.InsertSort();
            s.Show(dgArr);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            s.Save(dgArr);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            s.Show(dgArr);
        }
    }
}
