namespace mvdw.helpmijapi.forum.gui
{
    partial class uiComment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uiComment));
            this.lblName = new System.Windows.Forms.Label();
            this.rtfComment = new System.Windows.Forms.RichTextBox();
            this.lnlTitle = new System.Windows.Forms.Label();
            this.avatar = new mvdw.helpmijapi.gebruiker.gui.uiGebruikerAvatar();
            this.lblTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(3, 85);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(79, 16);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "<USER>";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rtfComment
            // 
            this.rtfComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtfComment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtfComment.Location = new System.Drawing.Point(92, 25);
            this.rtfComment.Name = "rtfComment";
            this.rtfComment.Size = new System.Drawing.Size(486, 187);
            this.rtfComment.TabIndex = 2;
            this.rtfComment.Text = "";
            // 
            // lnlTitle
            // 
            this.lnlTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lnlTitle.BackColor = System.Drawing.Color.Transparent;
            this.lnlTitle.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnlTitle.Location = new System.Drawing.Point(98, 3);
            this.lnlTitle.Name = "lnlTitle";
            this.lnlTitle.Size = new System.Drawing.Size(357, 24);
            this.lnlTitle.TabIndex = 3;
            this.lnlTitle.Text = "<TITLE>";
            this.lnlTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // avatar
            // 
            this.avatar.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avatar.Location = new System.Drawing.Point(3, 3);
            this.avatar.Name = "avatar";
            this.avatar.Size = new System.Drawing.Size(79, 79);
            this.avatar.TabIndex = 0;
            this.avatar.UserID = 1;
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(461, 3);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(117, 24);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "<TIMESTAMP>";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lnlTitle);
            this.Controls.Add(this.rtfComment);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.avatar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "uiComment";
            this.Size = new System.Drawing.Size(593, 226);
            this.ResumeLayout(false);

        }

        #endregion

        private gebruiker.gui.uiGebruikerAvatar avatar;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.RichTextBox rtfComment;
        private System.Windows.Forms.Label lnlTitle;
        private System.Windows.Forms.Label lblTime;
    }
}
