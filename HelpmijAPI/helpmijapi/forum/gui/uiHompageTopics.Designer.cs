namespace mvdw.helpmijapi.forum.gui
{
    partial class uiHompageTopics
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstTopicsNew = new System.Windows.Forms.ListBox();
            this.tbHompage = new System.Windows.Forms.TabControl();
            this.tbNew = new System.Windows.Forms.TabPage();
            this.tbUnanswered = new System.Windows.Forms.TabPage();
            this.tbUser = new System.Windows.Forms.TabPage();
            this.lstTopicsUnanswered = new System.Windows.Forms.ListBox();
            this.lstTopicsUser = new System.Windows.Forms.ListBox();
            this.tbHompage.SuspendLayout();
            this.tbNew.SuspendLayout();
            this.tbUnanswered.SuspendLayout();
            this.tbUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstTopicsNew
            // 
            this.lstTopicsNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTopicsNew.FormattingEnabled = true;
            this.lstTopicsNew.Location = new System.Drawing.Point(3, 3);
            this.lstTopicsNew.Name = "lstTopicsNew";
            this.lstTopicsNew.Size = new System.Drawing.Size(296, 320);
            this.lstTopicsNew.TabIndex = 0;
            // 
            // tbHompage
            // 
            this.tbHompage.Controls.Add(this.tbNew);
            this.tbHompage.Controls.Add(this.tbUnanswered);
            this.tbHompage.Controls.Add(this.tbUser);
            this.tbHompage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbHompage.Location = new System.Drawing.Point(0, 0);
            this.tbHompage.Name = "tbHompage";
            this.tbHompage.SelectedIndex = 0;
            this.tbHompage.Size = new System.Drawing.Size(310, 352);
            this.tbHompage.TabIndex = 1;
            // 
            // tbNew
            // 
            this.tbNew.Controls.Add(this.lstTopicsNew);
            this.tbNew.Location = new System.Drawing.Point(4, 22);
            this.tbNew.Name = "tbNew";
            this.tbNew.Padding = new System.Windows.Forms.Padding(3);
            this.tbNew.Size = new System.Drawing.Size(302, 326);
            this.tbNew.TabIndex = 0;
            this.tbNew.Text = "Nieuw";
            this.tbNew.UseVisualStyleBackColor = true;
            // 
            // tbUnanswered
            // 
            this.tbUnanswered.Controls.Add(this.lstTopicsUnanswered);
            this.tbUnanswered.Location = new System.Drawing.Point(4, 22);
            this.tbUnanswered.Name = "tbUnanswered";
            this.tbUnanswered.Padding = new System.Windows.Forms.Padding(3);
            this.tbUnanswered.Size = new System.Drawing.Size(302, 326);
            this.tbUnanswered.TabIndex = 1;
            this.tbUnanswered.Text = "Onbeantwoord";
            this.tbUnanswered.UseVisualStyleBackColor = true;
            // 
            // tbUser
            // 
            this.tbUser.Controls.Add(this.lstTopicsUser);
            this.tbUser.Location = new System.Drawing.Point(4, 22);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(302, 326);
            this.tbUser.TabIndex = 2;
            this.tbUser.Text = "Uw vragen";
            this.tbUser.UseVisualStyleBackColor = true;
            // 
            // lstTopicsUnanswered
            // 
            this.lstTopicsUnanswered.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTopicsUnanswered.FormattingEnabled = true;
            this.lstTopicsUnanswered.Location = new System.Drawing.Point(3, 3);
            this.lstTopicsUnanswered.Name = "lstTopicsUnanswered";
            this.lstTopicsUnanswered.Size = new System.Drawing.Size(296, 320);
            this.lstTopicsUnanswered.TabIndex = 1;
            // 
            // lstTopicsUser
            // 
            this.lstTopicsUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTopicsUser.FormattingEnabled = true;
            this.lstTopicsUser.Location = new System.Drawing.Point(0, 0);
            this.lstTopicsUser.Name = "lstTopicsUser";
            this.lstTopicsUser.Size = new System.Drawing.Size(302, 326);
            this.lstTopicsUser.TabIndex = 1;
            // 
            // uiHompageTopics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbHompage);
            this.Name = "uiHompageTopics";
            this.Size = new System.Drawing.Size(310, 352);
            this.tbHompage.ResumeLayout(false);
            this.tbNew.ResumeLayout(false);
            this.tbUnanswered.ResumeLayout(false);
            this.tbUser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstTopicsNew;
        private System.Windows.Forms.TabControl tbHompage;
        private System.Windows.Forms.TabPage tbNew;
        private System.Windows.Forms.TabPage tbUnanswered;
        private System.Windows.Forms.TabPage tbUser;
        private System.Windows.Forms.ListBox lstTopicsUnanswered;
        private System.Windows.Forms.ListBox lstTopicsUser;
    }
}
