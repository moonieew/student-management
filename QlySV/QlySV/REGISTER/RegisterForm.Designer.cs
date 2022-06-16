namespace QlySV
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.lbl_register = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_register = new System.Windows.Forms.Button();
            this.txb_userName = new System.Windows.Forms.TextBox();
            this.txb_lName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txb_fName = new System.Windows.Forms.TextBox();
            this.txb_pwd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.picBox_avatar = new System.Windows.Forms.PictureBox();
            this.btn_uploadPic = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_register
            // 
            this.lbl_register.AutoSize = true;
            this.lbl_register.BackColor = System.Drawing.Color.Transparent;
            this.lbl_register.Font = new System.Drawing.Font("MV Boli", 10.75F, System.Drawing.FontStyle.Bold);
            this.lbl_register.ForeColor = System.Drawing.Color.White;
            this.lbl_register.Location = new System.Drawing.Point(72, 435);
            this.lbl_register.Name = "lbl_register";
            this.lbl_register.Size = new System.Drawing.Size(231, 20);
            this.lbl_register.TabIndex = 17;
            this.lbl_register.Text = "Already have account? Login";
            this.lbl_register.Click += new System.EventHandler(this.lbl_register_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("SVN-Adam Gorry", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(127, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 30);
            this.label3.TabIndex = 16;
            this.label3.Text = "REGISTER";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_register
            // 
            this.btn_register.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_register.FlatAppearance.BorderSize = 0;
            this.btn_register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_register.Font = new System.Drawing.Font("SVN-A Love Of Thunder", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_register.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_register.Location = new System.Drawing.Point(86, 387);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(205, 34);
            this.btn_register.TabIndex = 15;
            this.btn_register.Text = "Sign Up";
            this.btn_register.UseVisualStyleBackColor = false;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // txb_userName
            // 
            this.txb_userName.Location = new System.Drawing.Point(132, 170);
            this.txb_userName.Name = "txb_userName";
            this.txb_userName.PasswordChar = '*';
            this.txb_userName.Size = new System.Drawing.Size(119, 20);
            this.txb_userName.TabIndex = 13;
            // 
            // txb_lName
            // 
            this.txb_lName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txb_lName.Location = new System.Drawing.Point(132, 130);
            this.txb_lName.Name = "txb_lName";
            this.txb_lName.Size = new System.Drawing.Size(159, 20);
            this.txb_lName.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("MV Boli", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MV Boli", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Username";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::QlySV.Properties.Resources.black_male_user_symbol;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::QlySV.Properties.Resources.black_male_user_symbol;
            this.pictureBox1.Location = new System.Drawing.Point(163, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 33);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("MV Boli", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "FirstName";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("MV Boli", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "LastName";
            // 
            // txb_fName
            // 
            this.txb_fName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txb_fName.Location = new System.Drawing.Point(132, 93);
            this.txb_fName.Name = "txb_fName";
            this.txb_fName.Size = new System.Drawing.Size(159, 20);
            this.txb_fName.TabIndex = 20;
            // 
            // txb_pwd
            // 
            this.txb_pwd.Location = new System.Drawing.Point(132, 207);
            this.txb_pwd.Name = "txb_pwd";
            this.txb_pwd.PasswordChar = '*';
            this.txb_pwd.Size = new System.Drawing.Size(119, 20);
            this.txb_pwd.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("MV Boli", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(51, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "Picture";
            // 
            // picBox_avatar
            // 
            this.picBox_avatar.Location = new System.Drawing.Point(132, 245);
            this.picBox_avatar.Name = "picBox_avatar";
            this.picBox_avatar.Size = new System.Drawing.Size(119, 92);
            this.picBox_avatar.TabIndex = 23;
            this.picBox_avatar.TabStop = false;
            // 
            // btn_uploadPic
            // 
            this.btn_uploadPic.Location = new System.Drawing.Point(163, 343);
            this.btn_uploadPic.Name = "btn_uploadPic";
            this.btn_uploadPic.Size = new System.Drawing.Size(55, 23);
            this.btn_uploadPic.TabIndex = 24;
            this.btn_uploadPic.Text = "Upload";
            this.btn_uploadPic.UseVisualStyleBackColor = true;
            this.btn_uploadPic.Click += new System.EventHandler(this.btn_uploadPic_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(365, 464);
            this.Controls.Add(this.btn_uploadPic);
            this.Controls.Add(this.picBox_avatar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txb_pwd);
            this.Controls.Add(this.txb_fName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_register);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_register);
            this.Controls.Add(this.txb_userName);
            this.Controls.Add(this.txb_lName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_avatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_register;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_register;
        private System.Windows.Forms.TextBox txb_userName;
        private System.Windows.Forms.TextBox txb_lName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txb_fName;
        private System.Windows.Forms.TextBox txb_pwd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox picBox_avatar;
        private System.Windows.Forms.Button btn_uploadPic;
    }
}