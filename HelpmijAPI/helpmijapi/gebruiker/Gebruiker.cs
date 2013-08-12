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

namespace mvdw.helpmijapi.gebruiker
{
    /// <summary>
    /// Verkrijg Gebruiker Identificatie
    /// </summary>
    public interface Gebruiker
    {
        /// <summary>
        /// Verkrijg de NickName
        /// </summary>
        /// <returns>String - Nickname</returns>
        String GetNickname();

        /// <summary>
        /// Set de gebruiker Nickname
        /// </summary>
        /// <param name="nickname">String - Nickname</param>
        void SetNickname(String nickname);

        /// <summary>
        /// Set de avatar URL
        /// </summary>
        /// <param name="url"></param>
        void SetAvatarUrl(String url);

        /// <summary>
        /// Verkrijg de Gebruikers ID
        /// </summary>
        /// <returns>int - ID</returns>
        int GetUserID();

        /// <summary>
        /// Set de gebruikers ID
        /// </summary>
        /// <param name="ID">int - ID</param>
        void SetUserID(int ID);

        /// <summary>
        /// Verkrijg de Security token
        /// </summary>
        /// <returns>String - Security Token</returns>
        String GetSecurityToken();

        /// <summary>
        /// Set de gebruikers ID
        /// </summary>
        /// <param name="sectoken">String - Security Token</param>
        void SetSecurityToken(String sectoken);

        /// <summary>
        /// Verkrijg of de gebruiker online is
        /// </summary>
        /// <returns>Boolean</returns>
        Boolean IsOnline();

        /// <summary>
        /// Set de gebruiker online
        /// </summary>
        void SetOnline();

        /// <summary>
        /// Set de gebruiker offline
        /// </summary>
        void SetOffline();

        /// <summary>
        /// Verkrijg de cookies van de sessie
        /// </summary>
        /// <returns>CookieContainer - Cookies</returns>
        CookieContainer GetCookies();

        /// <summary>
        /// Set de ccokies van de sessie
        /// </summary>
        /// <param name="container"></param>
        void SetCookies(CookieContainer container);

        /// <summary>
        /// Verkrijg GebruikersData
        /// </summary>
        GebruikerData GetUserData();

        /// <summary>
        /// Sla de wijzigingen op
        /// </summary>
        void SetUserData();

        /// <summary>
        /// Refresh de gegevens
        /// </summary>
        void refreshData();

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
    }
}
