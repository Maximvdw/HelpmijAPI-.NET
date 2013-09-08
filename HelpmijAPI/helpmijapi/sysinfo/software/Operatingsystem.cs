/* SPECIAL NOTICE:
 * This specific file is copyrighted to Maxim Van de Wynckel
 * and is opensoure, BUT can not be used in any other application.
 * This code belongs to the mvdw.helpmijapi.sysinfo that is also used for commercial use. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace mvdw.helpmijapi.sysinfo.software
{
    /// <summary>
    /// Operating System Information
    /// </summary>
    public class Operatingsystem
    {
        /// <summary>
        /// OS Friendly name
        /// </summary>
        private String osName = null;
        /// <summary>
        /// Manufacturer that created the OS
        /// </summary>
        private String osManufacturer = null;

        /// <summary>
        /// Get Machine name
        /// </summary>
        /// <returns>String - Name</returns>
        public String GetMachineName()
        {
            return Environment.MachineName;
        }

        /// <summary>
        /// Get the current User name
        /// </summary>
        /// <returns>String - Name</returns>
        public String GetUserName()
        {
            return Environment.UserName;
        }

        /// <summary>
        /// Get OS Friendly name
        /// </summary>
        /// <returns>String - Name</returns>
        public String GetOSName()
        {
            // Return if already fetched
            if (osName != null)
                return osName;
            try
            {
                osName = null; // New list
                ManagementObjectSearcher mos =
                    new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
                foreach (ManagementObject mo in mos.Get())
                {
                    // Return OS
                    osName = mo["Caption"].ToString();
                    break;
                }
                return osName; // Return name
            }
            catch (Exception)
            {
                // Error
            }
            // Return null if nothing found
            return null;
        }

        /// <summary>
        /// Get Manufacturer
        /// </summary>
        /// <returns>String - Name</returns>
        public String GetManufacturerName()
        {
            // Return if already fetched
            if (osManufacturer != null)
                return osManufacturer;
            try
            {
                osManufacturer = null; // New list
                ManagementObjectSearcher mos =
                    new ManagementObjectSearcher("SELECT Manufacturer FROM Win32_OperatingSystem");
                foreach (ManagementObject mo in mos.Get())
                {
                    // Return OS
                    osManufacturer = mo["Manufacturer"].ToString();
                    break;
                }
                return osManufacturer; // Return name
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
