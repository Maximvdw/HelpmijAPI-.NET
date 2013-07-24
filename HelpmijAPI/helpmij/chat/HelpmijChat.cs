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
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Drawing;
using mvdw.helpmij.utils;
using mvdw.helpmijapi.chat;
using mvdw.helpmijapi.gebruiker;
using mvdw.helpmijapi.chat.events;
using mvdw.helpmij.gebruiker;

namespace mvdw.helpmij.chat
{
    /// <summary>
    /// Helpmij.nl Chat integratie
    /// </summary>
    internal class HelpmijChat : HelpmijData, Chat
    {
        /// <summary>
        /// Chat gebruiker
        /// </summary>
        public Gebruiker user = null;
        /// <summary>
        /// Laatste update
        /// </summary>
        public String lastUpdate = "0";
        /// <summary>
        /// Laatste update
        /// </summary>
        public String lastMessage = "0"; 
        /// <summary>
        /// Chat listener
        /// </summary>
        public ChatListener listener = null;

        /// <summary>
        /// Connecteer met Helpmij.nl Chat
        /// </summary>
        /// <param name="user">Ingelogde gebruiker</param>
        /// <param name="listener">ChatListener - Listener</param>
        public void Connect(Gebruiker user, ChatListener listener)
        {
            RegisterListener(listener);
            Connect(user);
        }

        /// <summary>
        /// Connecteer met Helpmij.nl Chat
        /// </summary>
        /// <param name="user">Ingelogde gebruiker</param>
        public void Connect(Gebruiker user)
        {
            this.user = user;
            CookieContainer cookies = user.GetCookies();
            // Verkrijg de JSON data
            String jsonData = UtilsHTTP.GetPOSTSource(chatGetState
                , chatURL + chatPHP, ref cookies);
            Hashtable data = (Hashtable)UtilsJSON.JsonDecode(jsonData);
            Object smilies = data["smilies"];
            lastUpdate = (String)data["lastupdate"];
        }

        public String FilterHTML(String input)
        {
            String output = input;
            output = Regex.Replace(output, @"<[^>]*>", String.Empty);
            output = output.Replace("&gt;", ">");
            return output;
        }
        
        /// <summary>
        /// Registreer een chat listener
        /// </summary>
        /// <param name="listener">ChatListener</param>
        public void RegisterListener(ChatListener listener)
        {
            this.listener = listener;
            new HelpmijChatListener(listener);
        }


        /// <summary>
        /// Zend een bericht in de chat
        /// </summary>
        /// <param name="message">String - Bericht</param>
        public void SendMessage(String message)
        {
            CookieContainer cookies = user.GetCookies();
            UtilsHTTP.GetPOSTSource(chatSendMessage + message + "&color=006666", chatURL + chatPHP, ref cookies);
            listener.onChatReceived(null);
        }

        /// <summary>
        /// Zend een commando naar de chat
        /// </summary>
        /// <param name="command">String - Commando</param>
        public void SendCommand(String command)
        {
            CookieContainer cookies = user.GetCookies();
            String jsonData = UtilsHTTP.GetPOSTSource("function=command&message=" + command + "&color=006666", "http://chat.helpmij.nl/process.php", ref cookies);
            Hashtable data = (Hashtable)UtilsJSON.JsonDecode(jsonData);
            lastUpdate = (String)data["lastupdate"];
            ArrayList msgtext = (ArrayList)data["text"];
            List<ChatMessage> messages = new List<ChatMessage>();
            if (msgtext != null)
            {
                foreach (String msgdat in msgtext)
                {
                    try
                    {
                        String username = UtilsString.GetSubStrings(msgdat,
                            messageUsernamePrefix, messageUsernameSuffix)[0];
                        String message = UtilsString.GetSubStrings(msgdat,
                            username + messagePrefix, messageSuffix)[0];
                        String colorStr = UtilsString.GetSubStrings(msgdat,
                            messageColorPrefix, messageColorSuffix)[0];
                        Color color = ColorTranslator.FromHtml(colorStr);
                        ChatMessageType type = ChatMessageType.Normal;

                        if (message.StartsWith(":"))
                        {
                            // Normal message
                            message = message.Substring(2);
                            type = ChatMessageType.Normal;
                        }
                        else
                        {
                            // Login message
                            type = ChatMessageType.Login;
                        }

                        // Filter HTML
                        message = FilterHTML(message);
                        ChatMessage cm = new HelpmijChatMessage();
                        Gebruiker chatUser = new HelpmijGebruiker();
                        chatUser.SetNickname(username);
                        cm.SetMessage(message);
                        cm.SetUser(chatUser);
                        cm.SetColor(color);
                        messages.Add(cm);
                    }
                    catch (Exception)
                    {
                    }
                }
                listener.onChatReceived(new ChatReceivedArguments(messages));
            }
        }

        /// <summary>
        /// Forceer een update van de chat
        /// </summary>
        public void ForceUpdate()
        {
            CookieContainer cookies = user.GetCookies();
            String jsonData = UtilsHTTP.GetPOSTSource("function=update&state=1&lastupdate=" +
                lastUpdate + "&lastquoteupdate=" + lastMessage, chatURL + chatPHP, ref cookies);
            Hashtable data = (Hashtable)UtilsJSON.JsonDecode(jsonData);
            ArrayList msgtext = (ArrayList)data["text"];
            List<ChatMessage> messages = new List<ChatMessage>();
            if (msgtext != null)
            {
                foreach (String msg in msgtext)
                {
                    ChatMessage cm = new HelpmijChatMessage();
                    cm.SetMessage(msg);
                    messages.Add(cm);
                }
                listener.onChatReceived(new ChatReceivedArguments(messages));
            }
        }

        /// <summary>
        /// Verkrijg de laatste update
        /// </summary>
        /// <returns>String - Laatste update</returns>
        public String GetLastUpdate()
        {
            return lastUpdate;
        }
    }
}
