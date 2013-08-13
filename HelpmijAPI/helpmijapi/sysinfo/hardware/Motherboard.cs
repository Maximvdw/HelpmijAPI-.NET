/* SPECIAL NOTICE:
 * This specific file is copyrighted to Maxim Van de Wynckel
 * and is opensoure, BUT can not be used in any other application.
 * This code belongs to the mvdw.helpmijapi.sysinfo that is also used for commercial use. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace mvdw.helpmijapi.sysinfo.hardware
{
    /// <summary>
    /// Mother Board information
    /// </summary>
    public class Motherboard
    {
        /// <summary>
        /// Motherboard Product
        /// </summary>
        private String modoProduct = null;
        /// <summary>
        /// Motherboard Serial number
        /// </summary>
        private String modoSerial = null;

        /// <summary>
        /// Get Motherboard Serial
        /// </summary>
        /// <returns>String - Name</returns>
        public String GetSerial()
        {
            // Return if already fetched
            if (modoSerial != null)
                return modoSerial;
            try
            {
                modoSerial = null; // New list
                ManagementObjectSearcher mos =
                    new ManagementObjectSearcher("SELECT Product, SerialNumber FROM Win32_BaseBoard");
                foreach (ManagementObject mo in mos.Get())
                {
                    // Return Product
                    modoSerial = mo["SerialNumber"].ToString();
                    break;
                }
                return modoSerial; // Return name
            }
            catch (Exception)
            {
                // Error
            }
            // Return null if nothing found
            return null;
        }

        /// <summary>
        /// Get Motherboard product
        /// </summary>
        /// <returns>String - Name</returns>
        public String GetProduct()
        {
            // Return if already fetched
            if (modoProduct != null)
                return modoProduct;
            try
            {
                modoProduct = null; // New list
                ManagementObjectSearcher mos =
                    new ManagementObjectSearcher("SELECT Product, SerialNumber FROM Win32_BaseBoard");
                foreach (ManagementObject mo in mos.Get())
                {
                    // Return Product
                    modoProduct = mo["Product"].ToString();
                    break;
                }
                return modoProduct; // Return name
            }
            catch (Exception)
            {
                // Error
            }
            // Return null if nothing found
            return null;
        }
    }
}
