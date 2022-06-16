namespace QlySV
{
    partial class StacticsForm
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
            this.PanelTotal = new System.Windows.Forms.Panel();
            this.LabelTotal = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PanelMale = new System.Windows.Forms.Panel();
            this.LabelMale = new System.Windows.Forms.Label();
            this.PanelFemale = new System.Windows.Forms.Panel();
            this.LabelFemale = new System.Windows.Forms.Label();
            this.PanelTotal.SuspendLayout();
            this.PanelMale.SuspendLayout();
            this.PanelFemale.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelTotal
            // 
            this.PanelTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.PanelTotal.Controls.Add(this.LabelTotal);
            this.PanelTotal.Controls.Add(this.panel3);
            this.PanelTotal.Location = new System.Drawing.Point(0, 0);
            this.PanelTotal.Name = "PanelTotal";
            this.PanelTotal.Size = new System.Drawing.Size(361, 100);
            this.PanelTotal.TabIndex = 0;
            // 
            // LabelTotal
            // 
            this.LabelTotal.AutoSize = true;
            this.LabelTotal.BackColor = System.Drawing.Color.Transparent;
            this.LabelTotal.Font = new System.Drawing.Font("SVN-Batman Forever Alternate", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTotal.ForeColor = System.Drawing.Color.Lime;
            this.LabelTotal.Location = new System.Drawing.Point(67, 39);
            this.LabelTotal.Name = "LabelTotal";
            this.LabelTotal.Size = new System.Drawing.Size(99, 18);
            this.LabelTotal.TabIndex = 3;
            this.LabelTotal.Text = "Student";
            this.LabelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelTotal.MouseEnter += new System.EventHandler(this.LabelTotal_MouseEnter);
            this.LabelTotal.MouseLeave += new System.EventHandler(this.LabelTotal_MouseLeave);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(178, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(183, 113);
            this.panel3.TabIndex = 2;
            // 
            // PanelMale
            // 
            this.PanelMale.BackColor = System.Drawing.Color.YellowGreen;
            this.PanelMale.Controls.Add(this.LabelMale);
            this.PanelMale.Location = new System.Drawing.Point(0, 100);
            this.PanelMale.Name = "PanelMale";
            this.PanelMale.Size = new System.Drawing.Size(183, 113);
            this.PanelMale.TabIndex = 1;
            // 
            // LabelMale
            // 
            this.LabelMale.AutoSize = true;
            this.LabelMale.Font = new System.Drawing.Font("SVN-Batman Forever Alternate", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMale.ForeColor = System.Drawing.Color.Magenta;
            this.LabelMale.Location = new System.Drawing.Point(22, 49);
            this.LabelMale.Name = "LabelMale";
            this.LabelMale.Size = new System.Drawing.Size(81, 18);
            this.LabelMale.TabIndex = 4;
            this.LabelMale.Text = "label2";
            this.LabelMale.MouseLeave += new System.EventHandler(this.LabelMale_MouseLeave);
            // 
            // PanelFemale
            // 
            this.PanelFemale.BackColor = System.Drawing.Color.Violet;
            this.PanelFemale.Controls.Add(this.LabelFemale);
            this.PanelFemale.Location = new System.Drawing.Point(181, 100);
            this.PanelFemale.Name = "PanelFemale";
            this.PanelFemale.Size = new System.Drawing.Size(183, 113);
            this.PanelFemale.TabIndex = 2;
            // 
            // LabelFemale
            // 
            this.LabelFemale.AutoSize = true;
            this.LabelFemale.Font = new System.Drawing.Font("SVN-Batman Forever Alternate", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFemale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.LabelFemale.Location = new System.Drawing.Point(23, 49);
            this.LabelFemale.Name = "LabelFemale";
            this.LabelFemale.Size = new System.Drawing.Size(79, 18);
            this.LabelFemale.TabIndex = 5;
            this.LabelFemale.Text = "label3";
            this.LabelFemale.MouseEnter += new System.EventHandler(this.LabelFemale_MouseEnter);
            this.LabelFemale.MouseLeave += new System.EventHandler(this.LabelFemale_MouseLeave);
            // 
            // StacticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 213);
            this.Controls.Add(this.PanelFemale);
            this.Controls.Add(this.PanelMale);
            this.Controls.Add(this.PanelTotal);
            this.Name = "StacticsForm";
            this.Text = "StacticsForm";
            this.Load += new System.EventHandler(this.StacticsForm_Load_1);
            this.PanelTotal.ResumeLayout(false);
            this.PanelTotal.PerformLayout();
            this.PanelMale.ResumeLayout(false);
            this.PanelMale.PerformLayout();
            this.PanelFemale.ResumeLayout(false);
            this.PanelFemale.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Panel PanelTotal;
        public System.Windows.Forms.Panel PanelMale;
        public System.Windows.Forms.Panel PanelFemale;
        private System.Windows.Forms.Label LabelTotal;
        private System.Windows.Forms.Label LabelMale;
        private System.Windows.Forms.Label LabelFemale;
    }
}