namespace mvdw.helpmijapi.chat.gui
{
    partial class uiChatOnline
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uiChatOnline));
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.mUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.visitekaartjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.priveberichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "status_away.png");
            this.imgList.Images.SetKeyName(1, "status_busy.png");
            this.imgList.Images.SetKeyName(2, "status_offline.png");
            this.imgList.Images.SetKeyName(3, "status_online.png");
            // 
            // mUser
            // 
            this.mUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visitekaartjeToolStripMenuItem,
            this.priveberichtToolStripMenuItem});
            this.mUser.Name = "mUser";
            this.mUser.Size = new System.Drawing.Size(153, 70);
            // 
            // visitekaartjeToolStripMenuItem
            // 
            this.visitekaartjeToolStripMenuItem.Name = "visitekaartjeToolStripMenuItem";
            this.visitekaartjeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.visitekaartjeToolStripMenuItem.Text = "&Visitekaartje";
            // 
            // priveberichtToolStripMenuItem
            // 
            this.priveberichtToolStripMenuItem.Name = "priveberichtToolStripMenuItem";
            this.priveberichtToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.priveberichtToolStripMenuItem.Text = "&Privebericht";
            // 
            // uiChatOnline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Name = "uiChatOnline";
            this.Size = new System.Drawing.Size(167, 111);
            this.mUser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ContextMenuStrip mUser;
        private System.Windows.Forms.ToolStripMenuItem visitekaartjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem priveberichtToolStripMenuItem;
    }
}
