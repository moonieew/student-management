namespace QlySV
{
    partial class AvgScoreByCouseForm
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
            this.dataGridViewAvg = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAvg)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAvg
            // 
            this.dataGridViewAvg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAvg.BackgroundColor = System.Drawing.Color.MistyRose;
            this.dataGridViewAvg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAvg.Location = new System.Drawing.Point(14, 31);
            this.dataGridViewAvg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewAvg.Name = "dataGridViewAvg";
            this.dataGridViewAvg.Size = new System.Drawing.Size(491, 265);
            this.dataGridViewAvg.TabIndex = 0;
            // 
            // AvgScoreByCouseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(535, 331);
            this.Controls.Add(this.dataGridViewAvg);
            this.Font = new System.Drawing.Font("SVN-Abril Fatface", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AvgScoreByCouseForm";
            this.Text = "AvgScoreByCouseForm";
            this.Load += new System.EventHandler(this.AvgScoreByCouseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAvg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAvg;
    }
}