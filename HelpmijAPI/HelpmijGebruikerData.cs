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
using mvdw.helpmij.utils;
using mvdw.helpmijapi.gebruiker;

namespace mvdw.helpmij.gebruiker
{
    /// <summary>
    /// Laad en save gebruikersintellingen
    /// </summary>
    internal class HelpmijGebruikerData : HelpmijData
    {
        /* Prive Gegevens van de Gebruiker */
        #region Prive Gebruikers Data
        /// <summary>
        /// Verkrijg de gebruikers data, en save het
        /// </summary>
        /// <param name="userHelpmij">HelpmijGebruiker</param>
        public static void GetPrivateData(HelpmijGebruiker userHelpmij)
        {
            if (UtilsHTTP.IsInternetAvailable())
            {
                // Stel de URL samen
                String url = siteURL + privateProfile;
                // Verkrijg de gebruikers ID
                int id = userHelpmij.GetUserID();
                if (id != -1)
                {
                    // Verkrijg Webpagina
                    String source = UtilsHTTP.GetSource(url, userHelpmij.GetCookies());

                    // SECURITY TOKEN
                    userHelpmij.sectoken =
                        UtilsString.GetSubStrings(source, vartokenPrefix, vartokenSuffix)[0];

                    // AVATAR
                    userHelpmij.avatarUrl =
                        avatarUrlPrefix + id;

                    // Start met het ophalen van de gegevens...
                    try
                    {
                        userHelpmij.website = // WEBSITE
                            UtilsString.GetSubStrings(source, websitePrefix, websiteSuffix)[0];
                    }
                    catch (Exception) { }
                    try
                    {
                        userHelpmij.msn = // MSN
                            UtilsString.GetSubStrings(source, msnPrefix, msnSuffix)[0];
                    }
                    catch (Exception) { }
                    try
                    {
                        userHelpmij.icq = // ICQ
                            UtilsString.GetSubStrings(source, icqPrefix, icqSuffix)[0];
                    }
                    catch (Exception) { }
                    try
                    {
                        userHelpmij.aim = // AIM
                            UtilsString.GetSubStrings(source, aimPrefix, aimSuffix)[0];
                    }
                    catch (Exception) { }
                    try
                    {
                        userHelpmij.skype = // Skype
                            UtilsString.GetSubStrings(source, skypePrefix, skypeSuffix)[0];
                    }
                    catch (Exception) { }
                    try
                    {
                        userHelpmij.yahoo = // Yahoo
                            UtilsString.GetSubStrings(source, yahooPrefix, yahooSuffix)[0];
                    }
                    catch (Exception) { }
                    try
                    {
                        userHelpmij.biografie = // Biografie
                            UtilsString.GetSubStrings(source, biografiePrefix, biografieSuffix)[0];
                    }
                    catch (Exception) { }
                    try
                    {
                        userHelpmij.hobbys = // Hobby's
                            UtilsString.GetSubStrings(source, biografiePrefix, biografieSuffix)[0];
                    }
                    catch (Exception) { }
                    try
                    {
                        userHelpmij.woonplaats = // Woonplaats
                            UtilsString.GetSubStrings(source, woonplaatsPrefix, woonplaatsSuffix)[0];
                    }
                    catch (Exception) { }
                    try
                    {
                        userHelpmij.beroep = // Beroep
                            UtilsString.GetSubStrings(source, beroepPrefix, beroepSuffix)[0];
                    }
                    catch (Exception) { }
                    try
                    {
                        userHelpmij.birthday_dd = // Verjaardag
                            int.Parse(UtilsString.GetSubStrings(source, selectedPrefix, selectedSuffix)[1]);
                        userHelpmij.birthday_MM = // Verjaardag
                            int.Parse(UtilsString.GetSubStrings(source, selectedPrefix, selectedSuffix)[0]);
                    }
                    catch (Exception) { }
                    try
                    {
                        userHelpmij.birthday_yyyy = // Verjaardag
                            int.Parse(UtilsString.GetSubStrings(source, jaarPrefix, jaarSuffix)[0]);
                    }
                    catch (Exception) { }
                    try
                    {
                        userHelpmij.birthday = // Verjaardag
                            new DateTime(userHelpmij.birthday_yyyy,
                                userHelpmij.birthday_MM,
                                userHelpmij.birthday_dd);
                    }
                    catch (Exception) { }
                }
            }
            else
            {
                // Error geen internet
                throw new UnableToConnectException("Kan geen verbinding met Helpmij.nl maken!");
            }
        }

        /// <summary>
        /// Save de instellingen op Helpmij
        /// </summary>
        /// <param name="userHelpmij">HelpmijGebruiker</param>
        public static void SetPrivateData(HelpmijGebruiker userHelpmij)
        {
            if (UtilsHTTP.IsInternetAvailable())
            {
                // POST data samenstellen
                String postData = actionUpdateArg + "&" + additionalArgs + "&" +
                    tokenArg + "=" + userHelpmij.sectoken + "&" + // Security Token
                    msnField + "=" + userHelpmij.msn + "&" + // MSN Name
                    websiteField + "=" + userHelpmij.website + "&" + // Website
                    jabberField + "=" + userHelpmij.jabber + "&" + // Jabber
                    skypeField + "=" + userHelpmij.skype + "&" + // Skype
                    yahooField + "=" + userHelpmij.yahoo + "&" + // Yahoo
                    icqField + "=" + userHelpmij.icq + "&" + // ICQ
                    aimField + "=" + userHelpmij.aim + "&" + // AIM
                    biografieField + "=" + userHelpmij.biografie + "&" + // Biografie
                    hobbysField + "=" + userHelpmij.hobbys + "&" + // Hobby's
                    woonplaatsField + "=" + userHelpmij.woonplaats + "&" + // Woonplaats
                    beroepField + "=" + userHelpmij.beroep;
                // Cookie container maken
                CookieContainer cookies = userHelpmij.cookies;
                // Url samenstellen
                String url = siteURL + privateProfile;
                // Post de data
                String source = UtilsHTTP.GetPOSTSource(postData, url, ref cookies);
                if (!source.Contains("Bedankt voor het updaten van uw profiel,"))
                {
                    // Error, niet opgeslagen
                    String errorMessage = UtilsString.GetSubStrings(source, errorPrefix, errorSuffix)[0];
                    throw new UnableToSaveUserException(errorMessage);
                }
            }
            else
            {
                // Error geen internet
                throw new UnableToConnectException("Kan geen verbinding met Helpmij.nl maken!");
            }
        }
        #endregion

        public static void GetSignature()
        {
        }
    }
}
