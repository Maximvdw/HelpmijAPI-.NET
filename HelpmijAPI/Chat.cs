using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mvdw.helpmijapi.gebruiker;

namespace mvdw.helpmijapi.chat
{
    /// <summary>
    /// Helpmij.nl Chat
    /// </summary>
    public interface Chat
    {
        /// <summary>
        /// Connecteer met chat.helpmij.nl
        /// </summary>
        /// <param name="user">Gebruiker</param>
        void Connect(Gebruiker user);

        /// <summary>
        /// Zend een bericht in de chat
        /// </summary>
        /// <param name="message">String - Bericht</param>
        void SendMessage(String message);
    }
}
