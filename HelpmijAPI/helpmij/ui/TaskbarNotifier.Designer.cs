namespace mvdw.helpmij.ui
{
    partial class TaskbarNotifier
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
            this.lnkClose = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lnkClose
            // 
            this.lnkClose.AutoSize = true;
            this.lnkClose.BackColor = System.Drawing.Color.Transparent;
            this.lnkClose.Font = new System.Drawing.Font("Myriad Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkClose.Location = new System.Drawing.Point(199, 9);
            this.lnkClose.Name = "lnkClose";
            this.lnkClose.Size = new System.Drawing.Size(45, 16);
            this.lnkClose.TabIndex = 0;
            this.lnkClose.TabStop = true;
            this.lnkClose.Text = "Sluiten";
            this.lnkClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClose_LinkClicked);
            // 
            // TaskbarNotifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::mvdw.Properties.Resources.skin1;
            this.ClientSize = new System.Drawing.Size(250, 150);
            this.Controls.Add(this.lnkClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TaskbarNotifier";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Helpmij Pop-up";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkClose;
    }
}