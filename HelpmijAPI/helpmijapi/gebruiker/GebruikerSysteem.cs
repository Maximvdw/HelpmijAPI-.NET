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
using System.Drawing;

namespace mvdw.helpmijapi.gebruiker
{
    /// <summary>
    /// Helpmij.nl Gebruiker Systeem
    /// </summary>
    public interface GebruikerSysteem
    {
        /// <summary>
        /// Get/Set de Nickname van het systeem
        /// </summary>
        String Nickname { get; set; }

        /// <summary>
        /// Get/Set de functie van het systeem
        /// </summary>
        String Functie {get; set; }

        /// <summary>
        /// Get/Set de systeemkast van het systeem
        /// </summary>
        String Systeemkast { get; set; }

        /// <summary>
        /// Get/Set het moederbord van het systeem
        /// </summary>
        String Moederbord { get; set; }

        /// <summary>
        /// Get/Set de processor van het systeem
        /// </summary>
        String Processor { get; set; }

        /// <summary>
        /// Get/Set het geheugen van het systeem
        /// </summary>
        String Geheugen { get; set; }

        /// <summary>
        /// Get/Set de koeler van het systeem
        /// </summary>
        String Koeler { get; set; }

        /// <summary>
        /// Get/Set de case fan van het systeem
        /// </summary>
        String Casefan { get; set; }

        /// <summary>
        /// Get/Set de harddisks van het systeem
        /// </summary>
        String Harddisk { get; set; }

        /// <summary>
        /// Get/Set de videokaart(en) van het systeem
        /// </summary>
        String Videokaart { get; set; }

        /// <summary>
        /// Get/Set de monitor(en) van het systeem
        /// </summary>
        String Monitor { get; set; }

        /// <summary>
        /// Get/Set de brander van het systeem
        /// </summary>
        String Brander { get; set; }

        /// <summary>
        /// Get/Set de cd/dvd drives van het systeem
        /// </summary>
        String CdDvdDrives { get; set; }

        /// <summary>
        /// Get/Set de speakers van het systeem
        /// </summary>
        String Speakers { get; set; }

        /// <summary>
        /// Get/Set de geluidskaart van het systeem
        /// </summary>
        String Geluidskaart { get; set; }

        /// <summary>
        /// Get/Set de netwerkkaart(en) van het systeem
        /// </summary>
        String Netwerkkaart { get; set; }

        /// <summary>
        /// Get/Set de muis van het systeem
        /// </summary>
        String Muis { get; set; }

        /// <summary>
        /// Get/Set het toetsenbord van het systeem
        /// </summary>
        String Toetsenbord { get; set; }

        /// <summary>
        /// Get/Set de scanner van het systeem
        /// </summary>
        String Scanner { get; set; }

        /// <summary>
        /// Get/Set de printer van het systeem
        /// </summary>
        String Printer { get; set; }

        /// <summary>
        /// Get/Set de internetverbinding van het systeem
        /// </summary>
        String Internetverbinding { get; set; }

        /// <summary>
        /// Get/Set het bestuuringssysteem
        /// </summary>
        String Besturingssysteem { get; set; }

        /// <summary>
        /// Get/Set de voeding van het systeem
        /// </summary>
        String Voeding { get; set; }

        /// <summary>
        /// Get/Set extra informatie over het systeem
        /// </summary>
        String Extra { get; set; }

        /// <summary>
        /// Get/Set de temperatuur van het systeem
        /// </summary>
        String Temperatuur { get; set; }

        /// <summary>
        /// Get/Set een foto van het systeem
        /// </summary>
        Image Foto { get; set; }
    }
}
