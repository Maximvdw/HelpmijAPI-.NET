using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using mvdw.helpmijapi.chat;
using mvdw.helpmijapi.user;
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
        List<IUser> users = new List<IUser>();
        /// <summary>
        /// Helpmij Chat instantie
        /// </summary>
        IChat chat = null;
        /// <summary>
        /// Username Labels
        /// </summary>
        List<Label> usernames = new List<Label>();

        /// <summary>
        /// Nickname Clicked Event
        /// </summary>
        public event NicknameClickedEvent onNicknameClick;

        /// <summary>
        /// Initialize Chat online
        /// </summary>
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
        public List<IUser> OnlineUsers
        {
            get
            {
                return users;
            }
            set
            {
                this.users = value;
                usernames = new List<Label>();
                // Toon de gebruikers
                this.Controls.Clear();
                for (int i = 0; i < users.Count; i++)
                {
                    IUser user = users[i]; // Gebruiker
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
                    lblName.Click += new EventHandler(onLabelClick);
                    lblName.Cursor = Cursors.Hand;
                    // Voeg label toe aan lijst
                    usernames.Add(lblName);
                    this.Controls.Add(lblName);

                    PictureBox picStatus = new PictureBox();
                    picStatus.Image = imgStatus;
                    picStatus.Size = new Size(16, 16);
                    picStatus.Location = new Point(3, (3 * (i + 1)) + (16 * i));
                    this.Controls.Add(picStatus);
                }
            }
        }

        /// <summary>
        /// On label click (username)
        /// </summary>
        /// <param name="sender">Object, Sender</param>
        /// <param name="e">Event Args</param>
        private void onLabelClick(Object sender, EventArgs e)
        {
            // Verkrijg de label
            Label lblSender = (Label)sender;
            int idx = usernames.IndexOf(lblSender);
            IUser user = users[idx];
            // Invoke Event
            if (onNicknameClick != null)
                onNicknameClick(this, new NicknameClickedArgs(user));
        }
    }

    /// <summary>
    /// Nickname Clicked Event handler
    /// </summary>
    /// <param name="sender">Object - Sender</param>
    /// <param name="e">NicknameClicked Event Args</param>
    public delegate void NicknameClickedEvent(Object sender, NicknameClickedArgs e);

    /// <summary>
    /// Nickname clicked Event args
    /// </summary>
    public class NicknameClickedArgs : EventArgs
    {
        /// <summary>
        /// Clicked User
        /// </summary>
        IUser user = null;

        /// <summary>
        /// Maak een nieuwe Nickname Clicked Argument
        /// </summary>
        /// <param name="user"></param>
        public NicknameClickedArgs(IUser user)
        {
            this.user = user;
        }

        /// <summary>
        /// Verkrijg de gebruiker
        /// </summary>
        /// <returns>IUser - User</returns>
        public IUser GetUser()
        {
            return user;
        }
    }
}
