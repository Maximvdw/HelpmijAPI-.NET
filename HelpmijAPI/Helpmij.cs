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
using mvdw.helpmij.utils;
using mvdw.helpmijapi.gebruiker;
using mvdw.helpmij.gebruiker;
using mvdw.helpmij.homepage;
using mvdw.helpmijapi.forum;

namespace mvdw.helpmijapi
{
    /// <summary>
    /// Helpmij Aplication Interface
    /// </summary>
    public class Helpmij
    {
        /// <summary>
        /// Aanmelden op Helpmij.nl
        /// </summary>
        /// <param name="username">Helpmij gebruikersnaam</param>
        /// <param name="password">Zuiver wachtwoord</param>
        /// <returns>Gebruiker</returns>
        public static Gebruiker Login(String username, String password)
        {
            // Zet om naar MD5 wachtwoord
            String passwordMD5 = UtilsEncryption.GetMD5Hash(password);
            return HelpmijLogin.Login(username, passwordMD5);
        }

        /// <summary>
        /// Verkrijg een gebruikers met zijn ID
        /// </summary>
        /// <param name="ID">Gebruikers ID</param>
        /// <returns>Gebruikers</returns>
        public static Gebruiker GetUser(int ID)
        {
            // Creeer een nieuwe gebruikers instantie
            Gebruiker user = new HelpmijGebruiker();
            user.SetUserID(ID);
            return user; // Return de gebruiker
        }

        /// <summary>
        /// Verkrijg een lijst met de nieuwe topics op de site
        /// </summary>
        /// <returns>List Topic - Topics</returns>
        public static List<HomepageTopic> GetNewTopics()
        {
            return HomepageTopics.GetNewTopics();
        }

        /// <summary>
        /// Verkrijg een lijst met de nieuwe onbeantwoorde topics op de site
        /// </summary>
        /// <returns>List Topic - Topics</returns>
        public static List<HomepageTopic> GetUnansweredTopics()
        {
            return HomepageTopics.GetUnansweredTopics();
        }

        /// <summary>
        /// Refresh Homepage cache
        /// </summary>
        public static void RefreshCache()
        {
            HomepageTopics.RefreshCache();
        }
    }
}
