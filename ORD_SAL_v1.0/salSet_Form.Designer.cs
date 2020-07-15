namespace ORD_SAL_v1
{
    partial class salSet_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(salSet_Form));
            this.overlapCB = new System.Windows.Forms.CheckBox();
            this.UnitListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // overlapCB
            // 
            this.overlapCB.AutoSize = true;
            this.overlapCB.Location = new System.Drawing.Point(13, 13);
            this.overlapCB.Name = "overlapCB";
            this.overlapCB.Size = new System.Drawing.Size(132, 16);
            this.overlapCB.TabIndex = 0;
            this.overlapCB.Text = "전판 중복 불가 설정";
            this.overlapCB.UseVisualStyleBackColor = true;
            this.overlapCB.Click += new System.EventHandler(this.overlapCB_Click);
            // 
            // UnitListView
            // 
            this.UnitListView.CheckBoxes = true;
            this.UnitListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.UnitListView.HideSelection = false;
            this.UnitListView.Location = new System.Drawing.Point(12, 53);
            this.UnitListView.Name = "UnitListView";
            this.UnitListView.Size = new System.Drawing.Size(206, 385);
            this.UnitListView.TabIndex = 1;
            this.UnitListView.UseCompatibleStateImageBehavior = false;
            this.UnitListView.View = System.Windows.Forms.View.Details;
            this.UnitListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.UnitListView_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "이름";
            this.columnHeader1.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "유닛 목록";
            // 
            // salSet_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UnitListView);
            this.Controls.Add(this.overlapCB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "salSet_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "유닛 수정";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.salSet_Form_FormClosing);
            this.Load += new System.EventHandler(this.salSet_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox overlapCB;
        private System.Windows.Forms.ListView UnitListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label1;
    }
}