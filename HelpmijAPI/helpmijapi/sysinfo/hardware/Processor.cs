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
    /// Processor Information
    /// </summary>
    public class Processor
    {
        /// <summary>
        /// Processor name
        /// </summary>
        private List<String> cpuName = null;


        /// <summary>
        /// Get the processor name
        /// </summary>
        /// <remarks>String - Processor Names</remarks>
        public List<String> GetProcessorNames()
        {
            // Return if already fetched
            if (cpuName != null)
                return cpuName;
            try
            {
                cpuName = new List<String>(); // New list
                ManagementObjectSearcher mos =
                    new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
                foreach (ManagementObject mo in mos.Get())
                {
                    // Return name of the CPU
                    cpuName.Add(mo["Name"].ToString().TrimEnd(' '));
                }
                return cpuName; // Return list
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
