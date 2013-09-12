using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mvdw.helpmijapi.chat.gui
{
    /// <summary>
    /// Chat Message User Control
    /// </summary>
    internal partial class uiChatMessage : UserControl
    {
        /// <summary>
        /// ChatMessage - msg
        /// </summary>
        IChatMessage chatMsg = null;


        public uiChatMessage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get/Set het Chat Bericht
        /// </summary>
        public IChatMessage ChatMessage
        {
            get
            {
                return chatMsg;
            }
            set
            {
                this.chatMsg = value;
            }
        }
    }
}
