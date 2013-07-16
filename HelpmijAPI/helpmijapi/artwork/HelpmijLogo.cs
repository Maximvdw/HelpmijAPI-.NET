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

/*
 * DO NOT INCLUDE IN LITE VERSION
 */
namespace mvdw.helpmijapi.artwork
{
    /// <summary>
    /// Helpmij Logo type
    /// </summary>
    public enum LogoType
    {
        /// <summary>
        /// Helpmij logo small
        /// </summary>
        SMALL = 0,
        /// <summary>
        /// Helpmij logo large
        /// </summary>
        LARGE = 1,
        /// <summary>
        /// Helpmij logo small enkel HM
        /// </summary>
        HM_SMALL = 2,
        /// <summary>
        /// Helpmij logo large enkel HM
        /// </summary>
        HM_LARGE = 3
    }

    /// <summary>
    /// Verkrijg artwork van het Helpmij Logo
    /// </summary>
    public class HelpmijLogo
    {
        /// <summary>
        /// Verkrijg het normale Helpmij Logo
        /// </summary>
        /// <param name="type">Logo type</param>
        /// <returns>Image - Logo</returns>
        public static Image GetLogo(LogoType type)
        {
            switch (type)
            {
                case LogoType.SMALL:
                    break;
                case LogoType.LARGE:
                    break;
                case LogoType.HM_SMALL:
                    break;
                case LogoType.HM_LARGE:
                    break;    
            }
            return null; // Geen logo
        }

        /// <summary>
        /// Verkrijg het kerst Helpmij Logo
        /// </summary>
        /// <param name="type">Logo type</param>
        /// <returns>Image - kert Logo</returns>
        public static Image GetLogoXmas(LogoType type)
        {
            switch (type)
            {
                case LogoType.SMALL:
                    break;
                case LogoType.LARGE:
                    break;
                case LogoType.HM_SMALL:
                    break;
                case LogoType.HM_LARGE:
                    break;
            }
            return null; // Geen logo
        }

        /// <summary>
        /// Verkrijg het beste Helpmij Logo
        /// </summary>
        /// <param name="type">Logo type</param>
        /// <returns>Image - Current Logo</returns>
        public static Image GetCurrentLogo(LogoType type)
        {
            // Verkrijg het huidige tijdstip
            DateTime currentTime = DateTime.Now;
            
            switch (type)
            {
                case LogoType.SMALL:
                    break;
                case LogoType.LARGE:
                    break;
                case LogoType.HM_SMALL:
                    break;
                case LogoType.HM_LARGE:
                    break;
            }
            return null; // Geen logo
        }
    }
}
