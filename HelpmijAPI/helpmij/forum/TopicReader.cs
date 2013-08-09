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
using mvdw.helpmijapi.gebruiker.exceptions;
using mvdw.helpmijapi.forum;
using mvdw.helpmijapi;

namespace mvdw.helpmij.forum
{
    /// <summary>
    /// Helpmij Topic Reader
    /// </summary>
    internal class TopicReader
    {
        /// <summary>
        /// HM Forum Data Settings
        /// </summary>
        private static HMForumData s = new HMForumData();

        /// <summary>
        /// Verkrijg de Topic data
        /// </summary>
        /// <param name="topic">Het topic om te saven</param>
        /// <param name="cookies">Eventuele cookies</param>
        public static void GetTopicData(Topic topic, CookieContainer cookies)
        {
            if (UtilsHTTP.IsInternetAvailable())
            {
                // Verkrijg de sourcecode
                String source = UtilsHTTP.GetSource(topic.GetURL(), cookies);
                topic.SetAuthor(GetAuthor(source)); // AUTHEUR
                topic.SetTitle(GetTitle(source)); // TITEL
                topic.SetKeywords(GetKeywords(source)); // KEYWORDS
                topic.SetComments(GetComments(source, cookies, topic)); // COMMENTS
            }
            else
            {
                // Error geen internet
                throw new UnableToConnectException("Kan geen verbinding met Helpmij.nl maken!");
            }
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
                s.memberPrefix, s.authorSuffix)[0];
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
                s.titlePrefix, s.titleSuffix)[0];
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
                s.metaKeywordPrefix, s.metaKeywordSuffix)[0];
            // Split met ', '
            String[] data = keywords_str.Split(',');
            List<String> output = new List<String>();
            foreach (String keyword in data)
            {
                output.Add(keyword.Replace(" ", "").ToLower());
            }
            // Return het resultaat
            return output;
        }

        /// <summary>
        /// Verkrijg de comments uit de source
        /// </summary>
        /// <param name="source">De broncode</param>
        /// <param name="cookies">Cookies</param>
        /// <param name="topic">Helpmij Topic</param>
        /// <returns>Lijst met Comment</returns>
        private static List<Comment> GetComments(String source, CookieContainer cookies, Topic topic)
        {
            // Doorloop de pagina's
            String prevPage = source;
            String curPage = "";
            List<Comment> comments = new List<Comment>(); // Nieuwe lijst
            // Read pages
            int pages = 1;
            try
            {
                pages = int.Parse(UtilsString.GetSubStrings(source, s.topicPagesPrefix, s.topicPagesSuffix)[0]);
            }
            catch (Exception) { }

            for (int i = 1;i<=pages;i++){
                // Eerste keer
                if (curPage == "")
                    curPage = source.Split(new[] { s.beginTopic }, StringSplitOptions.RemoveEmptyEntries)[1].Replace("/page" + i + "#top","");
                prevPage = curPage; // Vorige pagina
                // Haal informatie uit pagina
                List<String> authors = UtilsString.GetSubStrings(curPage,
                s.memberPrefix, s.memberSuffix); // Autheurs
                String[] bodyHtml = curPage.Split(new[] { s.commentBodyPrefix, s.commentBodySuffix }, StringSplitOptions.RemoveEmptyEntries);

                // Loop door alle comments
                for (int j = 0; j < authors.Count; j++)
                {
                    try
                    {
                        Comment comment = new HelpmijComment();
                        Gebruiker user = Helpmij.GetUser(int.Parse(authors[j].Substring(0, authors[j].IndexOf('-'))));
                        comment.SetUser(user);
                        comment.SetBodyHTML(bodyHtml[(j + 1) + (j)]);
                        comments.Add(comment);
                    }
                    catch (Exception)
                    {
                        // Comment kon niet gelezen wordne
                        // Reclame?
                    }
                }

                // Verkrijg nieuwe pagina
                curPage = UtilsHTTP.GetSource(topic.GetURL() + s.pagePrefix + i.ToString(), cookies);
                curPage = curPage.Split(new[] { s.beginTopic }, StringSplitOptions.RemoveEmptyEntries)[1].Replace("/page" + i + "#top", "");
            }

            // Return het resultaat
            return comments;
        }

        /// <summary>
        /// Controlleer of een topic aan de keywords voldoet
        /// </summary>
        /// <param name="intrests">String list</param>
        /// <param name="topic">Topic</param>
        /// <returns>Boolean</returns>
        public static Boolean MatchesIntrests(List<String> intrests, Topic topic)
        {
            // Verkrijg informatie
            String title = topic.GetTitle().ToLower();

            String bodyHtml = topic.GetComments()[0].GetBodyHTML();
            String[] bodyKeywords = bodyHtml.Split(' ');
            List<String> keywords = topic.GetKeywords();
            keywords.AddRange(title.Split(' '));
            keywords.AddRange(bodyKeywords);

            // Doorloop de intressen
            foreach (String key in keywords)
            {
                if (intrests.Contains(key.ToLower()))
                {
                    return true;
                }
            }
            // Geen return gebeurt
            return false;
        }

        /// <summary>
        /// Controlleer of een topic aan de keywords voldoet
        /// </summary>
        /// <param name="intrests">String list</param>
        /// <param name="topic">Topic</param>
        /// <returns>Boolean</returns>
        public static Boolean MatchesIntrests(String[] intrests, Topic topic)
        {
            return MatchesIntrests(intrests.ToList<String>(), topic);
        }
    }
}
