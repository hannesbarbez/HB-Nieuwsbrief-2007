namespace HB_Nieuwsbrief
{
    partial class FrmConfiguration
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbDatabase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbRow = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbTable = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFont = new System.Windows.Forms.Button();
            this.btnBrowseLogo = new System.Windows.Forms.Button();
            this.btnBrowseBackground = new System.Windows.Forms.Button();
            this.tbBackground = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbLogo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbDatabase);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbServer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 71);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connectiviteit";
            // 
            // tbDatabase
            // 
            this.tbDatabase.Location = new System.Drawing.Point(86, 19);
            this.tbDatabase.Name = "tbDatabase";
            this.tbDatabase.Size = new System.Drawing.Size(158, 20);
            this.tbDatabase.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Database";
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(86, 41);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(158, 20);
            this.tbServer.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "MySQL server";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbPassword);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbUser);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(267, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 71);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Personalia";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(96, 41);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(158, 20);
            this.tbPassword.TabIndex = 4;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Paswoord";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(96, 19);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(158, 20);
            this.tbUser.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Gebruikersnaam";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbRow);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.tbTable);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(533, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(209, 71);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Localisatie";
            // 
            // tbRow
            // 
            this.tbRow.Location = new System.Drawing.Point(46, 41);
            this.tbRow.Name = "tbRow";
            this.tbRow.Size = new System.Drawing.Size(158, 20);
            this.tbRow.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Rij";
            // 
            // tbTable
            // 
            this.tbTable.Location = new System.Drawing.Point(46, 19);
            this.tbTable.Name = "tbTable";
            this.tbTable.Size = new System.Drawing.Size(158, 20);
            this.tbTable.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tabel";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(602, 164);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(68, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 7F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.Location = new System.Drawing.Point(18, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(217, 14);
            this.label7.TabIndex = 17;
            this.label7.Text = "©2009 Hannes Barbez. | hannesbarbez@hotmail.com";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(669, 164);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Annuleren";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.panel1);
            this.groupBox4.Controls.Add(this.btnFont);
            this.groupBox4.Controls.Add(this.btnBrowseLogo);
            this.groupBox4.Controls.Add(this.btnBrowseBackground);
            this.groupBox4.Controls.Add(this.tbBackground);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.tbLogo);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(12, 89);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(730, 69);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Afbeeldingen";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(583, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(4, 44);
            this.panel1.TabIndex = 24;
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(590, 16);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(135, 45);
            this.btnFont.TabIndex = 23;
            this.btnFont.Text = "&Lettertype && Kleur...";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // btnBrowseLogo
            // 
            this.btnBrowseLogo.Location = new System.Drawing.Point(77, 39);
            this.btnBrowseLogo.Name = "btnBrowseLogo";
            this.btnBrowseLogo.Size = new System.Drawing.Size(81, 23);
            this.btnBrowseLogo.TabIndex = 20;
            this.btnBrowseLogo.Text = "Selecteren...";
            this.btnBrowseLogo.UseVisualStyleBackColor = true;
            this.btnBrowseLogo.Click += new System.EventHandler(this.btnBrowseLogo_Click);
            // 
            // btnBrowseBackground
            // 
            this.btnBrowseBackground.Location = new System.Drawing.Point(77, 17);
            this.btnBrowseBackground.Name = "btnBrowseBackground";
            this.btnBrowseBackground.Size = new System.Drawing.Size(81, 23);
            this.btnBrowseBackground.TabIndex = 19;
            this.btnBrowseBackground.Text = "Selecteren...";
            this.btnBrowseBackground.UseVisualStyleBackColor = true;
            this.btnBrowseBackground.Click += new System.EventHandler(this.btnBrowseBackground_Click);
            // 
            // tbBackground
            // 
            this.tbBackground.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbBackground.Enabled = false;
            this.tbBackground.Location = new System.Drawing.Point(164, 22);
            this.tbBackground.Name = "tbBackground";
            this.tbBackground.ReadOnly = true;
            this.tbBackground.Size = new System.Drawing.Size(413, 13);
            this.tbBackground.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Achtergrond";
            // 
            // tbLogo
            // 
            this.tbLogo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLogo.Enabled = false;
            this.tbLogo.Location = new System.Drawing.Point(164, 44);
            this.tbLogo.Name = "tbLogo";
            this.tbLogo.ReadOnly = true;
            this.tbLogo.Size = new System.Drawing.Size(413, 13);
            this.tbLogo.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Logo";
            // 
            // lblError
            // 
            this.lblError.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblError.Font = new System.Drawing.Font("Arial Narrow", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(215, 173);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(381, 13);
            this.lblError.TabIndex = 23;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmConfiguration
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(750, 194);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfiguration";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HB Nieuwsbrief - Instellingen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmConfiguration_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbDatabase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbRow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbTable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbBackground;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbLogo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnBrowseBackground;
        private System.Windows.Forms.Button btnBrowseLogo;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbPassword;

    }
}