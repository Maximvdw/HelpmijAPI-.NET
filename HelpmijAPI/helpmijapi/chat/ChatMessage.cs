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
using System.Drawing;
using mvdw.helpmijapi.gebruiker;

namespace mvdw.helpmijapi.chat
{
    /// <summary>
    /// Helpmij.nl Chat message
    /// </summary>
    public interface ChatMessage
    {
        /// <summary>
        /// Verkrijg de gebruiker die het bericht schreef
        /// </summary>
        /// <returns>Gebruiker</returns>
        Gebruiker GetUser();

        /// <summary>
        /// Set de gebruiker die het bericht schreef
        /// </summary>
        /// <param name="user">Gebruiker - Auteur</param>
        void SetUser(Gebruiker user);

        /// <summary>
        /// Verkrijg het bericht
        /// </summary>
        /// <returns>String - Message</returns>
        String GetMessage();

        /// <summary>
        /// Set het bericht dat de gebruiker schreef
        /// </summary>
        /// <param name="message">String - message</param>
        void SetMessage(String message);

        /// <summary>
        /// Verkrijg de kleur van het bericht
        /// </summary>
        /// <returns>Color - Bericht</returns>
        Color GetColor();

        /// <summary>
        /// Set de kleur van het bericht
        /// </summary>
        /// <param name="color">Color - Bericht</param>
        void SetColor(Color color);

        /// <summary>
        /// Verkrijg het type bericht
        /// </summary>
        /// <returns>ChatMessageType - Type</returns>
        ChatMessageType GetMessageType();

        /// <summary>
        /// Set het type bericht
        /// </summary>
        /// <param name="type">ChatMessageType - Type</param>
        void SetMessageType(ChatMessageType type);
    }

    /// <summary>
    /// Chat Message Types
    /// </summary>
    public enum ChatMessageType
    {
        Normal = 0,
        PublicAt = 1,
        Private = 2,
        Login = 3,
        Logout = 4,
        Status = 5
    }
}
