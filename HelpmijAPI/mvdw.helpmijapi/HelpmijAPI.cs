using System;
using System.Collections.Generic;
using System.Text;

namespace vdw.maxim.helpmijapi
{
    /// <summary>
    /// Helpmij Aplication Interface
    /// </summary>
    class HelpmijAPI : Helpmij
    {
        /// <summary>
        /// Aanmelden op Helpmij.nl
        /// </summary>
        /// <param name="username">Helpmij gebruikersnaam</param>
        /// <param name="password">Zuiver wachtwoord</param>
        /// <returns>Gebruiker</returns>
        public Gebruiker Login(String username, String password)
        {
            // Zet om naar MD5 wachtwoord
            String passwordMD5 = UtilsEncryption.GetMD5Hash(password);
            return HelpmijLogin.Login(username, passwordMD5);
        }

        /// <summary>
        /// Verkrijg meer gebruikers data
        /// </summary>
        /// <param name="user">Gebruiker</param>
        /// <returns>Gebruiker</returns>
        public Gebruiker GetUserData(Gebruiker user)
        {
            return null;
        }
    }
}
