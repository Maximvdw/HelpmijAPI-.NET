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
using System.Text;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;

namespace mvdw.helpmij.utils
{
    /// <summary>
    /// HTTP Utilities
    /// </summary>
    internal class UtilsHTTP
    {
        /// <summary>
        /// Controlleer of er verbinding is met www.helpmij.nl
        /// </summary>
        /// <returns>Boolean - True bij verbinding</returns>
        public static Boolean IsInternetAvailable()
        {
            try
            {
                var ping = new Ping();
                // Constrolleer met google, want ICMP bij helpmij staat af
                var result = ping.Send("www.google.com");
                if (result.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                // False
                return false;
            }
        }

        /// <summary>
        /// Verkrijg de source code van een webpage
        /// </summary>
        /// <param name="postData">POST data</param>
        /// <param name="url">De url</param>
        /// <param name="cookies">De cookies</param>
        /// <returns>String - Broncode</returns>
        public static String GetPOSTSource(String postData, String url, ref CookieContainer cookies)
        {
            // Initializeer de request en response
            HttpWebResponse response;
            HttpWebRequest request;
            request = (HttpWebRequest)WebRequest.Create(url);
            // Request parameters instellen
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postData.Length;
            request.Method = "POST";
            request.AllowAutoRedirect = false;
            request.CookieContainer = cookies;
            request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.2.11) Gecko/20101012 Firefox/3.6.11";
            // Controlleer of er een proxy server moet worden gebruikt
            if (HelpmijConfig.proxy == true)
                request.Proxy = HelpmijConfig.proxyServer;

            Stream requestStream = request.GetRequestStream();
            Byte[] postBytes = Encoding.ASCII.GetBytes(postData);
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Flush();
            requestStream.Close();
            response = (HttpWebResponse)request.GetResponse();

            // Save de cookies
            foreach (Cookie tempCookie in response.Cookies)
            {
                cookies.Add(tempCookie);
            }

            // Lees de broncode
            String source;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                source = reader.ReadToEnd();
            }
            response.Close();

            // Return de source code
            return source;
        }

        /// <summary>
        /// Verkrijg de source code van een webpage
        /// </summary>
        /// <param name="url">De url</param>
        /// <param name="cookies">De cookies</param>
        /// <returns>String - Broncode</returns>
        public static String GetSource(String url, CookieContainer cookies)
        {
            // Initializeer de request en response
            HttpWebResponse response;
            HttpWebRequest request;
            request = (HttpWebRequest)WebRequest.Create(url);
            // Request parameters instellen
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "GET";
            request.AllowAutoRedirect = false;
            request.CookieContainer = cookies;
            request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.2.11) Gecko/20101012 Firefox/3.6.11";
            // Controlleer of er een proxy server moet worden gebruikt
            if (HelpmijConfig.proxy == true)
                request.Proxy = HelpmijConfig.proxyServer;

            response = (HttpWebResponse)request.GetResponse();

            // Save de cookies
            foreach (Cookie tempCookie in response.Cookies)
            {
                cookies.Add(tempCookie);
            }

            // Lees de broncode
            String source;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                source = reader.ReadToEnd();
            }
            response.Close();

            // Return de source code
            return source;
        }
    }
}
