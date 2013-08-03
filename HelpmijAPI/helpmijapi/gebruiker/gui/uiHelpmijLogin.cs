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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using mvdw.helpmijapi.gebruiker;
using mvdw.helpmijapi.gebruiker.exceptions;
using mvdw.helpmijapi.gebruiker.events;
using mvdw.helpmijapi;
using mvdw.helpmij.utils;

namespace mvdw.helpmijapi.gebruiker.gui
{
    /// <summary>
    /// Helpmij.nl Login Interface
    /// </summary>
    public partial class uiHelpmijLogin : UserControl
    {
        /// <summary>
        /// Verkrijg data bij het inloggen
        /// </summary>
        private Boolean getData = false;
        /// <summary>
        /// Helpmij Gebruiker
        /// </summary>
        private Gebruiker user = null;
        /// <summary>
        /// Helpmij Gebruikers Data
        /// </summary>
        private GebruikerData userData = null;
        /// <summary>
        /// Event wanneer het inloggen mislukt
        /// </summary>
        public event LoginFailedEventHandler onLoginFailed;
        /// <summary>
        /// Event wanneer het inloggen gelukt is
        /// </summary>
        public event LoginSuccessEventHandler onLoginSuccess;
        /// <summary>
        /// Hashed wachtwoord
        /// </summary>
        private String passwordMD5 = null;
        /// <summary>
        /// Herriner Mij aan
        /// </summary>
        private Boolean storedCred = false;

        /// <summary>
        /// Login Failed Event Handler
        /// </summary>
        public static LoginFailedEventHandler LoginFailedEventHandler;
        /// <summary>
        /// Login Failed Event Arguments
        /// </summary>
        public static LoginFailedEventArgs LoginFailedEventArgs;
        /// <summary>
        /// Login Success Event Handler
        /// </summary>
        public static LoginSuccessEventHandler LoginSuccessEventHandler;
        /// <summary>
        /// Login Success Event Arguments
        /// </summary>
        public static LoginSuccessEventArgs LoginSuccessEventArgs;
        

        [Description("Verkrijg gebruikers gegevens"), Category("Data")] 
        public Boolean Data
        {
            get { return getData; }
            set { getData = value; }
        }

        /// <summary>
        /// Login User Interface
        /// </summary>
        public uiHelpmijLogin()
        {
            InitializeComponent();
        }

        private void uiLogin_Load(object sender, EventArgs e)
        {
            // Controlleer op bewaarde gegevens
            String username = Properties.Settings.Default.Username;
            passwordMD5 = Properties.Settings.Default.Password;
            if (username != "" && passwordMD5 != "")
            {
                // Laad instellingen
                txtUsername.Text = username;
                txtPassword.Text =
                    new StringBuilder().Append('*', Properties.Settings.Default.PasswordLength).ToString();
                storedCred = true;
                // Wijzig kleur
                txtUsername.BackColor = Color.LemonChiffon;
                txtPassword.BackColor = Color.LemonChiffon;
                chkRemember.Checked = true;
            }
        }

        /// <summary>
        /// Inloggen
        /// </summary>
        public void Inloggen()
        {
            // Controlleer of de velden ingevoerd zijn
            if (txtUsername.Text != "" && txtUsername.Text != "")
            {
                String username = txtUsername.Text;
                String password = txtPassword.Text;
                if (storedCred == false)
                    passwordMD5 = UtilsEncryption.GetMD5Hash(password);

                // Controlleer of het wachtwoord moet onthouden worden
                if (chkRemember.Checked)
                {
                    // Save settings
                    Properties.Settings.Default.Username = username;
                    Properties.Settings.Default.Password = passwordMD5;
                    Properties.Settings.Default.PasswordLength = password.Length;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    // Reset settings
                    Properties.Settings.Default.Reset();
                }
                Thread thLogin = new Thread(() => Login(username, passwordMD5));
                thLogin.Start();
            }
        }

        /// <summary>
        /// Meld de HM gebruiker aan
        /// </summary>
        /// <param name="username">Helpmij Gebruikersnaam</param>
        /// <param name="password">Helpmij Wachtwoord</param>
        private void Login(String username, String password)
        {
            // Verkrijg de gebruiker
            user = null;
            try
            {
                // Probeer in to loggen
                user = Helpmij.LoginMD5(username, password);
                // Controlleer of de informatie moet worden opgehaald
                if (Data == true)
                {
                    // Haal de gegevens op
                    userData = user.GetUserData();
                    // Login gelukt
                    if (this.onLoginSuccess != null)
                        this.onLoginSuccess(this, new LoginSuccessEventArgs(userData));
                }
                else
                {
                    // Login gelukt
                    if (this.onLoginSuccess != null)
                        this.onLoginSuccess(this, new LoginSuccessEventArgs(user));
                }
            }
            catch (CredentialsWrongException e)
            {
                // Gebruikersnaam of wachtwoord fout
                if (this.onLoginFailed != null)
                    this.onLoginFailed(this, new LoginFailedEventArgs(e));
            }

        }

        /// <summary>
        /// Zet 'Herriner Mij?' af
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (storedCred == true)
            {
                txtPassword.BackColor = Color.White;
                storedCred = false;
                txtPassword.Text = "";
            }
        }

        /// <summary>
        /// Zet 'Herriner Mij?' af
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (storedCred == true)
            {
                txtUsername.BackColor = Color.White;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            // Controlleer of het ENTER is
            if (e.KeyData == Keys.Enter){
                Inloggen();
            }
        }
    }
}
