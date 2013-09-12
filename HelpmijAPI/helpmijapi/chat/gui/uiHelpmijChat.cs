using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using mvdw.helpmij.utils;

namespace mvdw.helpmijapi.chat.gui
{
    /// <summary>
    /// Helpmij Chat User Control
    /// </summary>
    public partial class uiHelpmijChat : UserControl
    {
        /// <summary>
        /// Initialize Helpmij Chat
        /// </summary>
        public uiHelpmijChat()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Write a message
        /// </summary>
        /// <param name="msg">ChatMessage msg</param>
        public void WriteMessage(IChatMessage msg)
        {
           
        }
    }
}
