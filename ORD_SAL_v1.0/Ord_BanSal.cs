using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORD_SAL_v1._0
{

    public partial class Ord_BanSal : Form
    {
        bool tb1 = false; // 텍스트박스 건드렸는지 안건드렸는지 확인
        public bool timerPress = true; //알리미버튼 확인용
        random_Pick s;
        public Commands cmd = null;
        public Ord_BanSal()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.Text = "ORD_TOOL";
            textBox1.Text = "입력하세요.";
            s = random_Pick.getInstance;
            
        }

        


        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!tb1)
            {
                textBox1.Text = null;
                tb1 = true;
            }
        }

        private void salCB3_Click(object sender, EventArgs e)
        {
            if (salCB1.Checked || salCB2.Checked)
            {
                salCB1.Checked = false;
                salCB2.Checked = false;
                salCB3.Checked = true;
            }
        }

        private void salCB1_Click(object sender, EventArgs e)
        {
            if (salCB3.Checked || salCB2.Checked)
            {
                salCB3.Checked = false;
                salCB2.Checked = false;
                salCB1.Checked = true;
            }
        }

        private void salCB2_Click(object sender, EventArgs e)
        {
            if (salCB1.Checked || salCB3.Checked)
            {
                salCB1.Checked = false;
                salCB3.Checked = false;
                salCB2.Checked = true;
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //sendMsg s = sendMsg.getInstance;
                //s.Send("새로운 밴살프로그램 테스트중입니다.");
                if (salCB1.Checked) //6
                {
                    //랜덤숫자 받아오기
                    int[] arr = s.start_Set(int.Parse(textBox1.Text), 6);
                    this.Hide();
                    new sal6_Form(this, arr).ShowDialog();
                }
                else if (salCB2.Checked) //8
                {
                    int[] arr = s.start_Set(int.Parse(textBox1.Text), 8);
                    this.Hide();
                    new sal8_Form(this, arr).ShowDialog();
                }
                else if (salCB3.Checked) //4
                {
                    int[] arr = s.start_Set(int.Parse(textBox1.Text), 4);
                    this.Hide();
                    new sal4_Form(this, arr).ShowDialog();
                }
                else if (!salCB1.Checked && !salCB2.Checked && !salCB3.Checked)
                {
                    MessageBox.Show("몇개를 뽑을지 정하지 않았습니다.", "체크박스 선택안함");
                }
            }
            catch
            {
                MessageBox.Show("잘못된 세이브 횟수를 입력했습니다.");
            }
        }

        private void setBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new teamSelect(this).ShowDialog();

        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new help(this).ShowDialog();
        }

        private void TimerBtn_Click(object sender, EventArgs e)
        {
            if (timerPress)
            {
                cmd = new Commands();
                if(!cmd.state)
                {
                    cmd.state = false;
                    cmd = null;
                    TimerBtn.Text = "미션 알리미";
                    TimerBtn.BackColor = SystemColors.Control;
                    timerPress = true;
                    return;
                }
                else
                {
                    Commands.StartDetect();
                    TimerBtn.Text = "알리미 취소";
                    TimerBtn.BackColor = Color.Red;
                    timerPress = false;
                }
            }
            else
            {
                cmd.state = false;
                cmd = null;
                TimerBtn.Text = "미션 알리미";
                TimerBtn.BackColor = SystemColors.Control;
                timerPress = true;
            }      
        }

        private void SalSetBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new salSet_Form(this).ShowDialog();
        }
    }
}
