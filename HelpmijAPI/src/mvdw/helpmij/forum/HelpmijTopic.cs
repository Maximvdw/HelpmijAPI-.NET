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

namespace mvdw.helpmij.forum
{
    /// <summary>
    /// Helpmij Topic
    /// </summary>
    internal class HelpmijTopic : Topic
    {
        /// <summary>
        /// Topic Titel
        /// </summary>
        public String title = null;
        /// <summary>
        /// Topic Auteur
        /// </summary>
        public Gebruiker author = null;
        /// <summary>
        /// Topic URL
        /// </summary>
        public String url = null;
        /// <summary>
        /// Aangemaakt op UUR
        /// </summary>
        public int hour = -1;
        /// <summary>
        /// Aangemaakt op Minuut
        /// </summary>
        public int minute = -1;
        /// <summary>
        /// HTML source
        /// </summary>
        public String source = null;
        /// <summary>
        /// Topic Keywords
        /// </summary>
        public List<String> keywords = new List<String>();
        /// <summary>
        /// Topic comments
        /// </summary>
        public List<Comment> comments = new List<Comment>();
        /// <summary>
        /// Topic ID
        /// </summary>
        public int id = -1;


        /// <summary>
        /// Zet de HomepageTopic om naar een Topic
        /// </summary>
        /// <returns>Topic</returns>
        public Topic GetTopic()
        {
            TopicReader.GetTopicData(this);
            return this;
        }

        /// <summary>
        /// Verkrijg de Titel van het topic
        /// </summary>
        /// <returns>String - Title</returns>
        public String GetTitle()
        {
            return title;
        }

        /// <summary>
        /// Set de Titel van het topic
        /// </summary>
        /// <param name="title">String - Title</param>
        public void SetTitle(String title)
        {
            this.title = title;
        }

        /// <summary>
        /// Verkrijg de URL van het topic
        /// </summary>
        /// <returns>String - URL</returns>
        public String GetURL()
        {
            return url;
        }

        /// <summary>
        /// Set de URL van het topic
        /// </summary>
        /// <param name="url">String - URL</param>
        public void SetURL(String url)
        {
            this.url = url;
        }

        /// <summary>
        /// Verkrijg het uur waarop de topic is aangemaakt
        /// </summary>
        /// <returns>int- Uur</returns>
        public int GetHour()
        {
            return hour;
        }

        /// <summary>
        /// Set het uur waarop de topic is aangemaakt
        /// </summary>
        /// <param name="hour">int - Uur</param>
        public void SetHour(int hour)
        {
            this.hour = hour;
        }

        /// <summary>
        /// Verkrijg de minuut waarop het topic is aangemaakt
        /// </summary>
        /// <returns>int - Minuten</returns>
        public int GetMinute()
        {
            return minute;
        }

        /// <summary>
        /// Set het tijdstip waarop het topic is aangemaakt
        /// </summary>
        /// <param name="minute">int - Minuten</param>
        public void SetMinute(int minute)
        {
            this.minute = minute;
        }

        /// <summary>
        /// Verkrijg de Auteur van het topic
        /// </summary>
        /// <returns>Gebruiker - Auteru</returns>
        public Gebruiker GetAuthor()
        {
            return author;
        }

        /// <summary>
        /// Set de Auteur van het topic
        /// </summary>
        /// <param name="user">Gebruiker - Auteur</param>
        public void SetAuthor(Gebruiker user)
        {
            this.author = user;
        }

        /// <summary>
        /// Verkrijg de HTML source van de webpagina
        /// </summary>
        /// <returns>String - HTML source</returns>
        public String GetHTMLSource()
        {
            return source;
        }

        /// <summary>
        /// Set de HTML source van de webpagina
        /// </summary>
        /// <param name="source">String - HTML source</param>
        public void SetHTMLSource(String source)
        {
            this.source = source;
        }

        /// <summary>
        /// Verkrijg de keywords van het topic
        /// </summary>
        /// <returns>Lijst met keywords</returns>
        public List<String> GetKeywords()
        {
            return keywords;
        }

        /// <summary>
        /// Set de keywords van het topic
        /// </summary>
        /// <param name="keywords"></param>
        public void SetKeywords(List<String> keywords)
        {
            this.keywords = keywords;
        }

        /// <summary>
        /// Verkrijg de Topic ID
        /// </summary>
        /// <returns>int - ID</returns>
        public int GetID()
        {
            return id;
        }

        /// <summary>
        /// Set de Topic ID
        /// </summary>
        /// <param name="id">int - ID</param>
        public void SetID(int id)
        {
            this.id = id;
        }

        /// <summary>
        /// Verkrijg alle comments
        /// </summary>
        /// <returns>List met Comments</returns>
        public List<Comment> GetComments()
        {
            return comments;
        }

        /// <summary>
        /// Set alle comments
        /// </summary>
        /// <param name="comments">List met Comments</param>
        public void SetComments(List<Comment> comments)
        {
            this.comments = comments;
        }
    }
}
