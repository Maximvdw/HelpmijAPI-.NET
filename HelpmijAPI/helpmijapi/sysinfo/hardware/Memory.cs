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
    /// Memory Information
    /// </summary>
    public class Memory
    {
        /// <summary>
        /// Memory information - Capacity
        /// </summary>
        private List<Double> memoryCapacity = null;
        /// <summary>
        /// Memory information - Type
        /// </summary>
        private List<String> memoryType = null;


        /// <summary>
        /// Get the memory capacties of each slot
        /// </summary>
        /// <remarks>Double - Memory capactities</remarks>
        public List<Double> GetMemoryCapacities()
        {
            // Return if already fetched
            if (memoryCapacity != null)
                return memoryCapacity;
            try
            {
                memoryCapacity = new List<Double>(); // New list
                ManagementObjectSearcher mos =
                    new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemory");
                foreach (ManagementObject mo in mos.Get())
                {
                    // Return the capacity
                    memoryCapacity.Add(Double.Parse(mo["Capacity"].ToString()));
                }
                return memoryCapacity; // Return list
            }
            catch (Exception)
            {
                // Error
            }
            // Return null if nothing found
            return null;
        }

        /// <summary>
        /// Get the memory types of each slot
        /// </summary>
        /// <remarks>String - Memory types</remarks>
        public List<String> GetMemoryTypes()
        {
            // Return if already fetched
            if (memoryType != null)
                return memoryType;
            try
            {
                memoryType = new List<String>(); // New list
                ManagementObjectSearcher mos =
                    new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemory");
                foreach (ManagementObject mo in mos.Get())
                {
                    // Return memory type
                    memoryType.Add(mo["Type"].ToString());
                }
                return memoryType; // Return list
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
