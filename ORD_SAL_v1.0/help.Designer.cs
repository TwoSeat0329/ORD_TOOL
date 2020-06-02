namespace ORD_SAL_v1._0
{
    partial class help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(help));
            this.LegendCalBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LegendCalBtn
            // 
            this.LegendCalBtn.Location = new System.Drawing.Point(697, 12);
            this.LegendCalBtn.Name = "LegendCalBtn";
            this.LegendCalBtn.Size = new System.Drawing.Size(75, 23);
            this.LegendCalBtn.TabIndex = 0;
            this.LegendCalBtn.Text = "전설계산기";
            this.LegendCalBtn.UseVisualStyleBackColor = true;
            this.LegendCalBtn.Click += new System.EventHandler(this.LegendCalBtn_Click);
            // 
            // help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.LegendCalBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "help";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "제작자:Twoseat.aC 제작도움:평타천국(BlacklightsC)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.help_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LegendCalBtn;
    }
}