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
using mvdw.helpmijapi.forum;
using mvdw.helpmij.utils;
using mvdw.helpmij.forum;
using mvdw.helpmijapi.gebruiker;

namespace mvdw.helpmij.homepage
{
    /// <summary>
    /// Helpmij Homepage topics
    /// </summary>
    class HomepageTopics : HelpmijData
    {
        /// <summary>
        /// Cache source code
        /// </summary>
        public static String source = null;
        /// <summary>
        /// Cache gebruiker
        /// </summary>
        public static Gebruiker user = null;

        /// <summary>
        /// Refresh the source cache
        /// </summary>
        public static void RefreshCache()
        {
            // Stel de URL samen
            String url = siteURL;
            // Maak een nieuwe cookiecontainer
            CookieContainer cookies = new CookieContainer();
            HomepageTopics.source = UtilsHTTP.GetSource(url, cookies);
            // Zet de gebruiker op null
            user = null;
        }

        /// <summary>
        /// Refresh the source cache
        /// </summary>
        public static void RefreshCache(Gebruiker user)
        {
            // Stel de URL samen
            String url = siteURL;
            // Maak een nieuwe cookiecontainer
            CookieContainer cookies = user.GetCookies();
            HomepageTopics.source = UtilsHTTP.GetSource(url, cookies);
            // Save de gebruiker
            HomepageTopics.user = user;
        }

        /// <summary>
        /// Verkrijg de laatste nieuwe topics van de site
        /// </summary>
        /// <returns>Lijst met topics</returns>
        public static List<HomepageTopic> GetNewTopics()
        {
            // Initializeer de output
            List<HomepageTopic> newTopics = new List<HomepageTopic>();
            // Verkrijg de broncode
            String source = HomepageTopics.source;
            if (source == null)
            {
                RefreshCache();
                source = HomepageTopics.source;
            }
            source = source.Split(new[] { homepageTab1, 
                homepageTab2 }, StringSplitOptions.RemoveEmptyEntries)[1];
            // Start met het ophalen van de gegevens
            List<String> topicURLs = new List<String>();
            List<String> topicTitles = new List<String>();
            List<String> topicTimes = new List<String>();
            topicURLs = UtilsString.GetSubStrings(source,
                newTopicUrlPrefix, newTopicUrlSuffix);
            topicTitles = UtilsString.GetSubStrings(source,
                newTopicTitlePrefix, newTopicTitleSuffix);
            topicTimes = UtilsString.GetSubStrings(source,
                newTopicTimePrefix, newTopicTimeSuffix);
            for (int i = 0; i < topicURLs.Count; i++)
            {
                // Creer een nieuwe HomepageTopic
                HomepageTopic topic = new HelpmijTopic();
                String topicUrl = topicURLs[i];
                String topicTitle = topicTitles[i];
                String topicTime = topicTimes[i];
                topic.SetURL(topicUrl);
                topic.SetTitle(topicTitle);
                DateTime time = new DateTime();
                DateTime.TryParse(topicTime, out time);
                topic.SetHour(time.Hour);
                topic.SetMinute(time.Minute);
                // Voeg de topic toe
                newTopics.Add(topic);
            }
            return newTopics;
        }

        /// <summary>
        /// Verkrijg de laatste onbeantwoorde topics van de site
        /// </summary>
        /// <returns>Lijst met topics</returns>
        public static List<HomepageTopic> GetUnansweredTopics()
        {
            // Initializeer de output
            List<HomepageTopic> newTopics = new List<HomepageTopic>();
            // Verkrijg de broncode
            String source = HomepageTopics.source;
            if (source == null)
            {
                RefreshCache();
                source = HomepageTopics.source;
            }
            source = source.Split(new[] { homepageTab2, 
                homepageTab3 }, StringSplitOptions.RemoveEmptyEntries)[1];
            // Start met het ophalen van de gegevens
            List<String> topicURLs = new List<String>();
            List<String> topicTitles = new List<String>();
            List<String> topicTimes = new List<String>();
            topicURLs = UtilsString.GetSubStrings(source,
                newTopicUrlPrefix, newTopicUrlSuffix);
            topicTitles = UtilsString.GetSubStrings(source,
                newTopicTitlePrefix, newTopicTitleSuffix);
            topicTimes = UtilsString.GetSubStrings(source,
                newTopicTimePrefix, newTopicTimeSuffix);
            for (int i = 0; i < topicURLs.Count; i++)
            {
                // Creer een nieuwe HomepageTopic
                HomepageTopic topic = new HelpmijTopic();
                String topicUrl = topicURLs[i];
                String topicTitle = topicTitles[i];
                String topicTime = topicTimes[i];
                topic.SetURL(topicUrl);
                topic.SetTitle(topicTitle);
                DateTime time = new DateTime();
                DateTime.TryParse(topicTime, out time);
                topic.SetHour(time.Hour);
                topic.SetMinute(time.Minute);
                // Voeg de topic toe
                newTopics.Add(topic);
            }
            return newTopics;
        }

        /// <summary>
        /// Verkrijg de laatste vragen van de gebruiker
        /// </summary>
        /// <returns>Lijst met topics</returns>
        public static List<HomepageTopic> GetUnansweredTopics(Gebruiker user)
        {
            // Initializeer de output
            List<HomepageTopic> newTopics = new List<HomepageTopic>();
            // Verkrijg de broncode
            String source = HomepageTopics.source;
            Gebruiker cachedUser = HomepageTopics.user;
            if (source == null && (cachedUser == user))
            {
                RefreshCache(user);
                source = HomepageTopics.source;
            }
            source = source.Split(new[] { homepageTab2, 
                homepageTab3 }, StringSplitOptions.RemoveEmptyEntries)[1];
            // Start met het ophalen van de gegevens
            List<String> topicURLs = new List<String>();
            List<String> topicTitles = new List<String>();
            List<String> topicTimes = new List<String>();
            topicURLs = UtilsString.GetSubStrings(source,
                newTopicUrlPrefix, newTopicUrlSuffix);
            topicTitles = UtilsString.GetSubStrings(source,
                newTopicTitlePrefix, newTopicTitleSuffix);
            topicTimes = UtilsString.GetSubStrings(source,
                newTopicTimePrefix, newTopicTimeSuffix);
            for (int i = 0; i < topicURLs.Count; i++)
            {
                // Creer een nieuwe HomepageTopic
                HomepageTopic topic = new HelpmijTopic();
                String topicUrl = topicURLs[i];
                String topicTitle = topicTitles[i];
                String topicTime = topicTimes[i];
                topic.SetURL(topicUrl);
                topic.SetTitle(topicTitle);
                DateTime time = new DateTime();
                DateTime.TryParse(topicTime, out time);
                topic.SetHour(time.Hour);
                topic.SetMinute(time.Minute);
                // Voeg de topic toe
                newTopics.Add(topic);
            }
            return newTopics;
        }
    }
}
