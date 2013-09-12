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

namespace mvdw.helpmijapi.forum
{
    /// <summary>
    /// Reacties op een Topic
    /// </summary>
    public interface Comment
    {
        /// <summary>
        /// Verkrijg de gebruiker
        /// </summary>
        /// <returns>Gebruiker - User</returns>
        IGebruiker GetUser();

        /// <summary>
        /// Set de gebruiker
        /// </summary>
        /// <param name="user">Gebruiker - User</param>
        void SetUser(IGebruiker user);

        /// <summary>
        /// Verkrijg de tekst in HTML
        /// </summary>
        /// <returns>String - HTML</returns>
        String GetBodyHTML();

        /// <summary>
        /// Set de tekst in HTML
        /// </summary>
        /// <param name="html">String - HTML</param>
        void SetBodyHTML(String html);
    }
}
