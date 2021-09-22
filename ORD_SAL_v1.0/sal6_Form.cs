﻿using System;
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
    public partial class sal6_Form : Form
    {
        Form parentf = null;
        character_Info ch;
        int[] character_arr;
        PictureBox[] pbArr;
        Label[] lbArr;
        string sendtxt, sendtxt1;
        sendMsg s;
        
        public sal6_Form(Form mainf, int[] arr)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.Text = "6개 결과발표";
            parentf = mainf;
            ch = character_Info.Instance;
            character_arr = arr;
            pbArr = new PictureBox[]{pictureBox1,pictureBox2,pictureBox3,pictureBox4,pictureBox5,pictureBox6};
            lbArr = new Label[] { label1, label2, label3, label4, label5, label6 };
            s = sendMsg.getInstance;
        }

        private void sal6_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentf.Show();
            parentf = null;
        }

        private void sal6_Form_Load(object sender, EventArgs e)
        {

            sendtxt = $"\x1「ORD_TOOL」6살결과|n";
            sendtxt1 = $"\x1「ORD_TOOL」6살결과";
            for (int i = 0; i < character_arr.Length; i++)
            {
                pbArr[i].Image = ch.chList[character_arr[i]].img;
                lbArr[i].Text = ch.chList[character_arr[i]].shortname;
                sendtxt += "[" + ch.chList[character_arr[i]].name + "] ";
                sendtxt1 += "[" + ch.chList[character_arr[i]].shortname + "] ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            s.Send(sendtxt);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            s.Send(sendtxt1);
        }

        public void CheckWarCreaftOn()
        {
            if (s == null)
            {
                parentf.Show();
                parentf = null;
            }
            else
            {
                this.ShowDialog();
            }
        }
    }
}
