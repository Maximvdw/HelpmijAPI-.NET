using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mvdw.helpmijapi.chat.events
{
    /// <summary>
    /// Chat Received Event Arguments
    /// </summary>
    public class ChatReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// Chat Message
        /// </summary>
        private ChatMessage message = null;

        /// <summary>
        /// Chat Received Event Arguments
        /// </summary>
        /// <param name="message">ChatMessage - Message</param>
        public ChatReceivedEventArgs(ChatMessage message)
        {
            this.message = message;
        }

        /// <summary>
        /// Get Chat Message
        /// </summary>
        /// <returns>ChatMessage - Message</returns>
        public ChatMessage GetMessage()
        {
            return message;
        }
    }

    /// <summary>
    /// Chat Received Event Handler
    /// </summary>
    public delegate void ChatReceivedEventHandler(Object sender, ChatReceivedEventArgs e);
}
