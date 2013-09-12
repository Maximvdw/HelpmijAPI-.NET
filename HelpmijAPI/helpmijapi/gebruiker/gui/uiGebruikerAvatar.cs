using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using mvdw.helpmijapi.gebruiker;
using mvdw.helpmij.gebruiker;
using mvdw.helpmijapi;
using System.Threading;

namespace mvdw.helpmijapi.gebruiker.gui
{
    public partial class uiGebruikerAvatar : UserControl
    {
        /// <summary>
        /// Gebruiker
        /// </summary>
        private IGebruiker user = Helpmij.GetUser(0);

        public uiGebruikerAvatar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get/Set de gebruikers ID
        /// </summary>
        [Description("Gebruikers ID van de avatar"), Category("Gebruikers ID")]
        public int UserID
        {
            get
            {
                return user.GetUserID();
            }
            set
            {
                user = Helpmij.GetUser(value);
                Thread thUpdate = new Thread(() => RefreshImage());
                thUpdate.Start(); // Start the thread
            }
        }

        /// <summary>
        /// Refresh Image
        /// </summary>
        public void RefreshImage()
        {
            Image img = user.GetAvatar();
            if (img.Width != 1)
            {
                pic.Image = img;
                pic.BackColor = Color.White;
            }
            else
            {
                pic.BackColor = Color.FromArgb(215,215,215);
                pic.Image = mvdw.Properties.Resources.Avatar;
            }
        }
    }
}
