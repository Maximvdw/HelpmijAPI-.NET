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

namespace mvdw.helpmijapi.forum
{
    /// <summary>
    /// Helpmij.nl Forum
    /// </summary>
    public interface Forum
    {
        /// <summary>
        /// Controlleer of de forum Subforums heeft
        /// </summary>
        /// <returns>Boolean</returns>
        Boolean HasSubForums();

        /// <summary>
        /// Verkrijg de sub forums
        /// </summary>
        /// <returns>Lijst met Forums</returns>
        List<Forum> GetSubForums();

        /// <summary>
        /// Set de sub forums
        /// </summary>
        /// <param name="forums">Lijst met forums</param>
        void SetSubForums(List<Forum> forums);
        
        /// <summary>
        /// Verkrijg de forum URL
        /// </summary>
        /// <returns>String - URL</returns>
        String GetURL();

        /// <summary>
        /// Set de forum URL
        /// </summary>
        /// <param name="url">String - URL</param>
        void SetURL(String url);

        /// <summary>
        /// Verkrijg de forum ID
        /// </summary>
        /// <returns>int - ID</returns>
        int GetID();

        /// <summary>
        /// Set de forum ID
        /// </summary>
        /// <param name="id">int - ID</param>
        void SetID(int id);

        /// <summary>
        /// Verkrijg de forum titel
        /// </summary>
        /// <returns>String - Titel</returns>
        String GetTitle();

        /// <summary>
        /// Set de forum titel
        /// </summary>
        /// <param name="title">String - Titel</param>
        void SetTitle(String title);

        /// <summary>
        /// Verkrijg de topics in het forum
        /// </summary>
        /// <returns>Lijst met topics</returns>
        List<Topic> GetTopics();

        /// <summary>
        /// Set de topics in het forum
        /// </summary>
        /// <param name="topics">Lijst met topics</param>
        void SetTopics(List<Topic> topics);
    }
}
