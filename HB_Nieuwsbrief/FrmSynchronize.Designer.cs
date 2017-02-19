namespace HB_Nieuwsbrief
{
    partial class FrmSynchronize
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
            this.pbSynchronization = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // pbSynchronization
            // 
            this.pbSynchronization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSynchronization.Location = new System.Drawing.Point(0, 0);
            this.pbSynchronization.MarqueeAnimationSpeed = 1;
            this.pbSynchronization.Name = "pbSynchronization";
            this.pbSynchronization.Size = new System.Drawing.Size(541, 33);
            this.pbSynchronization.Step = 1;
            this.pbSynchronization.TabIndex = 0;
            // 
            // FrmSynchronize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 33);
            this.Controls.Add(this.pbSynchronization);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSynchronize";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HB Nieuwsbrief - Synching RAM with MySQL server...";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ProgressBar pbSynchronization;



    }
}