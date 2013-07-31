/*
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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using mvdw.helpmijapi.gebruiker;
using mvdw.helpmijapi.forum;
using mvdw.helpmijapi.forum.exceptions;

namespace mvdw.helpmijapi.forum.gui
{
    /// <summary>
    /// Helpmij Hompage Topics User Interface
    /// </summary>
    public partial class uiHompageTopics : UserControl
    {
        /// <summary>
        /// Helpmij Gebruiker
        /// </summary>
        private Gebruiker user = null;

        /// <summary>
        /// Initialzeer de gebruikerscontrol
        /// </summary>
        public uiHompageTopics()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Verkrijg de gebruiker
        /// </summary>
        /// <returns>Gebruiker - user</returns>
        public Gebruiker GetUser()
        {
            return user;
        }

        /// <summary>
        /// Set de gebruiker
        /// </summary>
        /// <param name="user">Gebruiker - User</param>
        public void SetUser(Gebruiker user)
        {
            this.user = user;
        }

        /// <summary>
        /// Laad Helpmij Hompage Topics
        /// </summary>
        public void LoadTopics()
        {
            // User Interface
            lstTopicsNew.Items.Clear();
            lstTopicsUnanswered.Items.Clear();
            lstTopicsUser.Items.Clear();
            Thread thNew = new Thread(() => LoadNewTopics());
            thNew.Start();
            Thread thUnanswered = new Thread(() => LoadUnansweredTopics());
            thUnanswered.Start();
            if (user != null)
            {
                if (!tbHompage.TabPages.Contains(tbUser))
                    tbHompage.TabPages.Add(tbUser);
                Thread thUser = new Thread(() => LoadUserTopics());
                thUser.Start();
            }
            else
            {
                if (tbHompage.TabPages.Contains(tbUser))
                    tbHompage.TabPages.Remove(tbUser);
            }
        }

        /// <summary>
        /// Topic Load Invoke
        /// </summary>
        private delegate void InvokeTopicLoad();

        /// <summary>
        /// Laad nieuwe topics
        /// </summary>
        private void LoadNewTopics()
        {
            Thread.Sleep(100);
            // Check if invoke required
            if (lstTopicsNew.InvokeRequired)
            {
                lstTopicsNew.Invoke(new InvokeTopicLoad(LoadNewTopics));
            }
            else
            {
                List<HomepageTopic> topics = Helpmij.GetNewTopics();
                foreach (HomepageTopic topic in topics)
                {
                    lstTopicsNew.Items.Add("[" + topic.GetHour().ToString("00") + ":" + topic.GetMinute().ToString("00") + "] " + topic.GetTitle());
                }
            }
        }

        /// <summary>
        /// Laad onbeantwoorde topics
        /// </summary>
        private void LoadUnansweredTopics()
        {
            Thread.Sleep(100);
            // Check if invoke required
            if (lstTopicsUnanswered.InvokeRequired)
            {
                lstTopicsUnanswered.Invoke(new InvokeTopicLoad(LoadUnansweredTopics));
            }
            else
            {
                List<HomepageTopic> topics = Helpmij.GetUnansweredTopics();
                foreach (HomepageTopic topic in topics)
                {
                    lstTopicsUnanswered.Items.Add("[" + topic.GetHour().ToString("00") + ":" + topic.GetMinute().ToString("00") + "] " + topic.GetTitle());
                }
            }
        }

        /// <summary>
        /// Laad gebruikers topics
        /// </summary>
        private void LoadUserTopics()
        {
            Thread.Sleep(100);
            // Check if invoke required
            if (lstTopicsUser.InvokeRequired)
            {
                lstTopicsUser.Invoke(new InvokeTopicLoad(LoadUserTopics));
            }
            else
            {
                List<HomepageTopic> topics = Helpmij.GetUnansweredTopics(user);
                foreach (HomepageTopic topic in topics)
                {
                    lstTopicsUser.Items.Add("[" + topic.GetHour().ToString("00") + ":" + topic.GetMinute().ToString("00") + "] " + topic.GetTitle());
                }
            }
        }
    }
}
