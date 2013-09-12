using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using mvdw.helpmijapi.chat;
using mvdw.helpmijapi.gebruiker;
using mvdw.helpmij.utils;

namespace mvdw.helpmijapi.chat.gui
{
    /// <summary>
    /// Helpmij Chat online users
    /// </summary>
    public partial class uiChatOnline : UserControl
    {
        /// <summary>
        /// Gebruikers online
        /// </summary>
        List<IGebruiker> users = new List<IGebruiker>();
        /// <summary>
        /// Helpmij Chat instantie
        /// </summary>
        IChat chat = null;

        public uiChatOnline()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Set de chat instantie
        /// </summary>
        /// <param name="chat"><IChat chat/param>
        public void SetChat(IChat chat)
        {
            this.chat = chat;
        }

        /// <summary>
        /// Online gebruikers op de chat
        /// </summary>
        public List<IGebruiker> OnlineUsers
        {
            get
            {
                return users;
            }
            set
            {
                this.users = value;
                // Toon de gebruikers
                this.Controls.Clear();
                for (int i = 0; i < users.Count; i++)
                {
                    IGebruiker user = users[i]; // Gebruiker
                    Image imgStatus = imgList.Images["status_online.png"];
                    // Verkrijg de status
                    UserStatus status = user.GetUserStatus();
                    switch (status)
                    {
                        case UserStatus.Online:
                            imgStatus = imgList.Images["status_online.png"];
                            break;
                        case UserStatus.Offline:
                            imgStatus = imgList.Images["status_offline.png"];
                            break;
                        case UserStatus.Away:
                            imgStatus = imgList.Images["status_away.png"];
                            break;
                        case UserStatus.Busy:
                            imgStatus = imgList.Images["status_busy.png"];
                            break;
                    }
                    String nickname = user.GetNickname(); // Nickname

                    // Maak controls aan
                    Label lblName = new Label();
                    lblName.Text = nickname;
                    Font font = UtilsFont.GetEmbeddedFont(UtilsFont.HMFont.Myriad, FontStyle.Regular, 10);
                    lblName.Font = font;
                    lblName.Location = new Point(25, (3 * (i + 1)) + (16 * i));
                    this.Controls.Add(lblName);

                    PictureBox picStatus = new PictureBox();
                    picStatus.Image = imgStatus;
                    picStatus.Size = new Size(16, 16);
                    picStatus.Location = new Point(3, (3 * (i + 1)) + (16 * i));
                    this.Controls.Add(picStatus);
                }
            }
        }
    }
}
