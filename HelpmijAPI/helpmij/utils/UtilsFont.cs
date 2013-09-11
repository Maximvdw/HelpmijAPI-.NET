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
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace mvdw.helpmij.utils
{
    /// <summary>
    /// Font utilities
    /// </summary>
    internal class UtilsFont
    {
        /// <summary>
        /// Helpmij Font
        /// </summary>
        public enum HMFont
        {
            /// <summary>
            /// Calibri Font
            /// </summary>
            Calibri,
            /// <summary>
            /// Visitor Font
            /// </summary>
            Visitor,
            /// <summary>
            /// Myriad Pro Font
            /// </summary>
            Myriad
        }

        /// <summary>
        /// Verkrijg een font van de resources
        /// </summary>
        /// <param name="size">Font size</param>
        /// <param name="style">Font Style</param>
        /// <param name="hmfont">Helpmij Font</param>
        /// <returns>System.Drawing.Font - Font</returns>
        public static Font GetEmbeddedFont(HMFont hmfont, FontStyle style, float size)
        {
            byte[] resource = new byte[0]; // Font resource
            switch (hmfont) // Verkrijg de geselecteerde font
            {
                case HMFont.Calibri:
                    resource = mvdw.Properties.Resources.CALIBRI;
                    break;
                case HMFont.Visitor:
                    resource = resource = mvdw.Properties.Resources.visitor;
                    break;
                case HMFont.Myriad:
                    resource = resource = mvdw.Properties.Resources.MyriadPro_Regular;
                    break;
            }
            
            PrivateFontCollection pfc = new PrivateFontCollection();
            IntPtr fontMemPointer = Marshal.AllocCoTaskMem(resource.Length);
            Marshal.Copy(resource,
                         0, fontMemPointer,
                         resource.Length);
            pfc.AddMemoryFont(fontMemPointer,
                                resource.Length);
            Marshal.FreeCoTaskMem(fontMemPointer);
            // Return de nieuwe font
            return new Font(pfc.Families[0],size,style);
        }
    }
}
