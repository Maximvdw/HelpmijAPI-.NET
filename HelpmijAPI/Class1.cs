using System;
using System.Collections.Generic;
using System.Text;

namespace vdw.maxim.helpmijapi
{
    public abstract class Helpmij
    {
        /// <summary>
        /// Gebruiker Gebanned Exception
        /// </summary>
        Exception UserBannedException;

        /// <summary>
        /// Helpmij Gebruikersnaam
        /// </summary>
        protected String username;
        /// <summary>
        /// Geencrypteerd wachtwoord
        /// </summary>
        protected String passwordMD5;

        /// <summary>
        /// Aanmelden op Helpmij.nl
        /// </summary>
        /// <param name="username">Helpmij Gebruikersnaam</param>
        /// <param name="password">Zuiver wachtwoord</param>
        public Gebruiker Login(String username, String password);
    }
}
