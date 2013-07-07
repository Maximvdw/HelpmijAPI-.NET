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
using System.IO;
using mvdw.helpmij.utils;
using mvdw.helpmijapi.gebruiker;

namespace mvdw.helpmij.gebruiker
{
    /// <summary>
    /// Aanmelden op Helpmij.nl
    /// </summary>
    class HelpmijLogin : HelpmijData
    {
        /// <summary>
        /// Aanmelden op Helpmij.nl
        /// </summary>
        /// <param name="username">Helpmij Gebruikersnaam</param>
        /// <param name="passwordMD5">Wachwoord MD5 Hash</param>
        /// <returns>int - ID</returns>
        /// <exception cref="CredentialsWrongException">Foutieve inlog gegevens</exception>
        public static Gebruiker Login(String username, String passwordMD5)
        {
            if (UtilsHTTP.IsInternetAvailable())
            {
                // POST data samenstellen
                String postData = usernameArg + "=" + username +
                    "&" + passwordMD5Arg + "=" + passwordMD5 + "&" +
                    passwordMD5utfArg + "=" + passwordMD5 + "&" + additionalArgs +
                    "&" + actionLoginArg + "&" + passwordArg + "=";
                // Cookie container maken
                CookieContainer cookies = new CookieContainer();
                // Url samenstellen
                String url = siteURL + loginPHP;

                // Verkrijg de broncode
                String source = UtilsHTTP.GetPOSTSource(postData, url, ref cookies);
                // Verkrijg de userID
                try
                {
                    // Verkrijg de USER ID
                    int id = int.Parse(UtilsString.GetSubStrings(source, varidPrefix, varidSuffix)[0]);
                    if (id == 0)
                    {
                        // Inloggen mislukt
                        throw new CredentialsWrongException("Verkeerde gebruikersnaam of wachtwoord ingevoerd!");
                    }
                    else
                    {
                        Gebruiker user = new HelpmijGebruiker();
                        user.SetCookies(cookies);
                        user.SetUserID(id);
                        user.SetNickname(username);
                        user.SetOnline();
                        return user; // Enkel cookies , id , nick en sectoken
                    }
                }
                catch (Exception)
                {
                    // Error
                    return null;
                }
            }
            else
            {
                // Error geen internet
                throw new UnableToConnectException("Kan geen verbinding met Helpmij.nl maken!");
            }
        }
    }
}
