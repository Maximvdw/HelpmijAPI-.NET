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

namespace mvdw.helpmijapi.artwork.userbar
{
    /// <summary>
    /// Helpmij Userbar
    /// </summary>
    public class HelpmijUserbar
    {
        /// <summary>
        /// Verkrijg voorbeeld
        /// </summary>
        /// <param name="type">Userbar Type</param>
        /// <returns>Userbar Image</returns>
        public static Image GetPreviewUserbar(UserbarType type)
        {
            switch (type)
            {
                case UserbarType.Classic:
                    return resUserbars.UB_Classic_PREVIEW;
                case UserbarType.Emboss:
                    return resUserbars.UB_Emboss_PREVIEW;
                case UserbarType.ClassicDark:
                    return resUserbars.UB_ClassicDark_PREVIEW;
                case UserbarType.GreenSpring:
                    return resUserbars.UB_GreenSpring_PREVIEW;
                case UserbarType.Herfst:
                    return resUserbars.UB_Herfst_PREVIEW;
                case UserbarType.Nederland:
                    return resUserbars.UB_Nederland_PREVIEW;
                case UserbarType.RainbowBlue:
                    return resUserbars.UB_RainbowBlue_PREVIEW;
                case UserbarType.RainbowGreen:
                    return resUserbars.UB_RainbowGreen_PREVIEW;
                case UserbarType.RainbowRed:
                    return resUserbars.UB_RainbowRed_PREVIEW;
                case UserbarType.RainbowYellow:
                    return resUserbars.UB_RainbowYellow_PREVIEW;
                case UserbarType.Belg:
                    return resUserbars.UB_Belg_PREVIEW;
            }
            // Geen userbar gevonden
            return null;
        }

        /// <summary>
        /// Verkrijg Lege Userbar
        /// </summary>
        /// <param name="type">Userbar Type</param>
        /// <returns>Userbar Image</returns>
        public static Image GetBlankUserbar(UserbarType type)
        {
            switch (type)
            {
                case UserbarType.Classic:
                    return resUserbars.UB_Classic_img;
                case UserbarType.Emboss:
                    return resUserbars.UB_Emboss_img;
                case UserbarType.ClassicDark:
                    return resUserbars.UB_ClassicDark_img;
                case UserbarType.GreenSpring:
                    return resUserbars.UB_GreenSpring_img;
                case UserbarType.Herfst:
                    return resUserbars.UB_Herfst_img;
                case UserbarType.Nederland:
                    return resUserbars.UB_Nederland_img;
                case UserbarType.RainbowBlue:
                    return resUserbars.UB_RainbowBlue_img;
                case UserbarType.RainbowGreen:
                    return resUserbars.UB_RainbowGreen_img;
                case UserbarType.RainbowRed:
                    return resUserbars.UB_RainbowRed_img;
                case UserbarType.RainbowYellow:
                    return resUserbars.UB_RainbowYellow_img;
                case UserbarType.Belg:
                    return resUserbars.UB_Belg_img;
            }
            // Geen userbar gevonden
            return null;
        }
    }


    /// <summary>
    /// Helpmij.nl Userbar Types
    /// </summary>
    public enum UserbarType
    {
        /// <summary>
        /// Classic Userbar
        /// </summary>
        Classic,
        /// <summary>
        /// Emboss Userbar
        /// </summary>
        Emboss,
        /// <summary>
        /// Belg Userbar
        /// </summary>
        Belg,
        /// <summary>
        /// Classic Dark Userbar
        /// </summary>
        ClassicDark,
        /// <summary>
        /// Green Spring Userbar
        /// </summary>
        GreenSpring,
        /// <summary>
        /// Herfst Userbar
        /// </summary>
        Herfst,
        /// <summary>
        /// Nederland Userbar
        /// </summary>
        Nederland,
        /// <summary>
        /// Rainbow Blue Userbar
        /// </summary>
        RainbowBlue,
        /// <summary>
        /// Rainbow Green Userbar
        /// </summary>
        RainbowGreen,
        /// <summary>
        /// Rainbow Red Userbar
        /// </summary>
        RainbowRed,
        RainbowYellow
    }
}
