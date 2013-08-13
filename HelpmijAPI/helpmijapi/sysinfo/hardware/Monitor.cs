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
    /// Display Monitor Information
    /// </summary>
    public class Monitor
    {
        /// <summary>
        /// Monitor descriptions
        /// </summary>
        private List<String> monitors = null;


        /// <summary>
        /// Get the Monitor names
        /// </summary>
        /// <remarks>String - Monitor names</remarks>
        public List<String> GetMonitors()
        {
            // Return if already fetched
            if (monitors != null)
                return monitors;
            try
            {
                monitors = new List<String>(); // New list
                ManagementObjectSearcher mos =
                    new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DesktopMonitor");
                foreach (ManagementObject mo in mos.Get())
                {
                    // Return name of the CPU
                    monitors.Add(mo["Description"].ToString().TrimEnd(' '));
                }
                return monitors; // Return list
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
