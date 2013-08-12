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
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections;

namespace mvdw.helpmij.utils
{
    /// <summary>
    /// INI-File Utilities
    /// </summary>
    internal class UtilsINI
    {
                /* -----------------------------
         * Name: iniConfig
         * Author: Maxim Van de Wynckel
         * ----------------------------- */

        /* Desciprtion
         * -----------
         * Create or Load an Ini settings file */

        // Global Variables
        #region Variables
        private String path = "";
        #endregion

        // Initialize file load
        #region Initialize
        /// <summary>
        /// Get filename and open file
        /// </summary>
        /// <param name="file">INI file location</param>
        public UtilsINI(String file)
        {
            path = Path.GetFullPath(file); // Get file path
        }
        #endregion

        // Initialize Kernel DLL's
        #region Kernel32 Init
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        #endregion

        // Writing and Reading functions
        #region Writing and Reading
        /// <summary>
        /// Write data to the ini file
        /// </summary>
        /// <param name="Section">Section in ini file: [SECTION]</param>
        /// <param name="Key">Key in Section: key=...</param>
        /// <param name="Value">Value to put in the key: key=value</param>
        public void WriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }

        /// <summary>
        /// Read data from the ini file
        /// </summary>
        /// <param name="Section">Section in ini file: [SECTION]</param>
        /// <param name="Key">Key in Section: key=...</param>
        /// <returns></returns>
        public string ReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(10000);
            int i = GetPrivateProfileString(Section, Key, "", temp, 10000, this.path);
            return temp.ToString();
        }
        #endregion

        // Delete functions
        #region Deleting
        /// <summary>
        /// Delete the section from the ini file
        /// </summary>
        /// <param name="Section">Section in ini file: [SECTION]</param>
        public void DeleteSection(string Section)
        {
            WritePrivateProfileString(Section, null, null, this.path);
        }

        /// <summary>
        /// Delete the key from the ini file
        /// </summary>
        /// <param name="Section">Section in ini file: [SECTION]</param>
        /// <param name="key">Key in section: key=....</param>
        public void DeleteKey(string Section, String key)
        {
            WritePrivateProfileString(Section, key, null, this.path);
        }
        #endregion
    }
}
