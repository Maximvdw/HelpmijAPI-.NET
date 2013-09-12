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
        private IGebruiker user = null;

        /// <summary>
        /// Login Success Event Argeuments
        /// </summary>
        /// <param name="user">Gebruiker - User</param>
        public LoginSuccessEventArgs(IGebruiker user)
        {
            this.user = user;
        }

        /// <summary>
        /// Verkrijg de gebruiker
        /// </summary>
        /// <returns>Gebruiker - User</returns>
        public IGebruiker GetUser()
        {
            return user;
        }
    }

    /// <summary>
    /// Login Success Event Handler
    /// </summary>
    public delegate void LoginSuccessEventHandler(Object sender, LoginSuccessEventArgs e);
}
