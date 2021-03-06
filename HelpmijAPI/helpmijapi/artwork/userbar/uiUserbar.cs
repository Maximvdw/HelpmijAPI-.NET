﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace mvdw.helpmijapi.artwork.userbar
{
    /// <summary>
    /// Helpmij.nl Userbars
    /// </summary>
    public partial class uiUserbar : UserControl
    {
        /// <summary>
        /// Default Userbar
        /// </summary>
        private UserbarType type = UserbarType.Classic;
        /// <summary>
        /// Userbar Message
        /// </summary>
        private String message = null;
        /// <summary>
        /// Toon userbar voorbeeld
        /// </summary>
        private Boolean preview = false;
        /// <summary>
        /// Userbar arguments
        /// </summary>
        private UserbarArguments args = null;

        /// <summary>
        /// Helpmij.nl Userbars
        /// </summary>
        public uiUserbar()
        {
            InitializeComponent();
            // Basis Userbar
            this.BackgroundImage = resUserbars.UB_Classic_img;
        }

        /// <summary>
        /// Toon Userbar voorbeeld
        /// </summary>
        [Description("Toon Userbar voorbeeld"), Category("ShowPreview")]
        public Boolean ShowPreview
        {
            get
            {
                return preview;
            }
            set
            {
                this.preview = value;
                // Wijzig Image
                if (preview == true)
                {
                    this.BackgroundImage = HelpmijUserbar.GetPreviewUserbar(type);
                }
                else
                {
                    this.args = HelpmijUserbar.GetUserbar(type, message);
                    this.BackgroundImage = args.Userbar;
                }
            }
        }

        /// <summary>
        /// Userbar Text
        /// </summary>
        [Description("Userbar Text"), Category("UBText")]
        public String UBText
        {
            get
            {
                return message;
            }
            set
            {
                // Save val
                this.message = value;
                args.Text = message;
                args = HelpmijUserbar.GenerateUserbar(args);
                this.BackgroundImage = args.Userbar;
            }
        }

        /// <summary>
        /// Verkrijg de Userbar
        /// </summary>
        /// <returns>UserbarArguments</returns>
        public UserbarArguments GetUserbar()
        {
            return args;
        }

        /// <summary>
        /// Basis Userbar
        /// </summary>
        [Description("Basis Userbar"), Category("DefaultUserbar")]
        public UserbarType DefaultUserbar
        {
            get
            {
                return type;
            }
            set
            {
                this.type = value;
                // Wijzig Image
                if (preview == true)
                {
                    this.BackgroundImage = HelpmijUserbar.GetPreviewUserbar(type);
                }
                else
                {
                    this.args = HelpmijUserbar.GetUserbar(type, message);
                    this.BackgroundImage = args.Userbar;
                }
            }
        }

        private void uiUserbar_Load(object sender, EventArgs e)
        {

        }
    }
}
