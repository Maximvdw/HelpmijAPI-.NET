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
    /// Get system chassis
    /// </summary>
    public class Chassis
    {
        /// <summary>
        /// Chassis Type
        /// </summary>
        private ChassisTypes type = ChassisTypes.Unknown;
        /// <summary>
        /// Manufacturer that installed the OS
        /// </summary>
        private String osManufacturer = null;


        /// <summary>
        /// Get Chassis Type
        /// </summary>
        /// <returns>Chassis Type</returns>
        public ChassisTypes GetChassisType()
        {
            // Return if already fetched
            if (type != ChassisTypes.Unknown)
                return type;
            ManagementClass systemEnclosures = new ManagementClass("Win32_SystemEnclosure");
            foreach (ManagementObject obj in systemEnclosures.GetInstances())
            {
                foreach (int i in (UInt16[])(obj["ChassisTypes"]))
                {
                    if (i > 0 && i < 25)
                    {
                        type = (ChassisTypes)i;
                        return type;
                    }
                }
            }
            // Return unknown chassis
            return ChassisTypes.Unknown;
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
                    new ManagementObjectSearcher("SELECT Manufacturer FROM Win32_ComputerSystem");
                foreach (ManagementObject mo in mos.Get())
                {
                    // Return OS
                    osManufacturer = mo["Manufacturer"].ToString().TrimEnd(' ');
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

    /// <summary>
    /// Chassis Types
    /// </summary>
    public enum ChassisTypes
    {
        /// <summary>
        /// Other (Unknown)
        /// </summary>
        Other = 1,
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown,
        /// <summary>
        /// Desktop
        /// </summary>
        Desktop,
        /// <summary>
        /// Low Profile Desktop
        /// </summary>
        LowProfileDesktop,
        /// <summary>
        /// Pizza Box PC
        /// </summary>
        PizzaBox,
        /// <summary>
        /// Mini Tower PC
        /// </summary>
        MiniTower,
        /// <summary>
        /// Tower PC
        /// </summary>
        Tower,
        /// <summary>
        /// Portable
        /// </summary>
        Portable,
        /// <summary>
        /// Laptop
        /// </summary>
        Laptop,
        /// <summary>
        /// Notebook
        /// </summary>
        Notebook,
        /// <summary>
        /// Handheld device
        /// </summary>
        Handheld,
        /// <summary>
        /// Docking Station
        /// </summary>
        DockingStation,
        /// <summary>
        /// All in One
        /// </summary>
        AllInOne,
        /// <summary>
        /// Sub Netbook
        /// </summary>
        SubNotebook,
        /// <summary>
        /// Space Saving desktop
        /// </summary>
        SpaceSaving,
        /// <summary>
        /// Lunchbox
        /// </summary>
        LunchBox,
        /// <summary>
        /// Main System Chassis
        /// </summary>
        MainSystemChassis,
        /// <summary>
        /// Expansion Chassis
        /// </summary>
        ExpansionChassis,
        /// <summary>
        /// Sub Chassis
        /// </summary>
        SubChassis,
        /// <summary>
        /// Bus Expansion Chassis
        /// </summary>
        BusExpansionChassis,
        /// <summary>
        /// Peripheral Chassis
        /// </summary>
        PeripheralChassis,
        /// <summary>
        /// Storage Chassis
        /// </summary>
        StorageChassis,
        /// <summary>
        /// Rack Mounted Chassis (server)
        /// </summary>
        RackMountChassis,
        /// <summary>
        /// Sealed PC
        /// </summary>
        SealedCasePC
    }
}
