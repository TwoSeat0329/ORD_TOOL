using CirnoLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORD_SAL_v1._0
{
    public partial class help : Form
    {
        Form parentf = null;
        sendMsg s;
        character_Info ch;
        public help(Form mainf)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            parentf = mainf;
            s = sendMsg.getInstance;
            ch = character_Info.Instance;
        }

        private void help_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentf.Show();
            parentf = null;
        }

        private void LegendCalBtn_Click(object sender, EventArgs e)
        {
            string a = Properties.Resources.commonList;
            List<Commonamount> amountlist = JsonConvert.DeserializeObject<List<Commonamount>>(a);
            List<string> charaterdata = new List<string>();
            Double totalcount = 0;
            listView1.Items.Clear();
            ListViewItem item;
            try
            {
                int gc = int.Parse(countTB.Text);
                if (gc > 12)
                {
                    MessageBox.Show("잘못된 값을 입력하셨습니다."); return;
                }
                else if (gc == 1)
                {
                    MessageBox.Show("최소 한 개 이상만 검색이 가능합니다."); return;
                }
                charaterdata = s.GetCharacters(gc);
                foreach (Commonamount amount in amountlist)
                {
                    foreach (string name in charaterdata)
                    {
                        if (amount.characterName == name)
                        {
                            item = new ListViewItem(amount.characterName);
                            item.SubItems.Add(amount.Luppi.ToString());
                            item.SubItems.Add(amount.Zoro.ToString());
                            item.SubItems.Add(amount.Nami.ToString());
                            item.SubItems.Add(amount.Usopp.ToString());
                            item.SubItems.Add(amount.Sanji.ToString());
                            item.SubItems.Add(amount.Chopper.ToString());
                            item.SubItems.Add(amount.Buggy.ToString());
                            item.SubItems.Add(amount.musketeer.ToString());
                            item.SubItems.Add(amount.Swordsman.ToString());
                            item.SubItems.Add(amount.TotalCommonamount.ToString());

                            listView1.Items.Add(item);
                            item = null;
                            totalcount += amount.TotalCommonamount;
                        }
                        else continue;
                    }
                }              
                Double result = Math.Round(totalcount / 39.7, 1);
                s.Send(string.Format("조합 계산 결과 : 약 {0}전설", result));
            }
            catch(Exception ex)
            {
                MessageBox.Show("잘못된 숫자를 입력하셨습니다." + ex);
            }
        }

        private void help_Load(object sender, EventArgs e)
        {
            if (s == null) this.Close();
        }
    }
}
