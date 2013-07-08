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

namespace mvdw.helpmijapi.forum
{
    /// <summary>
    /// Helpmij HomepageTopic
    /// </summary>
    public interface HomepageTopic
    {
        /// <summary>
        /// Verkrijg de Titel van het topic
        /// </summary>
        /// <returns>String - Title</returns>
        String GetTitle();

        /// <summary>
        /// Set de Titel van het topic
        /// </summary>
        /// <param name="title">String - Title</param>
        void SetTitle(String title);

        /// <summary>
        /// Verkrijg de URL van het topic
        /// </summary>
        /// <returns>String - URL</returns>
        String GetURL();

        /// <summary>
        /// Set de URL van het topic
        /// </summary>
        /// <param name="url">String - URL</param>
        void SetURL(String url);

        /// <summary>
        /// Verkrijg het uur waarop de topic is aangemaakt
        /// </summary>
        /// <returns>int- Uur</returns>
        int GetHour();

        /// <summary>
        /// Set het uur waarop de topic is aangemaakt
        /// </summary>
        /// <param name="hour">int - Uur</param>
        void SetHour(int hour);

        /// <summary>
        /// Verkrijg de minuut waarop het topic is aangemaakt
        /// </summary>
        /// <returns>int - Minuten</returns>
        int GetMinute();

        /// <summary>
        /// Set het tijdstip waarop het topic is aangemaakt
        /// </summary>
        /// <param name="minute">int - Minuten</param>
        void SetMinute(int minute);

        /// <summary>
        /// Verkrijg de Topic ID
        /// </summary>
        /// <returns>int - ID</returns>
        int GetID();

        /// <summary>
        /// Set de Topic ID
        /// </summary>
        /// <param name="id">int - ID</param>
        void SetID(int id);

        /// <summary>
        /// Zet de HomepageTopic om naar een Topic
        /// </summary>
        /// <returns>Topic</returns>
        Topic GetTopic();
    }
}
