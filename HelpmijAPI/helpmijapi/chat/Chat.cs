using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mvdw.helpmijapi.gebruiker;
using mvdw.helpmijapi.chat.events;

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

        /// <summary>
        /// Zend een commando naar de chat
        /// </summary>
        /// <param name="command">String - Commando</param>
        void SendCommand(String command);

        /// <summary>
        /// Doe een update van de chat
        /// </summary>
        /// <returns>List ChatMessage</returns>
        List<ChatMessage> Update();

        /// <summary>
        /// Verkrijg de laatste update
        /// </summary>
        /// <returns>String - Laatste update</returns>
        String GetLastUpdate();

        /// <summary>
        /// Verkrijg de laatste quote update
        /// </summary>
        /// <returns>int - Laatste update</returns>
        int GetLastQuoteUpdate();
    }
}
