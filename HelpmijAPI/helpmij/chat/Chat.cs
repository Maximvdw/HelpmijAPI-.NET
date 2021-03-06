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
using System.Threading;
using mvdw.helpmij.utils;
using mvdw.helpmijapi.chat;
using mvdw.helpmijapi.user;
using mvdw.helpmij.user;
using mvdw.helpmijapi.chat.events;

namespace mvdw.helpmij.chat
{
    /// <summary>
    /// Helpmij.nl Chat integratie
    /// </summary>
    internal class Chat : IChat
    {
        /// <summary>
        /// Chat gebruiker
        /// </summary>
        IUser user = null;
        /// <summary>
        /// Laatste update
        /// </summary>
        String lastUpdate = "";
        /// <summary>
        /// Laatste update
        /// </summary>
        double lastQuoteUpdate = 0;
        /// <summary>
        /// Chat state
        /// </summary>
        double state = 0;
        /// <summary>
        /// Chat color
        /// </summary>
        Color colorMsg = Color.Black;
        /// <summary>
        /// Chat gebruikers
        /// </summary>
        List<IUser> users = null;
        /// <summary>
        /// Chat kleur van gebruikers
        /// </summary>
        List<Color> userColors = null;
        /// <summary>
        /// Smilies
        /// </summary>
        List<String> smilyCodes, smilyFiles = new List<String>();


        /// <summary>
        /// Load Progress Event
        /// </summary>
        public event LoadProgressHandler onProgressEvent;

        /// <summary>
        /// Connecteer met Helpmij.nl Chat
        /// </summary>
        /// <param name="user">Ingelogde gebruiker</param>
        public void Connect(IUser user)
        {
            this.user = user;
            CookieContainer cookies = user.GetCookies();
            // Laad de chat pagina om in te loggen
            UtilsHTTP.GetSource("http://chat.helpmij.nl/",cookies);
            // Verkrijg de JSON data
            String jsonData = UtilsHTTP.GetPOSTSource("function=getState"
                , "http://chat.helpmij.nl/process.php", ref cookies);
            // Decodeer de JSON data
            DecodeUpdateData(jsonData);
            Hashtable data = (Hashtable)UtilsJSON.JsonDecode(jsonData);
            ArrayList jarray = (ArrayList)data["smilies"];
            for (int i = 0; i < jarray.Count; i++)
            {
                try
                {
                    // Get all the smilies
                    Hashtable jobject = (Hashtable)jarray[i];
                    String code = (String)jobject["code"];
                    String file = (String)jobject["file"];
                    smilyCodes.Add(code);
                    smilyFiles.Add(file);// Add smily
                }
                catch (Exception ex)
                {

                }
            }
        }

        /// <summary>
        /// Afmelden uit de chat
        /// </summary>
        public void Disconnect()
        {
            CookieContainer cookies = user.GetCookies();
            UtilsHTTP.GetSource("http://chat.helpmij.nl/process_logout.php", cookies);
        }


        /// <summary>
        /// Filter a message
        /// </summary>
        /// <param name="msg">String - Message</param>
        /// <returns>String - Filtered Message</returns>
        private String FilterMessage(String msg)
        {
            // Filter smilys
            if (msg.Contains("alt=\"smiley\""))
            {
                for (int j = 0; j < smilyCodes.Count; j++)
                {
                    msg = msg.Replace("<img src=\"http://chat.helpmij.nl/images/smilies/" +
                                smilyFiles[j] + "\" alt=\"smiley\" />", smilyCodes[j]);
                }
            }
            // Filter HTML
            msg = WebUtility.HtmlDecode(msg);

            return msg; // Return filtered message
        }

        /// <summary>
        /// Verkrijg update data
        /// </summary>
        /// <param name="jsonData">JSON String</param>
        private void DecodeUpdateData(String jsonData)
        {
            try
            {
                Hashtable data = (Hashtable)UtilsJSON.JsonDecode(jsonData);
                String newLastUpdate = (String)data["lastupdate"];
                // lastupdate
                if (newLastUpdate != null)
                    lastUpdate = newLastUpdate;
                String newState = data["state"].ToString();

                // state
                if (newState != null)
                    state = (Double)data["state"];

                // lastquoteupdate
                data = (Hashtable)data["quote"];
                if (data != null)
                {
                    Double newLastQuoteUpdate = (Double)data["lastupdate"];
                    if (newLastQuoteUpdate != 0)
                        lastQuoteUpdate = newLastQuoteUpdate;
                }
            }
            catch (Exception ex)
            {
                // Error
                String errorMsg = ex.Message;
            }
        }

        /// <summary>
        /// Verkrijg online gebruikers
        /// </summary>
        /// <param name="jsonData">Json Data</param>
        private void DecodeOnlineUsers(String jsonData)
        {
            try
            {
                // Wis de lijsten
                users = new List<IUser>();
                userColors = new List<Color>();
                // Haal de gegevens op
                Hashtable data = (Hashtable)UtilsJSON.JsonDecode(jsonData);
                ArrayList jarray = (ArrayList)data["users"];
                // Loop all users
                for (int i = 0; i < jarray.Count; i++)
                {
                    Hashtable userJson = (Hashtable)jarray[i];
                    String username = (String)userJson["username"];
                    int userid = int.Parse(userJson["userid"].ToString());
                    String colorStr = userJson["color"].ToString();
                    String status = userJson["status"].ToString();
                    Color color = Color.Black; // Default color
                    try
                    {
                        if (colorStr != null)
                            color = ColorTranslator.FromHtml("#" + colorStr);
                    }
                    catch (Exception) { }
                    // Maak een gebruiker met deze gegevens
                    IUser user = new User();
                    user.SetNickname(username);
                    user.SetUserID(userid);
                    // Vind de Gebruiker Status
                    switch (status)
                    {
                        case "away":
                            user.SetUserStatus(UserStatus.Away);
                            break;
                        case "busy":
                            user.SetUserStatus(UserStatus.Busy);
                            break;
                        case "online":
                            user.SetUserStatus(UserStatus.Online);
                            break;
                        case "offline":
                            user.SetUserStatus(UserStatus.Offline);
                            break;
                    }
                    users.Add(user);
                    userColors.Add(color);
                    if (user.GetUserID() == this.user.GetUserID())
                    {
                        this.colorMsg = color; // Zet eigen kleur
                    }
                }
            }
            catch (Exception)
            {
                // Error
            }
        }

        /// <summary>
        /// Verkrijg alle chat berichten in de json data
        /// </summary>
        /// <param name="jsonData">JSON data</param>
        /// <returns>List Chatmessages</returns>
        private List<IChatMessage> DecodeChatMessages(String jsonData)
        {
            List<IChatMessage> msgs = new List<IChatMessage>();
            try
            {
                // Decode json
                Hashtable data = (Hashtable)UtilsJSON.JsonDecode(jsonData);
                DecodeUpdateData(jsonData);
                DecodeOnlineUsers(jsonData);
                ArrayList jarray = (ArrayList)data["text"];
                for (int i = 0; i < jarray.Count; i++)
                {
                    String msgHTML = ""; // HTML Message
                    try
                    {
                        msgHTML = (String)jarray[i];
                        // Get timestamp
                        String timeStr = UtilsString.GetSubStrings(msgHTML, "<span class=\"time\">[", "]</span>")[0];
                        DateTime time = DateTime.Parse(timeStr);

                        if (msgHTML.Contains("</span> komt binnen"))
                        {
                            // Login
                            String username = UtilsString.GetSubStrings(msgHTML,
                                    "<span class=\"user\">", "</span>")[0];
                            // Maak een gebruiker
                            IUser user = new User();
                            user.SetNickname(username);
                            // Maak een nieuw ChatMessage aan met de gegevens
                            IChatMessage chatMessage = new ChatMessage();
                            chatMessage.SetUser(user);
                            chatMessage.SetMessageType(ChatMessageType.Login);
                            chatMessage.SetTimeStamp(time);
                            msgs.Add(chatMessage);
                        }
                        else if (msgHTML.Contains("logt uit</b></li>"))
                        {
                            // Logoff
                            String username = UtilsString.GetSubStrings(msgHTML,
                                    "</span> <b>", " logt uit</b></li>")[0];
                            // Maak een gebruiker
                            IUser user = new User();
                            user.SetNickname(username);
                            // Maak een nieuw ChatMessage aan met de gegevens
                            IChatMessage chatMessage = new ChatMessage();
                            chatMessage.SetUser(user);
                            chatMessage.SetMessageType(ChatMessageType.Logout);
                            chatMessage.SetTimeStamp(time);
                            msgs.Add(chatMessage);
                        }
                        else if (msgHTML.Contains("is uit de chat verwijderd</b></li>"))
                        {
                            // Kicked
                            String username = UtilsString.GetSubStrings(msgHTML,
                                    "</span> <b>", " is uit de chat verwijderd</b></li>")[0];
                            // Maak een gebruiker
                            IUser user = new User();
                            user.SetNickname(username);
                            // Maak een nieuw ChatMessage aan met de gegevens
                            IChatMessage chatMessage = new ChatMessage();
                            chatMessage.SetUser(user);
                            chatMessage.SetMessageType(ChatMessageType.Kicked);
                            chatMessage.SetTimeStamp(time);
                            msgs.Add(chatMessage);
                        }
                        else if (msgHTML.Contains("is terug</b></li>"))
                        {
                            // Back
                            String username = UtilsString.GetSubStrings(msgHTML,
                                    "</span> <b>", " is terug</b></li>")[0];
                            // Maak een gebruiker
                            IUser user = new User();
                            user.SetNickname(username);
                            // Maak een nieuw ChatMessage aan met de gegevens
                            IChatMessage chatMessage = new ChatMessage();
                            chatMessage.SetUser(user);
                            chatMessage.SetMessageType(ChatMessageType.Back);
                            chatMessage.SetTimeStamp(time);
                            msgs.Add(chatMessage);
                        }
                        else if (msgHTML.Contains("is bezet</b></li>"))
                        {
                            // Busy
                            String username = UtilsString.GetSubStrings(msgHTML,
                                    "</span> <b>", " is bezet</b></li>")[0];
                            // Maak een gebruiker
                            IUser user = new User();
                            user.SetNickname(username);
                            // Maak een nieuw ChatMessage aan met de gegevens
                            IChatMessage chatMessage = new ChatMessage();
                            chatMessage.SetUser(user);
                            chatMessage.SetMessageType(ChatMessageType.Busy);
                            chatMessage.SetTimeStamp(time);
                            msgs.Add(chatMessage);
                        }
                        else if (msgHTML.Contains("is afwezig</b></li>"))
                        {
                            // Kicked
                            String username = UtilsString.GetSubStrings(msgHTML,
                                    "</span> <b>", " is afwezig</b></li>")[0];
                            // Maak een gebruiker
                            IUser user = new User();
                            user.SetNickname(username);
                            // Maak een nieuw ChatMessage aan met de gegevens
                            IChatMessage chatMessage = new ChatMessage();
                            chatMessage.SetUser(user);
                            chatMessage.SetMessageType(ChatMessageType.Away);
                            chatMessage.SetTimeStamp(time);
                            msgs.Add(chatMessage);
                        }
                        else if (msgHTML.Contains("<span class=\"userprivate\">"))
                        {
                            // Private message
                            String username = UtilsString.GetSubStrings(msgHTML,
                                    "<span class=\"userprivate\">", "</span>")[0];
                            String colorStr = UtilsString.GetSubStrings(msgHTML, "style=\"color: ", "\">")[0];
                            Color color = Color.Black;
                            try { color = ColorTranslator.FromHtml(colorStr); }
                            catch (Exception) { }
                            // Maak een gebruiker
                            IUser user = new User();
                            user.SetNickname(username);
                            String msg = UtilsString.GetSubStrings(msgHTML, username
                                    + "</span>", "</li>")[0];
                            // Filter message
                            msg = FilterMessage(msg);
                            // Maak een nieuw ChatMessage aan met de gegevens
                            IChatMessage chatMessage = new ChatMessage();
                            chatMessage.SetMessage(msg);
                            chatMessage.SetUser(user);
                            chatMessage.SetMessageType(ChatMessageType.Private);
                            chatMessage.SetTimeStamp(time);
                            chatMessage.SetColor(color);
                            msgs.Add(chatMessage);
                        }
                        else if (msgHTML.Contains(timeStr + "]</span>\" "))
                        {
                            // 3de persoon
                            String username = UtilsString.GetSubStrings(msgHTML,
                                    timeStr + "]</span>\" ", "</span>")[0];
                            String colorStr = UtilsString.GetSubStrings(msgHTML, "style=\"color: ", "\">")[0];
                            Color color = Color.Black;
                            try { color = ColorTranslator.FromHtml(colorStr); }
                            catch (Exception) { }
                            // Maak een gebruiker
                            IUser user = new User();
                            user.SetNickname(username);
                            String msg = UtilsString.GetSubStrings(msgHTML, username
                                    + "</span>", "</li>")[0];
                            // Filter message
                            msg = FilterMessage(msg);
                            // Maak een nieuw ChatMessage aan met de gegevens
                            IChatMessage chatMessage = new ChatMessage();
                            chatMessage.SetMessage(msg);
                            chatMessage.SetUser(user);
                            chatMessage.SetMessageType(ChatMessageType.Private);
                            chatMessage.SetTimeStamp(time);
                            chatMessage.SetColor(color);
                            msgs.Add(chatMessage);
                        }
                        else
                        {
                            // Normal message
                            String username = UtilsString.GetSubStrings(msgHTML,
                                    "<span class=\"user\">", "</span>")[0];
                            String msg = UtilsString.GetSubStrings(msgHTML, username
                                    + "</span>: ", "</li>")[0];
                            String colorStr = UtilsString.GetSubStrings(msgHTML,"style=\"color: ", "\">")[0];
                            Color color = Color.Black;
                            try { color = ColorTranslator.FromHtml(colorStr); }
                            catch (Exception) { }
                            // Filter message
                            msg = FilterMessage(msg);
                            // Maak een gebruiker
                            IUser user = new User();
                            user.SetNickname(username);
                            // Maak een nieuw ChatMessage aan met de gegevens
                            IChatMessage chatMessage = new ChatMessage();
                            chatMessage.SetMessage(msg);
                            chatMessage.SetUser(user);
                            chatMessage.SetMessageType(ChatMessageType.Normal);
                            chatMessage.SetTimeStamp(time);
                            chatMessage.SetColor(color);
                            msgs.Add(chatMessage);
                        }
                    }
                    catch (Exception)
                    {
                        // Error while decoding messages
                    }
                    // Event Progress
                    if (onProgressEvent != null)
                        onProgressEvent(this, new LoadProgressArgs(jarray.Count, i));
                }
            }
            catch (Exception)
            {
            }
            return msgs;
        }

        /// <summary>
        /// Zend een bericht in de chat
        /// </summary>
        /// <param name="message">String - Bericht</param>
        public void SendMessage(String message)
        {
            // Zend een bericht
            CookieContainer cookies = user.GetCookies();
            // Verkrijg de kleur
            if (cookies != null)
            {
                String colorStr = ColorTranslator.ToHtml(Color.FromArgb(colorMsg.ToArgb())).Substring(1);
                UtilsHTTP.GetPOSTSource("function=send&message=" + message + "&color=" + colorStr,
                    "http://chat.helpmij.nl/process.php", ref cookies);
            }
            else
            {
                throw new Exception("De gebruiker is nog niet ingelogd");
            }
        }

        /// <summary>
        /// Zend een commando naar de chat
        /// </summary>
        /// <param name="command">String - Commando</param>
        /// <returns>Chat messages</returns>
        public List<IChatMessage> SendCommand(String command)
        {
            // Zend een command
            CookieContainer cookies = user.GetCookies();
            // Verkrijg de kleur
            String colorStr = ColorTranslator.ToHtml(Color.FromArgb(colorMsg.ToArgb())).Substring(1);
            // Haal response op
            String jsonData = UtilsHTTP.GetPOSTSource("function=command&message=" + command + "&color=" + colorStr, 
                "http://chat.helpmij.nl/process.php", ref cookies);
            DecodeUpdateData(jsonData);
            return DecodeChatMessages(jsonData);
        }

        /// <summary>
        /// Doe update van de chat
        /// </summary>
        /// <returns>Chatmessages</returns>
        public List<IChatMessage> Update()
        {
            try
            {
                // Chat messages
                List<IChatMessage> msgs = new List<IChatMessage>();
                CookieContainer cookies = user.GetCookies();
                // Verkrijg Json Data
                String jsonData = UtilsHTTP.GetPOSTSource("function=update&state=" + state +
                    "&lastupdate=" + lastUpdate +
                    "&lastquoteupdate=" + lastQuoteUpdate, "http://chat.helpmij.nl/process.php", ref cookies);
                msgs = DecodeChatMessages(jsonData);
                return msgs; // Messages
            }
            catch (Exception)
            {
                return null; // Error
            }
        }

        /// <summary>
        /// Update User settings
        /// </summary>
        /// <param name="key">String - key</param>
        /// <param name="value">String - value</param>
        public void UpdateSettings(String key, String value)
        {
            try
            {
                // Verkrijg cookies
                CookieContainer cookies = user.GetCookies();
                String param = "function=usersettings&complete=1&" + key + "=" + value;
                String url = "http://chat.helpmij.nl/process.php";
                UtilsHTTP.GetPOSTSource(param, url, ref cookies);
            }
            catch (Exception)
            {
                // Error while changing settings
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

        /// <summary>
        /// Set de laatste update
        /// </summary>
        /// <param name="newUpdate">DateTime - Lastupdate</param>
        public void SetLastUpdate(DateTime newUpdate)
        {
            this.lastUpdate = newUpdate.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// Verkrijg de laatste quote update
        /// </summary>
        /// <returns>Double - Laatste update</returns>
        public Double GetLastQuoteUpdate()
        {
            return lastQuoteUpdate;
        }

        /// <summary>
        /// Set de gebruiker
        /// </summary>
        /// <param name="user">Gebruiker - user</param>
        public void SetUser(IUser user)
        {
            this.user = user;
        }

        /// <summary>
        /// Set chat kleur
        /// </summary>
        /// <param name="color">Color color</param>
        public void SetChatColor(Color color)
        {
            this.colorMsg = color;
            String colorStr = ColorTranslator.ToHtml(Color.FromArgb(colorMsg.ToArgb())).Substring(1);
            Thread thUpdateSettings = new Thread(() => UpdateSettings("color", colorStr));
            thUpdateSettings.Start();
        }

        /// <summary>
        /// Verkrijg chat kleur
        /// </summary>
        /// <returns>Color color</returns>
        public Color GetChatColor()
        {
            return colorMsg;
        }

        /// <summary>
        /// Verkrijg online gebruikers
        /// </summary>
        /// <returns>List users</returns>
        public List<IUser> GetOnlineUsers()
        {
            return users;
        }

        /// <summary>
        /// Verkrijg de chat kleur van een specifieke gebruiker
        /// </summary>
        /// <param name="user">Gebruiker - User</param>
        /// <returns>Color color</returns>
        public Color GetChatColor(IUser user)
        {
            if (users != null)
            {
                int idx = users.IndexOf(user);
                return userColors[idx];
            }
            else
            {
                // Default kleur
                return Color.Black;
            }
        }

        /// <summary>
        /// Verkrijg alle Smily Codes
        /// </summary>
        /// <returns>List van Strings</returns>
        public List<String> GetSmilyCodes()
        {
            return smilyCodes;
        }

        /// <summary>
        /// Verkrijg smily codes die van toepassing zijn voor de gebruiker
        /// </summary>
        /// <returns>List van Strings</returns>
        public List<String> GetUserSmilyCodes()
        {
            return null;
        }

        /// <summary>
        /// Verkrijg alle Smily Files
        /// </summary>
        /// <returns>List van Strings</returns>
        public List<String> GetSmilyFiles()
        {
            return smilyFiles;
        }

        /// <summary>
        /// Verkrijg smily files die van toepassing zijn voor de gebruiker
        /// </summary>
        /// <returns>List van Strings</returns>
        public List<String> GetUserSmilyFiles()
        {
            return null;
        }
    }
}
