using ORD_SAL_v1._0;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORD_SAL_v1
{
    public partial class salSet_Form : Form
    {
        Form parentf = null;
        random_Pick s;
        character_Info ch;
        bool fristinit = false;
        int count = 0;
        public salSet_Form(Form mainf)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            parentf = mainf;
            s = random_Pick.getInstance;
            overlapCB.Checked = s.overlap;
            ch = character_Info.Instance;
        }

        private void salSet_Form_Load(object sender, EventArgs e)
        {
            ListViewItem item;
            UnitListView.Items.Clear();
            foreach (var a in ch.chList)
            {
                item = new ListViewItem(a.name);
                item.Checked = a.sel;
                UnitListView.Items.Add(item);       
            }
            fristinit = true;
        }

        private void salSet_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            fristinit = false;
            parentf.Show();
            parentf = null;
        }


        private void overlapCB_Click(object sender, EventArgs e)
        {
            if (overlapCB.Checked)
                s.overlap = true;
            else
                s.overlap = false;
        }

        private void UnitListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (fristinit)
            {
                count = 0;
                foreach (ListViewItem temp in UnitListView.Items)
                {
                    if (temp.Checked)
                        count++;
                }
                if (count < 16)
                {
                    MessageBox.Show("살을 뽑을려면 최소 16개의 유닛이 체크되어야 합니다.");
                    e.Item.Checked = true;
                    return;
                }
                ch.ListCheckChange(e.Item.Index, e.Item.Checked);
            }
            
        }
    }
}
