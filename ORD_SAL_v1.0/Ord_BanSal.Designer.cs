namespace ORD_SAL_v1._0
{
    partial class Ord_BanSal
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ord_BanSal));
            this.startBtn = new System.Windows.Forms.Button();
            this.helpBtn = new System.Windows.Forms.Button();
            this.salCB1 = new System.Windows.Forms.CheckBox();
            this.salCB2 = new System.Windows.Forms.CheckBox();
            this.saveLB = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.setBtn = new System.Windows.Forms.Button();
            this.salCB3 = new System.Windows.Forms.CheckBox();
            this.TimerBtn = new System.Windows.Forms.Button();
            this.SalSetBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(104, 72);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "시작";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // helpBtn
            // 
            this.helpBtn.Location = new System.Drawing.Point(13, 72);
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Size = new System.Drawing.Size(75, 23);
            this.helpBtn.TabIndex = 1;
            this.helpBtn.Text = "전설계산기";
            this.helpBtn.UseVisualStyleBackColor = true;
            this.helpBtn.Click += new System.EventHandler(this.helpBtn_Click);
            // 
            // salCB1
            // 
            this.salCB1.AutoSize = true;
            this.salCB1.Location = new System.Drawing.Point(96, 12);
            this.salCB1.Name = "salCB1";
            this.salCB1.Size = new System.Drawing.Size(82, 16);
            this.salCB1.TabIndex = 3;
            this.salCB1.Text = "6개 살리기";
            this.salCB1.UseVisualStyleBackColor = true;
            this.salCB1.Click += new System.EventHandler(this.salCB1_Click);
            // 
            // salCB2
            // 
            this.salCB2.AutoSize = true;
            this.salCB2.Location = new System.Drawing.Point(184, 12);
            this.salCB2.Name = "salCB2";
            this.salCB2.Size = new System.Drawing.Size(82, 16);
            this.salCB2.TabIndex = 4;
            this.salCB2.Text = "8개 살리기";
            this.salCB2.UseVisualStyleBackColor = true;
            this.salCB2.Click += new System.EventHandler(this.salCB2_Click);
            // 
            // saveLB
            // 
            this.saveLB.AutoSize = true;
            this.saveLB.Location = new System.Drawing.Point(13, 46);
            this.saveLB.Name = "saveLB";
            this.saveLB.Size = new System.Drawing.Size(77, 12);
            this.saveLB.TabIndex = 5;
            this.saveLB.Text = "세이브 횟수 :";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(104, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(75, 21);
            this.textBox1.TabIndex = 7;
            this.textBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseClick);
            // 
            // setBtn
            // 
            this.setBtn.Location = new System.Drawing.Point(191, 72);
            this.setBtn.Name = "setBtn";
            this.setBtn.Size = new System.Drawing.Size(75, 23);
            this.setBtn.TabIndex = 2;
            this.setBtn.Text = "팀 설정";
            this.setBtn.UseVisualStyleBackColor = true;
            this.setBtn.Click += new System.EventHandler(this.setBtn_Click);
            // 
            // salCB3
            // 
            this.salCB3.AutoSize = true;
            this.salCB3.Location = new System.Drawing.Point(8, 12);
            this.salCB3.Name = "salCB3";
            this.salCB3.Size = new System.Drawing.Size(82, 16);
            this.salCB3.TabIndex = 8;
            this.salCB3.Text = "4개 살리기";
            this.salCB3.UseVisualStyleBackColor = true;
            this.salCB3.Click += new System.EventHandler(this.salCB3_Click);
            // 
            // TimerBtn
            // 
            this.TimerBtn.Location = new System.Drawing.Point(13, 104);
            this.TimerBtn.Name = "TimerBtn";
            this.TimerBtn.Size = new System.Drawing.Size(253, 23);
            this.TimerBtn.TabIndex = 9;
            this.TimerBtn.Text = "미션 알리미";
            this.TimerBtn.UseVisualStyleBackColor = true;
            this.TimerBtn.Click += new System.EventHandler(this.TimerBtn_Click);
            // 
            // SalSetBtn
            // 
            this.SalSetBtn.Location = new System.Drawing.Point(191, 43);
            this.SalSetBtn.Name = "SalSetBtn";
            this.SalSetBtn.Size = new System.Drawing.Size(75, 23);
            this.SalSetBtn.TabIndex = 10;
            this.SalSetBtn.Text = "유닛 목록";
            this.SalSetBtn.UseVisualStyleBackColor = true;
            this.SalSetBtn.Click += new System.EventHandler(this.SalSetBtn_Click);
            // 
            // Ord_BanSal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 134);
            this.Controls.Add(this.SalSetBtn);
            this.Controls.Add(this.TimerBtn);
            this.Controls.Add(this.salCB3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.saveLB);
            this.Controls.Add(this.salCB2);
            this.Controls.Add(this.salCB1);
            this.Controls.Add(this.setBtn);
            this.Controls.Add(this.helpBtn);
            this.Controls.Add(this.startBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ord_BanSal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button helpBtn;
        private System.Windows.Forms.CheckBox salCB1;
        private System.Windows.Forms.CheckBox salCB2;
        private System.Windows.Forms.Label saveLB;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button setBtn;
        private System.Windows.Forms.CheckBox salCB3;
        private System.Windows.Forms.Button TimerBtn;
        private System.Windows.Forms.Button SalSetBtn;
    }
}

