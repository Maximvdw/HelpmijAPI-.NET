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
using mvdw.helpmijapi.forum;
using mvdw.helpmijapi.gebruiker;
using mvdw.helpmijapi.gebruiker.exceptions;

namespace mvdw.helpmij.forum
{
    /// <summary>
    /// Reacties op een Topic
    /// </summary>
    internal class HelpmijComment : Comment
    {
        /// <summary>
        /// Autheur van de comment
        /// </summary>
        private IGebruiker user = null;
        /// <summary>
        /// HTML Body
        /// </summary>
        private String bodyHTML = null;

        /// <summary>
        /// Verkrijg de gebruiker
        /// </summary>
        /// <returns>Gebruiker - User</returns>
        public IGebruiker GetUser()
        {
            return user;
        }

        /// <summary>
        /// Set de gebruiker
        /// </summary>
        /// <param name="user">Gebruiker - User</param>
        public void SetUser(IGebruiker user)
        {
            this.user = user;
        }

        /// <summary>
        /// Verkrijg de tekst in HTML
        /// </summary>
        /// <returns>String - HTML</returns>
        public String GetBodyHTML()
        {
            return bodyHTML;
        }

        /// <summary>
        /// Set de tekst in HTML
        /// </summary>
        /// <param name="html">String - HTML</param>
        public void SetBodyHTML(String html)
        {
            this.bodyHTML = html;
        }
    }
}
