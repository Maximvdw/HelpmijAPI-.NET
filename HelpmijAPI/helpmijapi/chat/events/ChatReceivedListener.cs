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
using mvdw.helpmijapi.gebruiker;

namespace mvdw.helpmijapi.chat.events
{
    /// <summary>
    /// Helpmij.nl Chat Message Receieved Listener
    /// </summary>
    public interface ChatReceivedListener
    {
        /// <summary>
        /// Word opgeroepen wanneer er een nieuw chat bericht is
        /// </summary>
        /// <param name="e">Event Argumenten</param>
        void onChatReceived(ChatReceivedArguments e);
    }

    /// <summary>
    /// Helpmij.nl Chat Arguments
    /// </summary>
    public class ChatReceivedArguments
    {
        /// <summary>
        /// Received Chat message
        /// </summary>
        private ChatMessage message = null;

        /// <summary>
        /// Chat Message received
        /// </summary>
        /// <param name="message">ChatMessage - Message</param>
        public ChatReceivedArguments(ChatMessage message)
        {
            this.message = message;
        }

        /// <summary>
        /// Verkrijg een Chat Message
        /// </summary>
        public ChatMessage GetChatMessage()
        {
            return message;
        }
    }
}
