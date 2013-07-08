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
using System.Net;
using mvdw.helpmij.utils;
using mvdw.helpmijapi.chat;
using mvdw.helpmijapi.gebruiker;

namespace mvdw.helpmij.chat
{
    /// <summary>
    /// Helpmij.nl Chat integratie
    /// </summary>
    internal class HelpmijChat : HelpmijData , Chat
    {
        /// <summary>
        /// Chat gebruiker
        /// </summary>
        public Gebruiker user = null;

        /// <summary>
        /// Connecteer met Helpmij.nl Chat
        /// </summary>
        /// <param name="user">Ingelogde gebruiker</param>
        public void Connect(Gebruiker user)
        {
            this.user = user;
        }

        /// <summary>
        /// Zend een bericht in de chat
        /// </summary>
        /// <param name="message">String - Bericht</param>
        public void SendMessage(String message)
        {
            CookieContainer cookies = user.GetCookies();
            UtilsHTTP.GetPOSTSource("function=send&message=" + message + "&color=006666", "http://chat.helpmij.nl/process.php",ref cookies);
        }
    }
}
