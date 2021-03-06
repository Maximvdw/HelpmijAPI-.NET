﻿/*
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
using mvdw.helpmijapi.user.events;
using mvdw.helpmijapi.user;

namespace mvdw.helpmijapi.user.gui
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
        private IUser user = null;


        /// <summary>
        /// Helpmij Login Gui Form
        /// </summary>
        public frmLogin(Boolean getUserData)
        {
            InitializeComponent();
            this.getUserData = getUserData;
            // Register events
            hmLogin.onLoginSuccess += new LoginSuccessEventHandler(onLoginSuccess);
            hmLogin.onLoginFailed += new LoginFailedEventHandler(onLoginFailed);
        }

        /// <summary>
        /// Verkrijg de gebruiker
        /// </summary>
        /// <returns>Gebruiker</returns>
        public IUser GetUser()
        {
            return user;
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
        /// On Login Failed Event
        /// </summary>
        /// <param name="e">Event Arguments</param>
        /// <param name="sender">Sender</param>
        private void onLoginFailed(Object sender, LoginFailedEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new LoginFailedEventHandler(onLoginFailed), new Object[] { sender, e });
                }
                else
                {
                    // Login Failed
                    MessageBox.Show("Je hebt een ongeldige gebruikersnaam of een ongeldig wachtwoord ingevoerd.\nDenk eraan dat het wachtwoord hoofdlettergevoelig is.",
                        "Helpmij.nl Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnLogin.Text = "&Inloggen";
                    btnLogin.Enabled = true;
                    hmLogin.Enabled = true;
                }
            }
            catch (Exception)
            {
                // Login Failed
                MessageBox.Show("Je hebt een ongeldige gebruikersnaam of een ongeldig wachtwoord ingevoerd.\nDenk eraan dat het wachtwoord hoofdlettergevoelig is.",
                    "Helpmij.nl Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnLogin.Text = "&Inloggen";
                btnLogin.Enabled = true;
                hmLogin.Enabled = true;
            }
        }

        /// <summary>
        /// On Login Success Event
        /// </summary>
        /// <param name="e">Event Arguments</param>
        /// <param name="sender">Sender</param>
        private void onLoginSuccess(Object sender, LoginSuccessEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new LoginSuccessEventHandler(onLoginSuccess), new Object[] { sender, e });
                }
                else
                {
                    // Login success
                    this.DialogResult = DialogResult.OK;
                    user = e.GetUser();
                    this.Close();
                }
            }
            catch (Exception)
            {
                // Login Failed
                MessageBox.Show("Je hebt een ongeldige gebruikersnaam of een ongeldig wachtwoord ingevoerd.\nDenk eraan dat het wachtwoord hoofdlettergevoelig is.",
                    "Helpmij.nl Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnLogin.Text = "&Inloggen";
                btnLogin.Enabled = true;
                hmLogin.Enabled = true;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
