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
using System.Net;
using mvdw.helpmijapi.user;
using mvdw.helpmij.user;
using mvdw.helpmij;
using mvdw.helpmij.forum;

namespace mvdw.helpmijapi
{
    /// <summary>
    /// Helpmij Aplication Interface
    /// </summary>
    public class HelpmijAPI
    {
        /// <summary>
        /// Total Downloaded
        /// </summary>
        internal static Decimal _downloadSize = 0;
        /// <summary>
        /// Total Uploaded
        /// </summary>
        internal static Decimal _uploadSize = 0;


        /// <summary>
        /// Verkrijg de API versie
        /// </summary>
        /// <returns></returns>
        public static Version GetVersion()
        {
            return Environment.Version;
        }

        /// <summary>
        /// Verkrijg de gebruiker die deze api maakte (Maximvdw)
        /// </summary>
        /// <returns>Gebruiker - Maximvdw</returns>
        public static IUser GetAuthor()
        {
            return Helpmij.GetUser(137609);
        }

        /// <summary>
        /// Configureer een proxy server
        /// </summary>
        /// <param name="url">De URL van de proxy server</param>
        /// <param name="port">De poort van de proxy server</param>
        public static void SetProxy(String url, int port)
        {
            IWebProxy proxyServer = new WebProxy(url, port);
            HelpmijConfig.PROXY_SERVER = proxyServer;
        }

        /// <summary>
        /// Configureer een proxy server
        /// </summary>
        /// <param name="url">De URL van de proxy server</param>
        /// <param name="port">De poort van de proxy server</param>
        /// <param name="username">Username voor proxy</param>
        /// <param name="password">Wachtwoord voor proxy</param>
        public static void SetProxy(String url, int port, String username, String password)
        {
            ICredentials credentials = new NetworkCredential(username, password);
            IWebProxy proxyServer = new WebProxy(url + ":" + port, true, null, credentials);
            HelpmijConfig.PROXY_SERVER = proxyServer;
        }

        /// <summary>
        /// Gebruik een proxy server
        /// </summary>
        public static void EnableProxy(Boolean enable)
        {
            HelpmijConfig.PROXY = enable; // Zet proxy op aan
        }

        /// <summary>
        /// Verkrijg het aantal byte dat gedownload is
        /// </summary>
        /// <returns>Size in byte</returns>
        public static Decimal GetDownloadSize()
        {
            return _downloadSize;
        }

        /// <summary>
        /// Verkrijg het aantal byte dat geupload is
        /// </summary>
        /// <returns>Size in byte</returns>
        public static Decimal GetUploadSize()
        {
            return _uploadSize;
        }

        /// <summary>
        /// Controlleer op updates voor de API
        /// </summary>
        /// <returns>Boolean - If update found</returns>
        public static Boolean CheckForUpdates()
        {
            return false; // Under Construction
        }
    }
}
