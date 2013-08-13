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
    /// Video Card Information
    /// </summary>
    public class Videocard
    {
        /// <summary>
        /// Vidoe Processor name
        /// </summary>
        private List<String> gpuName = null;


        /// <summary>
        /// Get the Video processor name
        /// </summary>
        /// <remarks>String - Video Processor Names</remarks>
        public List<String> GetVideocardNames()
        {
            // Return if already fetched
            if (gpuName != null)
                return gpuName;
            try
            {
                gpuName = new List<String>(); // New list
                ManagementObjectSearcher mos =
                    new ManagementObjectSearcher("root\\CIMV2","SELECT * FROM Win32_VideoController");
                foreach (ManagementObject mo in mos.Get())
                {
                    // Return name of the GPU
                    gpuName.Add(mo["Description"].ToString().TrimEnd(' '));
                }
                return gpuName; // Return list
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
