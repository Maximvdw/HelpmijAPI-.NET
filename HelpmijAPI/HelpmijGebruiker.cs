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
using System.Drawing;
using System.IO;
using mvdw.helpmijapi.gebruiker;
using mvdw.helpmijapi.gebruiker.exceptions;

namespace mvdw.helpmij.gebruiker
{
    /// <summary>
    /// Verkrijg Gebruiker Identificatie
    /// </summary>
    class HelpmijGebruiker : GebruikerData
    {
        /// <summary>
        /// User ID
        /// </summary>
        public int userID = -1;
        /// <summary>
        /// Security Token
        /// </summary>
        public String sectoken = null;
        /// <summary>
        /// Is de gebruiker online
        /// </summary>
        public Boolean online = false;
        /// <summary>
        /// User Session Cookies
        /// </summary>
        public CookieContainer cookies = null;
        /// <summary>
        /// Gebruikers Nickname
        /// </summary>
        public String nickname = null;
        /// <summary>
        /// Verjaardag jaar
        /// </summary>
        public int birthday_yyyy = -1;
        /// <summary>
        /// Verjaardag Maand
        /// </summary>
        public int birthday_MM = -1;
        /// <summary>
        /// Verjaar dag
        /// </summary>
        public int birthday_dd = -1;
        /// <summary>
        /// Gebruiker verjaardag
        /// </summary>
        public DateTime birthday = DateTime.MinValue;
        /// <summary>
        /// Gebruikers privacy
        /// </summary>
        public int privacy = -1;
        /// <summary>
        /// Gebruikers website
        /// </summary>
        public String website = null;
        /// <summary>
        /// Gebruikers MSN naam
        /// </summary>
        public String msn = null;
        /// <summary>
        /// Gebruikers Avatar
        /// </summary>
        public String avatarUrl = null;
        /// <summary>
        /// Gebruikers Avatar
        /// </summary>
        public Image avatar = null;
        /// <summary>
        /// Gebruikers ICQ
        /// </summary>
        public String icq = null;
        /// <summary>
        /// Gebruikers Yahoo
        /// </summary>
        public String yahoo = null;
        /// <summary>
        /// Gebruikers Skype
        /// </summary>
        public String skype = null;
        /// <summary>
        /// Gebruikers Jabber
        /// </summary>
        public String jabber = null;
        /// <summary>
        /// Gebruikers AIM
        /// </summary>
        public String aim = null;
        /// <summary>
        /// Gebruikers Biografie
        /// </summary>
        public String biografie = null;
        /// <summary>
        /// Gebruikers Hobby's
        /// </summary>
        public String hobbys = null;
        /// <summary>
        /// Gebruikers Beroep
        /// </summary>
        public String beroep = null;
        /// <summary>
        /// Gebruikers Woonplaats
        /// </summary>
        public String woonplaats = null;
        /// <summary>
        /// Signature BB code
        /// </summary>
        public String signatureBB = null;
        /// <summary>
        /// Signature HTML code
        /// </summary>
        public String signatureHTML = null;


        /// <summary>
        /// Verkrijg GebruikersData
        /// </summary>
        public GebruikerData GetUserData()
        {
            if (GetCookies() != null)
            {
                // Laad de instellingen van het online profiel
                HelpmijGebruikerData.GetPrivateData(this);
                HelpmijGebruikerData.GetSignature(this);
            }
            else
            {
                // Laad publieke instellingen

            }
            return this;
        }

        /// <summary>
        /// Sla de wijzigingen op
        /// </summary>
        /// <exception cref="UserNotLoggedInException">Wanneer cookies null zijn</exception>
        public void SetUserData()
        {
            if (GetCookies() != null)
            {
                // Save de instellingen op het online profiel
                HelpmijGebruikerData.SetPrivateData(this);
            }
            else
            {
                // Error geen toegang to gebruikersintellingen
                throw new UserNotLoggedInException("Geen toegang tot gebruikersintellingen!");
            }
        }

        /// <summary>
        /// Verkrijg de Gebruikers ID
        /// </summary>
        /// <returns>int - ID</returns>
        public int GetUserID()
        {
            return userID;
        }

        /// <summary>
        /// Set de gebruikers ID
        /// </summary>
        /// <param name="ID">int - ID</param>
        public void SetUserID(int ID)
        {
            userID = ID;
        }

        /// <summary>
        /// Verkrijg de Security token
        /// </summary>
        /// <returns>String - Security Token</returns>
        public String GetSecurityToken()
        {
            return sectoken;
        }

        /// <summary>
        /// Set de gebruikers ID
        /// </summary>
        /// <param name="sectoken">String - Security Token</param>
        public void SetSecurityToken(String sectoken)
        {
            this.sectoken = sectoken;
        }

        /// <summary>
        /// Verkrijg of de gebruiker online is
        /// </summary>
        /// <returns>Boolean</returns>
        public Boolean IsOnline()
        {
            // Poll zowizo om te kijken of de gebruiker online is
            return online;
        }

        /// <summary>
        /// Set de gebruiker online
        /// </summary>
        public void SetOnline()
        {
            online = true;
        }

        /// <summary>
        /// Set de gebruiker offline
        /// </summary>
        public void SetOffline()
        {
            online = false;
        }

        /// <summary>
        /// Verkrijg de avatar url
        /// </summary>
        /// <returns>String - URL naar avatar</returns>
        public String GetAvatarUrl()
        {
            return avatarUrl;
        }

        /// <summary>
        /// Verkrijg de avatar Image
        /// </summary>
        /// <returns>Image - Avatar</returns>
        public Image GetAvatar()
        {
            // Stream the image from the url
            var request = WebRequest.Create(avatarUrl);
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                return Image.FromStream(stream);
            }
        }

        /// <summary>
        /// Verkrijg de cookies van de sessie
        /// </summary>
        /// <returns>CookieContainer - Cookies</returns>
        public CookieContainer GetCookies()
        {
            return cookies;
        }

        /// <summary>
        /// Set de ccokies van de sessie
        /// </summary>
        /// <param name="container"></param>
        public void SetCookies(CookieContainer container)
        {
            cookies = container;
        }

        /// <summary>
        /// Verkrijg de NickName
        /// </summary>
        /// <returns>String - Nickname</returns>
        public String GetNickname()
        {
            return nickname;
        }

        /// <summary>
        /// Set de gebruiker Nickname
        /// </summary>
        /// <param name="nickname">String - Nickname</param>
        public void SetNickname(String nickname)
        {
            this.nickname = nickname;
        }

        /// <summary>
        /// Verkrijg de geboortedatum
        /// </summary>
        /// <returns>DateTime - Geboortedatum</returns>
        public DateTime GetBirthday()
        {
            return birthday;
        }

        /// <summary>
        /// Set de leeftijd van de gebruiker
        /// </summary>
        /// <returns>DateTime - Geboortedatum</returns>
        public void SetBirthday(DateTime birthday)
        {
            this.birthday = birthday;
        }

        /// <summary>
        /// Verkrijg de geboortedag van de gebruiker
        /// </summary>
        /// <returns>int - Dag</returns>
        public int GetBirthdayDay()
        {
            return birthday_dd;
        }

        /// <summary>
        /// Set de geboortedag van de gebruiker
        /// </summary>
        /// <param name="day">int - Dag</param>
        public void SetBirthdayDay(int day)
        {
            this.birthday_dd = day;
        }

        /// <summary>
        /// Verkrijg de geboorte maand van de gebruiker
        /// </summary>
        /// <returns>int - Maand</returns>
        public int GetBirthdayMonth()
        {
            return birthday_MM;
        }

        /// <summary>
        /// Set de geboorte maand van de gebruiker
        /// </summary>
        /// <param name="month">int - Maand</param>
        public void SetBirthdayMonth(int month)
        {
            this.birthday_MM = month;
        }

        /// <summary>
        /// Verkrijg het geboortejaar van de gebruiker
        /// </summary>
        /// <returns>int - Jaar</returns>
        public int GetBirthdayYear()
        {
            return birthday_yyyy;
        }

        /// <summary>
        /// Set het geboortejaar van de gebruiker
        /// </summary>
        /// <param name="year">int - Year</param>
        public void SetBirthdayYear(int year)
        {
            this.birthday_yyyy = year;
        }

        /// <summary>
        /// Verkrijg de privacy instellingen omtrend de leeftijd
        /// </summary>
        /// <returns>int - Gebruiker Privacy</returns>
        public int GetPrivacy()
        {
            return privacy;
        }

        /// <summary>
        /// Set de gebruikers privacy
        /// </summary>
        /// <param name="privacy">int - GebruikerPrivacy</param>
        public void SetPrivacy(int privacy)
        {
            this.privacy = privacy;
        }

        /// <summary>
        /// Verkrijg de website van de gebruiker
        /// </summary>
        /// <returns>String - website</returns>
        public String GetWebsite()
        {
            return website;
        }

        /// <summary>
        /// Set de website van de gebruiker
        /// </summary>
        /// <param name="website">String - Website</param>
        public void SetWebsite(String website)
        {
            this.website = website;
        }

        /// <summary>
        /// Verkrijg de MSN naam van de gebruiker
        /// </summary>
        /// <returns>String - MSN Name</returns>
        public String GetMSN()
        {
            return msn;
        }

        /// <summary>
        /// Set de MSN naam van de gebruiker
        /// </summary>
        /// <param name="msn">String - MSN Name</param>
        public void SetMSN(String msn)
        {
            this.msn = msn;
        }

        /// <summary>
        /// Verkrijg de ICQ nummer van de gebruiker
        /// </summary>
        /// <returns>String - ICQ number</returns>
        public String GetICQ()
        {
            return icq;
        }

        /// <summary>
        /// Set de ICQ nummer van de gebruiker
        /// </summary>
        /// <param name="icq">String - ICQ number</param>
        public void SetICQ(String icq)
        {
            this.icq = icq;
        }

        /// <summary>
        /// Verkrijg de AIM naam van de gebruiker
        /// </summary>
        /// <returns>String - AIM Name</returns>
        public String GetAIM()
        {
            return aim;
        }

        /// <summary>
        /// Set de AIM naam van de gebruiker
        /// </summary>
        /// <param name="aim">String - AIM Name</param>
        public void SetAIM(String aim)
        {
            this.aim = aim;
        }

        /// <summary>
        /// Verkrijg de Yahoo van de gebruiker
        /// </summary>
        /// <returns>String - Yahoo</returns>
        public String GetYahoo()
        {
            return yahoo;
        }

        /// <summary>
        /// Set de Yahoo van de gebruiker
        /// </summary>
        /// <param name="yahoo">String - Yahoo</param>
        public void SetYahoo(String yahoo)
        {
            this.yahoo = yahoo;
        }

        /// <summary>
        /// Verkrijg de Skype naam van de gebruiker
        /// </summary>
        /// <returns>String - Skype Name</returns>
        public String GetSkype()
        {
            return skype;
        }

        /// <summary>
        /// Set de Skype naam van de gebruiker
        /// </summary>
        /// <param name="skype">String - Skype Name</param>
        public void SetSkype(String skype)
        {
            this.skype = skype;
        }

        /// <summary>
        /// Verkrijg de Jabber IM van de gebruiker
        /// </summary>
        /// <returns>String - Jabber IM</returns>
        public String GetJabber()
        {
            return jabber;
        }

        /// <summary>
        /// Set de Jabber IM van de gebruiker
        /// </summary>
        /// <param name="jabber">String - Jabber IM</param>
        public void SetJabber(String jabber)
        {
            this.jabber = jabber;
        }

        /// <summary>
        /// Verkrijg de Biografie van de gebruiker
        /// </summary>
        /// <returns>String - Biografie</returns>
        public String GetBiografie()
        {
            return biografie;
        }

        /// <summary>
        /// Set de Biografie van de gebruiker
        /// </summary>
        /// <param name="biografie">String - Biografie</param>
        public void SetBiografie(String biografie)
        {
            this.biografie = biografie;
        }

        /// <summary>
        /// Verkrijg de Hobbys van de gebruiker
        /// </summary>
        /// <returns>String - Hobbys</returns>
        public String GetHobbys()
        {
            return hobbys;
        }

        /// <summary>
        /// Set de Hobbys van de gebruiker
        /// </summary>
        /// <param name="hobbys">String - Hobbys</param>
        public void SetHobbys(String hobbys)
        {
            this.hobbys = hobbys;
        }

        /// <summary>
        /// Verkrijg het beroep van de gebruiker
        /// </summary>
        /// <returns>String - Beroep</returns>
        public String GetBeroep()
        {
            return beroep;
        }

        /// <summary>
        /// Set de Beroep van de gebruiker
        /// </summary>
        /// <param name="beroep">String - Beroep</param>
        public void SetBeroep(String beroep)
        {
            this.beroep = beroep;
        }

        /// <summary>
        /// Verkrijg de Woonplaats van de gebruiker
        /// </summary>
        /// <returns>String - Woonplaats</returns>
        public String GetWoonplaats()
        {
            return woonplaats;
        }

        /// <summary>
        /// Set de Woonplaats van de gebruiker
        /// </summary>
        /// <param name="woonplaats">String - Woonplaats</param>
        public void SetWoonplaats(String woonplaats)
        {
            this.woonplaats = woonplaats;
        }

        /// <summary>
        /// Refresh de gegevens
        /// </summary>
        public void refreshData()
        {

        }
    }
}
