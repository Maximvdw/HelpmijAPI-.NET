using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using mvdw.helpmijapi.forum;
using mvdw.helpmij.utils;
using mvdw.helpmij.forum;

namespace mvdw.helpmij.homepage
{
    /// <summary>
    /// Onbeantwoorde topics
    /// </summary>
    class UnansweredTopics : HelpmijData
    {
        /// <summary>
        /// Cache source code
        /// </summary>
        public static String source = "";


        /// <summary>
        /// Verkrijg de laatste onbeantwoorde topics van de site
        /// </summary>
        /// <returns>Lijst met topics</returns>
        public static List<HomepageTopic> GetTopics()
        {
            // Initializeer de output
            List<HomepageTopic> newTopics = new List<HomepageTopic>();
            // Maak een nieuwe cookiecontainer
            CookieContainer cookies = new CookieContainer();
            // Stel de URL samen
            String url = siteURL;
            // Verkrijg de broncode
            String source = UtilsHTTP.GetSource(url, cookies);
            UnansweredTopics.source = source;
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
