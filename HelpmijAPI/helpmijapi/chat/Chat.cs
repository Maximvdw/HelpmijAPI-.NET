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
using System.Linq;
using System.Text;
using System.Drawing;
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
        /// <returns>Chat messages</returns>
        List<ChatMessage> SendCommand(String command);

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
        /// Set de laatste update
        /// </summary>
        /// <param name="lastUpdate">DateTime - Lastupdate</param>
        void SetLastUpdate(DateTime lastUpdate);

        /// <summary>
        /// Verkrijg de laatste quote update
        /// </summary>
        /// <returns>Double - Laatste update</returns>
        Double GetLastQuoteUpdate();

        /// <summary>
        /// Set de gebruiker
        /// </summary>
        /// <param name="user">Gebruiker - user</param>
        void SetUser(Gebruiker user);

        /// <summary>
        /// Load Progress Event
        /// </summary>
        event LoadProgressHandler onProgressEvent;

        /// <summary>
        /// Set chat kleur
        /// </summary>
        /// <param name="color">Color color</param>
        void SetChatColor(Color color);

        /// <summary>
        /// Verkrijg chat kleur
        /// </summary>
        /// <returns>Color color</returns>
        Color GetChatColor();
    }
}
