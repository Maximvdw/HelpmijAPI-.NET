﻿/*
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
using mvdw.helpmijapi.chat;
using mvdw.helpmijapi.gebruiker;

namespace mvdw.helpmij.chat
{
    /// <summary>
    /// Helpmij.nl Chat bericht
    /// </summary>
    internal class HelpmijChatMessage : ChatMessage
    {
        /// <summary>
        /// Helpmij Gebruiker
        /// </summary>
        public Gebruiker user = null;
        /// <summary>
        /// Het verzonden bericht
        /// </summary>
        public String message = null;

        /// <summary>
        /// Verkrijg de gebruiker die het bericht schreef
        /// </summary>
        /// <returns>Gebruiker</returns>
        public Gebruiker GetUser()
        {
            return user;
        }

        /// <summary>
        /// Set de gebruiker die het bericht schreef
        /// </summary>
        /// <param name="user">Gebruiker - Auteur</param>
        public void SetUser(Gebruiker user)
        {
            this.user = user;
        }

        /// <summary>
        /// Verkrijg het bericht
        /// </summary>
        /// <returns>String - Message</returns>
        public String GetMessage()
        {
            return message;
        }

        /// <summary>
        /// Set het bericht dat de gebruiker schreef
        /// </summary>
        /// <param name="message">String - message</param>
        public void SetMessage(String message)
        {
            this.message = message;
        }
    }
}