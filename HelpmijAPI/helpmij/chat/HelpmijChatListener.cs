﻿/*
 * Unofficial Helpmij.nl Aplication Interface
 * Copyright (C) 2009 Maxim Van de Wynckel <Maximvdw> and contributors
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mvdw.helpmijapi.gebruiker;
using mvdw.helpmijapi.chat;
using mvdw.helpmijapi.chat.events;

namespace mvdw.helpmij.chat
{
    /// <summary>
    /// Helpmij Chat Listener
    /// </summary>
    internal class HelpmijChatListener
    {
        /// <summary>
        /// Update Interval
        /// </summary>
        public int updateInterval = 1000;
        /// <summary>
        /// Set to true to stop updating
        /// </summary>
        public Boolean updateFlag = false;

        /// <summary>
        /// Start de chatlistener
        /// </summary>
        /// <param name="listener">Chat Listener</param>
        public HelpmijChatListener(ChatListener listener)
        {
            if (listener is ChatQuitListener)
            {
                // ChatQuitListener

            }
            else if (listener is ChatJoinListener)
            {
                // ChatJoinListener

            }
            else if (listener is ChatReceivedListener)
            {
                // ChatReceivedListener

            }
            else
            {
                // ChatListener

            }
        }

        /// <summary>
        /// Stop de chat listener
        /// </summary>
        public void StopListener()
        {
            updateFlag = false;
        }
    }
}
