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
    /// Storage Information
    /// </summary>
    public class Storage
    {
        /// <summary>
        /// Logical Drives - Size
        /// </summary>
        private List<Double> logicalDrivesSize = null;


        /// <summary>
        /// Get logical drive capacities
        /// </summary>
        /// <remarks>String - Capacity</remarks>
        public List<Double> GetLogicalDrivesSize()
        {
            // Return if already fetched
            if (logicalDrivesSize != null)
                return logicalDrivesSize;
            try
            {
                logicalDrivesSize = new List<Double>(); // New list
                ManagementObjectSearcher mos =
                    new ManagementObjectSearcher("root\\CIMV2", "SELECT Size FROM Win32_LogicalDisk");
                foreach (ManagementObject mo in mos.Get())
                {
                    // Return name of the CPU
                    logicalDrivesSize.Add(Double.Parse(mo["Size"].ToString()));
                }
                return logicalDrivesSize; // Return list
            }
            catch (Exception)
            {
                // Error
                return logicalDrivesSize;
            }
        }
    }
}
