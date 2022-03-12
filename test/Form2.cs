using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test

{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 dlg = new Form1();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.pic1.Image = dlg.SavedBitmap;
            }
        }
    }
}
