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
    /// Event Handler
    /// </summary>
    /// <param name="e">Event arguments</param>
    public delegate void UserJoinedEventHandler(UserJoinedEventArgs e);

    /// <summary>
    /// Triggered als een Gebruiker de chat joined
    /// </summary>
    public class UserJoinedEventArgs : EventArgs
    {
        /// <summary>
        /// De gebruiker die joined
        /// </summary>
        public readonly Gebruiker user = null;

        /// <summary>
        /// Triggered als een Gebruiker de chat joined
        /// </summary>
        public UserJoinedEventArgs(Gebruiker user)
        {
            this.user = user;
        }
    }

    /// <summary>
    /// Triggered als een Gebruiker de chat joined
    /// </summary>
    public class UserJoinedListener
    {
    }
}
