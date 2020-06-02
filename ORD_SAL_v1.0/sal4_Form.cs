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
    public partial class sal4_Form : Form
    {
        Form parentf = null;
        character_Info ch;
        int[] character_arr;
        PictureBox[] pbArr;
        Label[] lbArr;
        string sendtxt;
        sendMsg s;
        public sal4_Form(Form mainf, int[] arr)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.Text = "4개 결과발표";
            parentf = mainf;
            ch = character_Info.Instance;
            character_arr = arr;
            pbArr = new PictureBox[] { sal4_PB1, sal4_PB2, sal4_PB3, sal4_PB4};
            lbArr = new Label[] { label1, label2, label3, label4};
            s = sendMsg.getInstance;
        }

        private void sal4_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentf.Show();
            parentf = null;
        }

        private void sal4_Form_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < character_arr.Length; i++)
            {
                pbArr[i].Image = ch.chList[character_arr[i]].img;
                lbArr[i].Text = ch.chList[character_arr[i]].name;
                sendtxt += "[" + ch.chList[character_arr[i]].name + "] ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            s.Send(sendtxt);
        }

    }
}
