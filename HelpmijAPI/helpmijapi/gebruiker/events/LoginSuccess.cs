using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mvdw.helpmijapi.gebruiker.events
{
    /// <summary>
    /// Login Success Event Arguments
    /// </summary>
    public class LoginSuccessEventArgs : EventArgs
    {
        /// <summary>
        /// Gebruiker
        /// </summary>
        private Gebruiker user = null;
        /// <summary>
        /// Gebruikers Data
        /// </summary>
        private GebruikerData userData = null;

        /// <summary>
        /// Login Success Event Argeuments
        /// </summary>
        /// <param name="user">Gebruiker - User</param>
        public LoginSuccessEventArgs(Gebruiker user)
        {
            this.user = user;
        }

        /// <summary>
        /// Login Success Event Argeuments
        /// </summary>
        /// <param name="user">GebruikerData - User</param>
        public LoginSuccessEventArgs(GebruikerData user)
        {
            this.userData = user;
        }

        /// <summary>
        /// Verkrijg de gebruiker data
        /// </summary>
        /// <returns>GebruikerData - Data</returns>
        public GebruikerData GetUserData()
        {
            if (userData == null)
            {
                return user.GetUserData();
            }
            else
            {
                return userData;
            }
        }

        /// <summary>
        /// Verkrijg de gebruiker
        /// </summary>
        /// <returns>Gebruiker - User</returns>
        public Gebruiker GetUser()
        {
            return user;
        }
    }

    /// <summary>
    /// Login Success Event Handler
    /// </summary>
    public delegate void LoginSuccessEventHandler(Object sender, LoginSuccessEventArgs e);
}
