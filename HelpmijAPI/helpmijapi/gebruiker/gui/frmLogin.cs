/*
 * Unofficial Helpmij.nl Aplication Interface
 * Copyright (C) 2009 Maxim Van de Wynckel <Maximvdw> and contributors
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using mvdw.helpmijapi.gebruiker.events;
using mvdw.helpmijapi.gebruiker;

namespace mvdw.helpmijapi.gebruiker.gui
{
    /// <summary>
    /// Helpmij Login GUI Form
    /// </summary>
    public partial class frmLogin : Form
    {
        /// <summary>
        /// Verkrijg gebruikers data
        /// </summary>
        private Boolean getUserData = false;
        /// <summary>
        /// Helpmij Gebruiker
        /// </summary>
        private Gebruiker user = null;
        /// <summary>
        /// Helpmij GebruikerData
        /// </summary>
        private GebruikerData userData = null;

        /// <summary>
        /// Helpmij Login Gui Form
        /// </summary>
        public frmLogin(Boolean getUserData)
        {
            InitializeComponent();
            this.getUserData = getUserData;
            // Register events
            hmLogin.onLoginSuccess += new LoginSuccessEventHandler(onLoginSuccess);
        }

        /// <summary>
        /// Verkrijg de gebruiker
        /// </summary>
        /// <returns>Gebruiker</returns>
        public Gebruiker GetUser()
        {
            return user;
        }

        /// <summary>
        /// Verkrijg gebruikers gegevens
        /// </summary>
        /// <returns>GebruikerData</returns>
        public GebruikerData GetUserData()
        {
            return userData;
        }

        /// <summary>
        /// Inloggen
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Event Arguments</param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Log in op Helpmij.nl
            btnLogin.Text = "Bezig...";
            btnLogin.Enabled = false;
            hmLogin.Enabled = false;
            hmLogin.Inloggen();
        }


        /// <summary>
        /// Annuleren
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Event Arguments</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Cancel Login
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// On Login Success Event
        /// </summary>
        /// <param name="e">Event Arguments</param>
        /// <param name="sender">Sender</param>
        private void onLoginSuccess(Object sender, LoginSuccessEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new LoginSuccessEventHandler(onLoginSuccess), new Object[] { sender, e });
            }
            else
            {
                // Login success
                this.DialogResult = DialogResult.OK;
                if (getUserData)
                    userData = e.GetUserData();
                user = e.GetUser();
                this.Close();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
