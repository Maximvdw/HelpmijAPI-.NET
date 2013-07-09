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
using System.Security.Cryptography;

namespace mvdw.helpmij.utils
{
    /// <summary>
    /// Encryptie Utilities
    /// </summary>
    internal class UtilsEncryption
    {
        /// <summary>
        /// Verkrijg een MD5 hash van een String
        /// </summary>
        /// <param name="str">De input</param>
        /// <returns>String - MD5 hash</returns>
        public static String GetMD5Hash(String str)
        {
            // Nieuwe MD5 Hash
            MD5 md5Hash = MD5.Create();
            // Zet de input string om naar een Array van bytes
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(str));

            // Gebruik een String builder om de output te maken
            StringBuilder sBuilder = new StringBuilder();

            // Doorloop de data array en zet elke byte
            // om naar een Hex. String.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return Hexadecimale string 
            return sBuilder.ToString();
        }
    }
}
