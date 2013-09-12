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
        IGebruiker GetAuthor();

        /// <summary>
        /// Set de Auteur van het topic
        /// </summary>
        /// <param name="user">Gebruiker - Auteur</param>
        void SetAuthor(IGebruiker user);

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

        /// <summary>
        /// Verkrijg alle comments
        /// </summary>
        /// <returns>Topic</returns>
        Topic GetTopic();

        /// <summary>
        /// Verkrijg alle comments
        /// </summary>
        /// <returns>List met Comments</returns>
        List<Comment> GetComments();

        /// <summary>
        /// Set alle comments
        /// </summary>
        /// <param name="comments">List met Comments</param>
        void SetComments(List<Comment> comments);

        /// <summary>
        /// Controlleer of een topic aan jouw intressen voldoet
        /// </summary>
        /// <param name="intrests">List String - Intresses</param>
        /// <returns>Boolean</returns>
        Boolean MatchesIntrests(List<String> intrests);

        /// <summary>
        /// Controlleer of een topic aan jouw intressen voldoet
        /// </summary>
        /// <param name="intrests">List String - Intresses</param>
        /// <returns>Boolean</returns>
        Boolean MatchesIntrests(String[] intrests);
    }
}
