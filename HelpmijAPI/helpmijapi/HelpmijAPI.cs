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
using mvdw.helpmijapi.gebruiker;
using mvdw.helpmij.gebruiker;
using mvdw.helpmij;

namespace mvdw.helpmijapi
{
    /// <summary>
    /// Helpmij Aplication Interface
    /// </summary>
    public class HelpmijAPI
    {
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
        public static Gebruiker GetAuthor()
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
            HelpmijConfig.proxyServer = proxyServer;
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
            HelpmijConfig.proxyServer = proxyServer;
        }

        /// <summary>
        /// Stop het gebruik van de proxy server
        /// </summary>
        public static void DisableProxy()
        {
            HelpmijConfig.proxy = false; // Zet proxy op af
        }

        /// <summary>
        /// Gebruik een proxy server
        /// </summary>
        public static void EnableProxy()
        {
            HelpmijConfig.proxy = true; // Zet proxy op aan
        }
    }
}
