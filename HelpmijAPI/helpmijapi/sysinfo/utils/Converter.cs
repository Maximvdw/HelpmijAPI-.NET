/* SPECIAL NOTICE:
 * This specific file is copyrighted to Maxim Van de Wynckel
 * and is opensoure, BUT can not be used in any other application.
 * This code belongs to the mvdw.helpmijapi.sysinfo that is also used for commercial use. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mvdw.helpmijapi.sysinfo.utils
{
    /// <summary>
    /// Converters
    /// </summary>
    public class Converter
    {
        /// <summary>
        /// Convert bytes to a readable string
        /// </summary>
        /// <param name="bytes">int - bytes</param>
        /// <returns>String - [xx] MB/GB/KB ,..</returns>
        public static String ByteConvert(double bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB" ,"TB"};
            double len = bytes;
            int order = 0;
            while (len >= 1024 && order + 1 < sizes.Length)
            {
                order++;
                len = len / 1024;
            }

            // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
            // show a single decimal place, and no space.
            string result = String.Format("{0:0.##} {1}", len, sizes[order]);
            return result;
        }
    }
}
