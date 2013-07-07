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

namespace mvdw.helpmijapi.gebruiker
{
    /// <summary>
    /// Gebruikers Privacy
    /// </summary>
    public class GebruikerPrivacy
    {
        /// <summary>
        /// Verberg de leeftijd en geboortedatum
        /// </summary>
        public static int VERBERG_LEEFTIJD_EN_GEBOORTEDATUM = 0;
        /// <summary>
        /// Toon enkel de leeftijd
        /// </summary>
        public static int TOON_LEEFTIJD = 1;
        /// <summary>
        /// Toon enkel de geboortedag en maand
        /// </summary>
        public static int TOON_GEBOORTEDAG_EN_MAAND = 2;
        /// <summary>
        /// Toon de leeftijd en de geboortedatum
        /// </summary>
        public static int TOON_LEEFTIJD_EN_GEBOORTEDATUM = 3;
    }
}
