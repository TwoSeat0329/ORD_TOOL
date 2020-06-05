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
    public partial class teamSelect : Form
    {
        Form parentf = null;
        random_Pick rp;
        sendMsg s;
        string[] a;
        int[] arr;
        struct Dice
        {
            public string name;
            public int index;
        }
        List<Dice> data;
        public teamSelect(Form mainf)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            parentf = mainf;
            rp = random_Pick.getInstance;
            s = sendMsg.getInstance;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            data = new List<Dice>();
            a = textBox1.Text.Split(',');
            arr = rp.randomteam(a.Length);
            string smsg = null;
            //LstEventList = LstEventList.OrderBy(sel => sel.EventDate).ToList();
            Dice dicedata = new Dice();

            for(int i =0; i< a.Length; i++)
            {
                dicedata.index = arr[i];
                dicedata.name = a[i];
                data.Add(dicedata);
            }

            data = data.OrderBy(x => x.index).ToList();


            for (int i = 0; i < a.Length; i++)
            {                    
                smsg += data[i].name + ":" + data[i].index+" ";
                if ((i+1) % 3 == 0)
                    smsg += " |  ";
            }
            s.Send("========== 팀 랜덤 다이스 결과 ==========");
            DelaySystem(1000);
            s.Send(smsg);
            a.Initialize();
            arr.Initialize();
            data.Clear();
        }

        private void teamSelect_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentf.Show();
            parentf = null;
        }
        private void DelaySystem(int MS) 
        { /* 함수명 : DelaySystem * 1000ms = 1초 * 전달인자 : 얼마나 지연시킬것인가에 대한 변수 * */ 
            DateTime dtAfter = DateTime.Now; TimeSpan dtDuration = new TimeSpan(0, 0, 0, 0, MS); 
            DateTime dtThis = dtAfter.Add(dtDuration); 
            while (dtThis >= dtAfter) 
            { 
                //DoEvent () 를 사용 해서 지연 시간 동안 
                //버튼 클릭 이벤트 및 다른 윈도우 이벤트를 받을 수 있게끔 하는 역할 
                //없으면 지연 동안 다른 이벤트를 받지 못함... System.Windows.Forms.Application.DoEvents(); 
                //현재 시간 얻어 오기... 
                dtAfter = DateTime.Now; 
            } 
        }

        private void teamSelect_Load(object sender, EventArgs e)
        {
            if (s == null) this.Close();
        }
    }
}
    
