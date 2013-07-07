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
using System.Drawing;

namespace mvdw.helpmijapi.gebruiker
{
    /// <summary>
    /// Verkrijg Gebruiker data
    /// </summary>
    public interface GebruikerData : Gebruiker
    {
        /// <summary>
        /// Verkrijg de avatar url
        /// </summary>
        /// <returns>String - URL naar avatar</returns>
        String GetAvatarUrl();

        /// <summary>
        /// Verkrijg de avatar Image
        /// </summary>
        /// <returns>Image - Avatar</returns>
        Image GetAvatar();

        /// <summary>
        /// Verkrijg de geboortedatum
        /// </summary>
        /// <returns>DateTime - Geboortedatum</returns>
        DateTime GetBirthday();

        /// <summary>
        /// Set de leeftijd van de gebruiker
        /// </summary>
        /// <returns>DateTime - Geboortedatum</returns>
        void SetBirthday(DateTime birthday);

        /// <summary>
        /// Verkrijg de geboortedag van de gebruiker
        /// </summary>
        /// <returns>int - Dag</returns>
        int GetBirthdayDay();

        /// <summary>
        /// Set de geboortedag van de gebruiker
        /// </summary>
        /// <param name="day">int - Dag</param>
        void SetBirthdayDay(int day);

        /// <summary>
        /// Verkrijg de geboorte maand van de gebruiker
        /// </summary>
        /// <returns>int - Maand</returns>
        int GetBirthdayMonth();

        /// <summary>
        /// Set de geboorte maand van de gebruiker
        /// </summary>
        /// <param name="month">int - Maand</param>
        void SetBirthdayMonth(int month);

        /// <summary>
        /// Verkrijg het geboortejaar van de gebruiker
        /// </summary>
        /// <returns>int - Jaar</returns>
        int GetBirthdayYear();

        /// <summary>
        /// Set het geboortejaar van de gebruiker
        /// </summary>
        /// <param name="year">int - Year</param>
        void SetBirthdayYear(int year);

        /// <summary>
        /// Verkrijg de privacy instellingen omtrend de leeftijd
        /// </summary>
        /// <returns>Gebruiker Privacy</returns>
        int GetPrivacy();

        /// <summary>
        /// Set de gebruikers privacy
        /// </summary>
        /// <param name="privacy">GebruikerPrivacy</param>
        void SetPrivacy(int privacy);

        /// <summary>
        /// Verkrijg de website van de gebruiker
        /// </summary>
        /// <returns>String - website</returns>
        String GetWebsite();

        /// <summary>
        /// Set de website van de gebruiker
        /// </summary>
        /// <param name="website">String - website</param>
        void SetWebsite(String website);

        /// <summary>
        /// Verkrijg de MSN naam van de gebruiker
        /// </summary>
        /// <returns>String - MSN Name</returns>
        String GetMSN();

        /// <summary>
        /// Set de MSN naam van de gebruiker
        /// </summary>
        /// <param name="msn">String - MSN Name</param>
        void SetMSN(String msn);

        /// <summary>
        /// Verkrijg de ICQ nummer van de gebruiker
        /// </summary>
        /// <returns>String - ICQ number</returns>
        String GetICQ();

        /// <summary>
        /// Set de ICQ nummer van de gebruiker
        /// </summary>
        /// <param name="icq">String - ICQ number</param>
        void SetICQ(String icq);

        /// <summary>
        /// Verkrijg de AIM naam van de gebruiker
        /// </summary>
        /// <returns>String - AIM Name</returns>
        String GetAIM();

        /// <summary>
        /// Set de AIM naam van de gebruiker
        /// </summary>
        /// <param name="aim">String - AIM Name</param>
        void SetAIM(String aim);

        /// <summary>
        /// Verkrijg de Yahoo van de gebruiker
        /// </summary>
        /// <returns>String - Yahoo</returns>
        String GetYahoo();

        /// <summary>
        /// Set de Yahoo van de gebruiker
        /// </summary>
        /// <param name="yahoo">String - Yahoo</param>
        void SetYahoo(String yahoo);

        /// <summary>
        /// Verkrijg de Skype naam van de gebruiker
        /// </summary>
        /// <returns>String - Skype Name</returns>
        String GetSkype();

        /// <summary>
        /// Set de Skype naam van de gebruiker
        /// </summary>
        /// <param name="skype">String - Skype Name</param>
        void SetSkype(String skype);

        /// <summary>
        /// Verkrijg de Jabber IM van de gebruiker
        /// </summary>
        /// <returns>String - Jabber IM</returns>
        String GetJabber();

        /// <summary>
        /// Set de Jabber IM van de gebruiker
        /// </summary>
        /// <param name="jabber">String - Jabber IM</param>
        void SetJabber(String jabber);

        /// <summary>
        /// Verkrijg de Biografie van de gebruiker
        /// </summary>
        /// <returns>String - Biografie</returns>
        String GetBiografie();

        /// <summary>
        /// Set de Biografie van de gebruiker
        /// </summary>
        /// <param name="biografie">String - Biografie</param>
        void SetBiografie(String biografie);

        /// <summary>
        /// Verkrijg de Hobbys van de gebruiker
        /// </summary>
        /// <returns>String - Hobbys</returns>
        String GetHobbys();

        /// <summary>
        /// Set de Hobbys van de gebruiker
        /// </summary>
        /// <param name="hobbys">String - Hobbys</param>
        void SetHobbys(String hobbys);

        /// <summary>
        /// Verkrijg het beroep van de gebruiker
        /// </summary>
        /// <returns>String - Beroep</returns>
        String GetBeroep();

        /// <summary>
        /// Set de Beroep van de gebruiker
        /// </summary>
        /// <param name="beroep">String - Beroep</param>
        void SetBeroep(String beroep);

        /// <summary>
        /// Verkrijg de Woonplaats van de gebruiker
        /// </summary>
        /// <returns>String - Woonplaats</returns>
        String GetWoonplaats();

        /// <summary>
        /// Set de Woonplaats van de gebruiker
        /// </summary>
        /// <param name="woonplaats">String - Woonplaats</param>
        void SetWoonplaats(String woonplaats);
    }
}
