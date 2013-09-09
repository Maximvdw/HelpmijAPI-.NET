using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mvdw.helpmijapi.chat.events
{
    /// <summary>
    /// Load Progress Handler
    /// </summary>
    /// <param name="o">Sender</param>
    /// <param name="e">Event Args</param>
    public delegate void LoadProgressHandler(object o, LoadProgressArgs e);

    /// <summary>
    /// Chat Load Progress Event args
    /// </summary>
    public class LoadProgressArgs : EventArgs
    {
        /// <summary>
        /// Total progress
        /// </summary>
        int total = 0;
        /// <summary>
        /// Current progress
        /// </summary>
        int current = 0;

        /// <summary>
        /// EventArgs Load Progress
        /// </summary>
        /// <param name="total">int - Total progress</param>
        /// <param name="current">int - Current progress</param>
        public LoadProgressArgs(int total, int current)
        {
            this.total = total;
            this.current = current;
        }

        /// <summary>
        /// Verkrijg de totale stand
        /// </summary>
        /// <returns>int - Total</returns>
        public int GetTotalProgress()
        {
            return total;
        }

        /// <summary>
        /// Verkrijg de huidige stand
        /// </summary>
        /// <returns>int - Progress</returns>
        public int GetCurrentProgress()
        {
            return current;
        }
    }
}
