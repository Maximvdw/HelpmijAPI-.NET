using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mvdw.helpmijapi.gebruiker.events
{
    /// <summary>
    /// Login Failed Event Arguments
    /// </summary>
    public class LoginFailedEventArgs : EventArgs
    {
        /// <summary>
        /// Error message
        /// </summary>
        public Exception error = null;

        /// <summary>
        /// Login Failed Event Argeuments
        /// </summary>
        /// <param name="error">Login Exception</param>
        public LoginFailedEventArgs(Exception error)
        {
            this.error = error;
        }
    }

    /// <summary>
    /// Login Failed Event Handler
    /// </summary>
    public delegate void LoginFailedEventHandler(Object sender, LoginFailedEventArgs e);
}
