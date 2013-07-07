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
    /// Helpmij Topic
    /// </summary>
    public interface Topic : HomepageTopic
    {
        /// <summary>
        /// Verkrijg de Auteur van het topic
        /// </summary>
        /// <returns>Gebruiker - Auteru</returns>
        Gebruiker GetAuthor();

        /// <summary>
        /// Set de Auteur van het topic
        /// </summary>
        /// <param name="user">Gebruiker - Auteur</param>
        void SetAuthor(Gebruiker user);

        /// <summary>
        /// Verkrijg de HTML source van de webpagina
        /// </summary>
        /// <returns>String - HTML source</returns>
        String GetHTMLSource();

        /// <summary>
        /// Set de HTML source van de webpagina
        /// </summary>
        /// <param name="source">String - HTML source</param>
        void SetHTMLSource(String source);

        /// <summary>
        /// Verkrijg de keywords van het topic
        /// </summary>
        /// <returns>Lijst met keywords</returns>
        List<String> GetKeywords();

        /// <summary>
        /// Set de keywords van het topic
        /// </summary>
        /// <param name="keywords"></param>
        void SetKeywords(List<String> keywords);
    }
}
