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
using mvdw.helpmij.utils;

namespace mvdw.helpmij.gebruiker
{
    /// <summary>
    /// Verkrijg Gebruiker Identificatie
    /// </summary>
    internal class HelpmijGebruiker : GebruikerData
    {
        /// <summary>
        /// HM Gebruiker Data
        /// </summary>
        private static HMGebruikerData s = new HMGebruikerData();

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
        public int agePrivacy = -1;
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
        /// Registratie jaar
        /// </summary>
        public int registrationYear = -1;
        /// <summary>
        /// Registratie maand
        /// </summary>
        public int registrationMonth = -1;
        /// <summary>
        /// Registratie dag
        /// </summary>
        public int registrationDay = -1;
        /// <summary>
        /// Registratie datum
        /// </summary>
        public DateTime registrationDate = DateTime.MinValue;
        /// <summary>
        /// Laatste Activiteit
        /// </summary>
        public int lastactivityYear = -1;
        /// <summary>
        /// Laatste Activiteit
        /// </summary>
        public int lastactivityMonth = -1;
        /// <summary>
        /// Laatste Activiteit
        /// </summary>
        public int lastactivityDay = -1;
        /// <summary>
        /// Laatste Activiteit
        /// </summary>
        public DateTime lastactivityDate = DateTime.MinValue;
        /// <summary>
        /// Gebruikers Rank
        /// </summary>
        public String userRank = null;
        /// <summary>
        /// Totaal aantal posts
        /// </summary>
        public int totalPosts = -1;
        /// <summary>
        /// Gemiddeld aantal posts per dag
        /// </summary>
        public Decimal postEaDay = -1;
        /// <summary>
        /// Gebruikers Profiel
        /// </summary>
        public String profileURL = null;
        /// <summary>
        /// Verenigingslid
        /// </summary>
        public Boolean vererningingslid = false;
        /// <summary>
        /// Gebruiker systeem
        /// </summary>
        public List<GebruikerSysteem> systems = new List<GebruikerSysteem>();


        /// <summary>
        /// Reset gebruiekrs wachtwoord
        /// </summary>
        /// <param name="email">String - Email</param>
        public static void ResetPassword(String email)
        {
            try
            {
                CookieContainer cookies = new CookieContainer();
                // Get Source
                UtilsHTTP.GetPOSTSource(s.sendPassword + email, s.siteURL + s.loginPHP, ref cookies);
            }
            catch (Exception ex)
            {
                // Error
            }
        }

        /// <summary>
        /// Controlleer of een variabele geset is
        /// </summary>
        /// <param name="var">Variabele</param>
        private void CheckVariable(Object var)
        {
            if (var is int)
            {
                if ((int)var != -1)
                {
                    return;
                }
            }
            else if (var is String)
            {
                if ((String)var != null)
                {
                    return;
                }
            }
            else if (var is DateTime)
            {
                if ((DateTime)var != DateTime.MinValue)
                {
                    return;
                }
            }
            else
            {
                return;
            }
            // Foutmedling
            throw new UserDataNotFound(
                "De gegevens voor de gebruiker zijn niet gevonden!");
        }

        /// <summary>
        /// Verkrijg GebruikersData
        /// </summary>
        /// <param name="fetch">Also fetch data?</param>
        public GebruikerData GetUserData(Boolean fetch)
        {
            if (fetch)
            {
                if (GetCookies() != null)
                {
                    // Laad de instellingen van het online profiel
                    HelpmijGebruikerData.GetPublicData(this); // Bevat apparte gegevens
                    HelpmijGebruikerData.GetPrivateData(this);
                    HelpmijGebruikerData.GetSignature(this);
                }
                else
                {
                    // Laad publieke instellingen
                    HelpmijGebruikerData.GetPublicData(this);
                }
            }
            return this;
        }

        /// <summary>
        /// Set de avatar URL
        /// </summary>
        /// <param name="url"></param>
        public void SetAvatarUrl(String url)
        {
            this.avatarUrl = url;
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
            CheckVariable(userID);
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
            CheckVariable(sectoken);
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
            CheckVariable(avatarUrl);
            return avatarUrl;
        }

        /// <summary>
        /// Verkrijg de avatar Image
        /// </summary>
        /// <returns>Image - Avatar</returns>
        public Image GetAvatar()
        {
            CheckVariable(avatarUrl);
            if (avatar != null)
                return avatar;
            // Stream the image from the url
            var request = WebRequest.Create(avatarUrl);
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                avatar = Image.FromStream(stream);
                return avatar;
            }
        }

        /// <summary>
        /// Verkrijg de cookies van de sessie
        /// </summary>
        /// <returns>CookieContainer - Cookies</returns>
        public CookieContainer GetCookies()
        {
            CheckVariable(cookies);
            return cookies;
        }

        /// <summary>
        /// Set de ccokies van de sessie
        /// </summary>
        /// <param name="container"></param>
        public void SetCookies(CookieContainer container)
        {
            CheckVariable(container);
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
            CheckVariable(birthday);
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
            CheckVariable(birthday_dd);
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
            CheckVariable(birthday_MM);
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
            CheckVariable(birthday_yyyy);
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
        public int GetAgePrivacy()
        {
            CheckVariable(agePrivacy);
            return agePrivacy;
        }

        /// <summary>
        /// Set de gebruikers privacy
        /// </summary>
        /// <param name="privacy">int - GebruikerPrivacy</param>
        public void SetPrivacy(int privacy)
        {
            this.agePrivacy = privacy;
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
        /// Verkrijg de HTML versie van de handtekening
        /// </summary>
        /// <returns>String - Handtekening</returns>
        public String GetSignatureHTML()
        {
            return signatureHTML;
        }

        /// <summary>
        /// Set de HTML versie van de handtekening
        /// </summary>
        /// <param name="signature">String - Handtekening</param>
        public void SetSignatureHTML(String signature)
        {
            this.signatureHTML = signature;
        }

        /// <summary>
        /// Verkrijg de BB code van de handtekening
        /// </summary>
        /// <returns>String - Handtekening</returns>
        public String GetSignatureBB()
        {
            return signatureBB;
        }

        /// <summary>
        /// Set de BB code van de handtekening
        /// </summary>
        /// <param name="signature">String - Handtekening</param>
        public void SetSignatureBB(String signature)
        {
            this.signatureBB = signature;
        }

        /// <summary>
        /// Verkrijg de registratiedatum
        /// </summary>
        /// <returns>DateTime - Registratie</returns>
        public DateTime GetRegistrationDate()
        {
            return registrationDate;
        }

        /// <summary>
        /// Set de registratiedatum
        /// </summary>
        /// <param name="registration">DateTime - Registratie</param>
        public void SetRegistrationDate(DateTime registration)
        {
        }

        /// <summary>
        /// Verkrijg het jaar van de registratie
        /// </summary>
        /// <returns>int - Jaar</returns>
        public int GetRegistrationYear()
        {
            return registrationYear;
        }

        /// <summary>
        /// Set het jaar van de registratie
        /// </summary>
        /// <param name="year">int - Jaar</param>
        public void SetRegistrationYear(int year)
        {
        }

        /// <summary>
        /// Verkrijg de maand van de registratie
        /// </summary>
        /// <returns>int - Maand</returns>
        public int GetRegistrationMonth()
        {
            return registrationMonth;
        }

        /// <summary>
        /// Set de maand van de registratie
        /// </summary>
        /// <param name="month">int - Maand</param>
        public void SetRegistrationMonth(int month)
        {
        }

        /// <summary>
        /// Verkrijg de dag van de registratie
        /// </summary>
        /// <returns>int - Dag</returns>
        public int GetRegistrationDay()
        {
            return registrationDay;
        }

        /// <summary>
        /// Set de dag van de registratie
        /// </summary>
        /// <param name="day"></param>
        public void SetRegistrationDay(int day)
        {
        }

        /// <summary>
        /// Verkrijg het tijdstip van de laatste activiteit
        /// </summary>
        /// <returns>DateTime - Laatste Activiteit</returns>
        public DateTime GetLastactivity()
        {
            return lastactivityDate;
        }

        /// <summary>
        /// Set het tijdstip van de laatste activiteit
        /// </summary>
        /// <param name="date"></param>
        public void SetLastactivity(DateTime date)
        {
        }

        /// <summary>
        /// Verkrijg het jaar van de laatste activiteit
        /// </summary>
        /// <returns>int - Jaar</returns>
        public int GetLastactivityYear()
        {
            return lastactivityYear;
        }

        /// <summary>
        /// Set het jaar van de laatste activiteit
        /// </summary>
        /// <param name="year">int - Jaar</param>
        public void SetLastactivityYear(int year)
        {
        }

        /// <summary>
        /// Verkrijg de maand van de laatste activiteit
        /// </summary>
        /// <returns>int - Maand</returns>
        public int GetLastactivityMonth()
        {
            return lastactivityMonth;
        }

        /// <summary>
        /// Set de maand van de laatste activiteit
        /// </summary>
        /// <param name="month">int - Maand</param>
        public void SetLastactivityMonth(int month)
        {
        }

        /// <summary>
        /// Verkrijg de dag van de laatste activiteit
        /// </summary>
        /// <returns>int - Dag</returns>
        public int GetLastactivityDay()
        {
            return lastactivityDay;
        }

        /// <summary>
        /// Set de dag van de laatste activiteit
        /// </summary>
        /// <param name="day"></param>
        public void SetLastactivityDay(int day)
        {
        }

        /// <summary>
        /// Verkrijg de gebruikers rank
        /// </summary>
        /// <returns>String - Rank</returns>
        public String GetUserRank()
        {
            return userRank;
        }

        /// <summary>
        /// Set de gebruikers rank
        /// </summary>
        /// <param name="rank">String - Rank</param>
        public void SetUserRank(String rank)
        {
        }

        /// <summary>
        /// Verkrijg het aantal reacties
        /// </summary>
        /// <returns>int - Posts</returns>
        public int GetTotalPosts()
        {
            return totalPosts;
        }

        /// <summary>
        /// Set het totaal aantal posts
        /// </summary>
        /// <param name="posts">int - Posts</param>
        public void SetTotalPosts(int posts)
        {
            this.totalPosts = posts;
        }

        /// <summary>
        /// Verkrijg het gemiddeld aantal berichten per dag
        /// </summary>
        /// <returns>Decimal - Berichten per dag</returns>
        public Decimal GetPostsEachDay()
        {
            return postEaDay;
        }

        /// <summary>
        /// Set het gemiddeld aantal berichten per dag
        /// </summary>
        /// <param name="posts">Decimal - Berichten per dag</param>
        public void SetPostsEachDay(Decimal posts)
        {
            this.postEaDay = posts;
        }

        /// <summary>
        /// Verkrijg de publieke profiel URL
        /// </summary>
        /// <returns>String - URL</returns>
        public String GetPublicProfileURL()
        {
            return profileURL;
        }

        /// <summary>
        /// Set de publieke profile URL
        /// </summary>
        /// <param name="url">String - URL</param>
        public void SetPublicProfileURL(String url)
        {
            this.profileURL = url;
        }

        /// <summary>
        /// Get/Set of de gebruiker verenigingslid is
        /// </summary>
        public Boolean IsVerenigingslid
        {
            get
            {
                return vererningingslid;
            }
            set
            {
                this.vererningingslid = value;
            }
        }

        /// <summary>
        /// Voeg een gebruikersysteem toe
        /// </summary>
        /// <param name="system">GebruikerSysteem - System</param>
        public void AddSystem(GebruikerSysteem system)
        {
            // Save system to site
            if (HelpmijGebruikerSysteem.SaveSystem(system,this))
                systems.Add(system); // Add to list
        }

        /// <summary>
        /// Verkrijg een Gebruiker systeem
        /// </summary>
        /// <returns>GebruikerSysteem - System</returns>
        public List<GebruikerSysteem> GetSystems()
        {
            return systems;
        }

        /// <summary>
        /// Refresh de gegevens
        /// </summary>
        public void refreshData()
        {

        }
    }
}
