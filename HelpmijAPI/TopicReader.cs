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
using mvdw.helpmijapi.gebruiker;
using mvdw.helpmij;
using mvdw.helpmij.utils;
using mvdw.helpmij.gebruiker;
using mvdw.helpmijapi.forum;

namespace mvdw.helpmij.forum
{
    /// <summary>
    /// Helpmij Topic Reader
    /// </summary>
    internal class TopicReader : HelpmijData
    {
        /// <summary>
        /// Verkrijg de Topic data
        /// </summary>
        /// <param name="topic">Het topic om te saven</param>
        /// <param name="cookies">Eventuele cookies</param>
        public static void GetTopicData(Topic topic, CookieContainer cookies)
        {
            // Verkrijg de sourcecode
            String source = UtilsHTTP.GetSource(topic.GetURL(), cookies);
            topic.SetAuthor(GetAuthor(source)); // AUTHEUR
            topic.SetTitle(GetTitle(source)); // TITEL
            topic.SetKeywords(GetKeywords(source)); // KEYWORDS
        }

        /// <summary>
        /// Verkrijg de Topic data
        /// </summary>
        /// <param name="topic">Het topic om te saven</param>
        public static void GetTopicData(Topic topic)
        {
            // Maak een nieuwe cookiecontainer
            CookieContainer cookies = new CookieContainer();
            GetTopicData(topic, cookies);
        }

        /// <summary>
        /// Verkrijg de auteur van het topic
        /// </summary>
        /// <param name="source">De Broncode</param>
        /// <returns>Gebruiker - Auteur</returns>
        private static Gebruiker GetAuthor(String source)
        {
            String usernameAndID = UtilsString.GetSubStrings(source,
                memberPrefix, authorSuffix)[0];
            String[] data = usernameAndID.Split('-');
            String username = data[1];
            int id = int.Parse(data[0]);
            // Maak een nieuwe gebruiker met deze gegevens
            Gebruiker user = new HelpmijGebruiker();
            user.SetNickname(username);
            user.SetUserID(id);
            // Return the result
            return user;
        }

        /// <summary>
        /// Verkrijg de titel
        /// </summary>
        /// <param name="source">De broncode</param>
        /// <returns>String - Titel</returns>
        private static String GetTitle(String source)
        {
            // Verkrijg de titel
            String title = UtilsString.GetSubStrings(source,
                titlePrefix, titleSuffix)[0];
            return title;
        }

        /// <summary>
        /// Verkrijg de keywords
        /// </summary>
        /// <param name="source">De broncode</param>
        /// <returns>String - Titel</returns>
        private static List<String> GetKeywords(String source)
        {
            // Verkrijg de titel
            String keywords_str = UtilsString.GetSubStrings(source,
                metaKeywordPrefix, metaKeywordSuffix)[0];
            // Split met ', '
            String[] data = keywords_str.Split(',');
            List<String> output = new List<String>();
            foreach (String keyword in data){
                output.Add(keyword.Replace(" ", ""));
            }
            // Return het resultaat
            return output;
        }
    }
}
