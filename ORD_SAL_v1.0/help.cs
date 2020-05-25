using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORD_SAL_v1._0
{
    public partial class help : Form
    {
        Form parentf = null;

        public help(Form mainf)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            parentf = mainf;
        }

        private void help_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentf.Show();
            parentf = null;
        }
    }
}
