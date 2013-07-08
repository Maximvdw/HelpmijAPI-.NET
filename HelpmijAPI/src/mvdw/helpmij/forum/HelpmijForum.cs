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
    /// Helpmij.nl Forum
    /// </summary>
    internal class HelpmijForum : Forum
    {
        /// <summary>
        /// Forums heeft subforums
        /// </summary>
        public Boolean hasSubForums = false;
        /// <summary>
        /// Sub forums
        /// </summary>
        public List<Forum> subForums = new List<Forum>();
        /// <summary>
        /// Forum URL
        /// </summary>
        public String url = null;
        /// <summary>
        /// Forum ID
        /// </summary>
        public int id = -1;
        /// <summary>
        /// Forum Title
        /// </summary>
        public String title = null;
        /// <summary>
        /// Forum Topics
        /// </summary>
        public List<Topic> topics = new List<Topic>();


        /// <summary>
        /// Controlleer of de forum Subforums heeft
        /// </summary>
        /// <returns>Boolean</returns>
        public Boolean HasSubForums()
        {
            return hasSubForums;
        }

        /// <summary>
        /// Verkrijg de sub forums
        /// </summary>
        /// <returns>Lijst met Forums</returns>
        public List<Forum> GetSubForums()
        {
            return subForums;
        }

        /// <summary>
        /// Set de sub forums
        /// </summary>
        /// <param name="forums">Lijst met forums</param>
        public void SetSubForums(List<Forum> forums)
        {
        }

        /// <summary>
        /// Verkrijg de forum URL
        /// </summary>
        /// <returns>String - URL</returns>
        public String GetURL()
        {
            return url;
        }

        /// <summary>
        /// Set de forum URL
        /// </summary>
        /// <param name="url">String - URL</param>
        public void SetURL(String url)
        {
        }

        /// <summary>
        /// Verkrijg de forum ID
        /// </summary>
        /// <returns>int - ID</returns>
        public int GetID()
        {
            return id;
        }

        /// <summary>
        /// Set de forum ID
        /// </summary>
        /// <param name="id">int - ID</param>
        public void SetID(int id)
        {
        }

        /// <summary>
        /// Verkrijg de forum titel
        /// </summary>
        /// <returns>String - Titel</returns>
        public String GetTitle()
        {
            return title;
        }

        /// <summary>
        /// Set de forum titel
        /// </summary>
        /// <param name="title">String - Titel</param>
        public void SetTitle(String title)
        {
        }

        /// <summary>
        /// Verkrijg de topics in het forum
        /// </summary>
        /// <returns>Lijst met topics</returns>
        public List<Topic> GetTopics()
        {
            return topics;
        }

        /// <summary>
        /// Set de topics in het forum
        /// </summary>
        /// <param name="topics">Lijst met topics</param>
        public void SetTopics(List<Topic> topics)
        {
        }
    }
}
