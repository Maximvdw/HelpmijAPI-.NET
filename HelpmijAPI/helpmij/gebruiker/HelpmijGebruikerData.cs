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
using mvdw.helpmijapi.gebruiker.exceptions;
using mvdw.helpmijapi.forum;

namespace mvdw.helpmij.gebruiker
{
    /// <summary>
    /// Laad en save gebruikersintellingen
    /// </summary>
    internal class HelpmijGebruikerData : HelpmijData
    {
        /// <summary>
        /// HM Gebruiker Data
        /// </summary>
        private static HMGebruikerData s = new HMGebruikerData();

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
                            UtilsString.GetSubStrings(source, hobbysPrefix, hobbysSuffix)[0];
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

        /* Prive Gegevens van de Signature van de gebruiker */
        #region Prive Signature Data
        /// <summary>
        /// Verkrijg de handtekening gegevens
        /// </summary>
        /// <param name="userHelpmij">HelpmijGebruiker</param>
        public static void GetSignature(HelpmijGebruiker userHelpmij)
        {
            if (UtilsHTTP.IsInternetAvailable())
            {
                // Stel de URL samen
                String url = siteURL + signaturePHP;
                // Verkrijg de gebruikers ID
                int id = userHelpmij.GetUserID();
                if (id != -1)
                {
                    // Verkrijg de source code
                    String source = UtilsHTTP.GetSource(url, userHelpmij.GetCookies());
                    try
                    {
                        userHelpmij.signatureHTML = UtilsString.GetSubStrings(source,
                            signatureHTMLPrefix, signatureHTMLSuffix)[0]; // Signature HTML
                    }
                    catch (Exception) { }
                    try
                    {
                        userHelpmij.signatureBB = UtilsString.GetSubStrings(source,
                            signatureBBPrefix, signatureBBSuffix)[0]; // Signature BB
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
        #endregion

        /// <summary>
        /// Verkrijg posts die door de gebruiker gestart zijn
        /// </summary>
        /// <param name="userHelpmij">HelpmijGebruiker - userHelpmij</param>
        public static void GetPostsStarted(HelpmijGebruiker userHelpmij)
        {
            if (UtilsHTTP.IsInternetAvailable())
            {
                // Stel de URL samen
                String url = siteURL + s.searchPHP + s.searchPostsArgs + userHelpmij.GetUserID();
                // Verkrijg de gebruikers ID
                int id = userHelpmij.GetUserID();
                if (id != -1)
                {
                    // Verkrijg de source code
                    String source = UtilsHTTP.GetSource(url, userHelpmij.GetCookies());
                    try
                    {
                        List<String> topicUrls = (List<String>)UtilsString.GetSubStrings(source,
                            "<a class=\"title\" href=\"", "\" id=\"thread_title_"); // Topic Urls

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
        /// Verkrijg de publieke data van de gebruiker
        /// </summary>
        /// <param name="userHelpmij">Helpmij Gebruiker</param>
        public static void GetPublicData(HelpmijGebruiker userHelpmij)
        {
            if (UtilsHTTP.IsInternetAvailable())
            {
                // Stel de URL samen
                String url = siteURL + s.publicprofilePHP + userHelpmij.GetUserID();
                // Verkrijg de gebruikers ID
                int id = userHelpmij.GetUserID();
                if (id != -1)
                {
                    // Verkrijg de source code
                    String source = UtilsHTTP.GetSource(url, userHelpmij.GetCookies());
                    try
                    {
                        userHelpmij.userRank = UtilsString.GetSubStrings(source,
                            s.userstatusPrefix, s.userstatusSuffix)[0]; // User Rank
                        if (userHelpmij.userRank.Contains("<br />Verenigingslid"))
                        {
                            userHelpmij.userRank.Replace("<br />Verenigingslid", "");
                            // Verenigingslid
                            userHelpmij.IsVerenigingslid = true;
                        }
                    }
                    catch (Exception) { }
                    try
                    {
                        userHelpmij.totalPosts = int.Parse(UtilsString.GetSubStrings(source,
                            s.totalPostsPrefix, s.totalPostsSuffix)[0]); // Totaal aantal berichten
                    }
                    catch (Exception) { }
                    try
                    {
                        userHelpmij.postEaDay = Decimal.Parse(UtilsString.GetSubStrings(source,
                            s.postdayPrefix, s.postdaySuffix)[0]); // Totaal aantal berichten
                    }
                    catch (Exception) { }
                    try
                    {
                        String registration = UtilsString.GetSubStrings(source,
                            s.registeredPrefix, s.registeredSuffix)[0]; // Registratie
                        userHelpmij.registrationDate = DateTime.Parse(registration);
                        userHelpmij.registrationDay = userHelpmij.registrationDate.Day;
                        userHelpmij.registrationMonth = userHelpmij.registrationDate.Month;
                        userHelpmij.registrationYear = userHelpmij.registrationDate.Year;
                    }
                    catch (Exception) { }
                    try
                    {
                        String lastactivity = UtilsString.GetSubStrings(source,
                            s.lastactivityPrefix, s.lastactivitySuffix)[0]; // Laatste Activiteit
                        userHelpmij.lastactivityDate = DateTime.Parse(lastactivity);
                        userHelpmij.lastactivityDay = userHelpmij.lastactivityDate.Day;
                        userHelpmij.lastactivityMonth = userHelpmij.lastactivityDate.Month;
                        userHelpmij.lastactivityYear = userHelpmij.lastactivityDate.Year;
                    }
                    catch (Exception) { }
                    try
                    {
                        userHelpmij.nickname = UtilsString.GetSubStrings(source,
                            s.publicuserPrefix, s.publicuserSuffix)[0]; // Gebruikersnaam
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
    }
}
