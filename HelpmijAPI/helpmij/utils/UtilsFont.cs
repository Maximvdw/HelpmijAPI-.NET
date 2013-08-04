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
        /// Verkrijg een font van de resources
        /// </summary>
        /// <param name="font">Font naam (+ext)</param>
        /// <param name="size">Font size</param>
        /// <param name="style">Font Style</param>
        /// <returns>System.Drawing.Font - Font</returns>
        public Font GetEmbeddedFont(String font, FontStyle style, float size)
        {
            // specify embedded resource name
            string resource = "mvdw." + font;

            // receive resource stream
            Stream fontStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource);

            // create an unsafe memory block for the font data
            IntPtr data = Marshal.AllocCoTaskMem((int)fontStream.Length);

            // create a buffer to read in to
            byte[] fontdata = new byte[fontStream.Length];

            // read the font data from the resource
            fontStream.Read(fontdata, 0, (int)fontStream.Length);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);

            // pass the font to the font collection
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddMemoryFont(data, (int)fontStream.Length);

            // close the resource stream
            fontStream.Close();

            // free up the unsafe memory
            Marshal.FreeCoTaskMem(data);

            // Return de nieuwe font
            return new Font(pfc.Families[0],size,style);
        }
    }
}
