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
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace mvdw.helpmij.ui
{
    /// <summary>
    /// Taskbar Pop-Up
    /// </summary>
    public class TaskbarPopup
    {
        /// <summary>
        /// Pop up Form
        /// </summary>
        Form frmPopup = null;

        /// <summary>
        /// Initialize a new Taskbar popup
        /// </summary>
        /// <param name="style">Style - style</param>
        public TaskbarPopup(Style style)
        {
            // Create a new form
            frmPopup = new Form();
            Image imgBackground = GetStyleBackground(style);
            frmPopup.FormBorderStyle = FormBorderStyle.None;
            frmPopup.Width = imgBackground.Width;
            frmPopup.Height = imgBackground.Height;
            frmPopup.BackgroundImage = imgBackground;
            frmPopup.StartPosition = FormStartPosition.Manual;
            Rectangle workingArea = Screen.GetWorkingArea(frmPopup);
            frmPopup.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - frmPopup.Width,
                       Screen.PrimaryScreen.WorkingArea.Height - frmPopup.Height);
        }

        /// <summary>
        /// Show the popup for a specific time
        /// </summary>
        /// <param name="time">int - Time</param>
        public void Show(int time)
        {
            frmPopup.Show();
        }

        /// <summary>
        /// Pop-Up Styles
        /// </summary>
        public enum Style
        {
            /// <summary>
            /// Default Helpmij Popup
            /// </summary>
            Default
        }

        /// <summary>
        /// Get Style Background
        /// </summary>
        /// <param name="style">Style - style</param>
        /// <returns></returns>
        public Image GetStyleBackground(Style style)
        {
            switch (style)
            {
                case Style.Default:
                    // Default Skin
                    return Properties.Resources.skin1;
            }
            // Not found
            return null;
        }
    }
}
