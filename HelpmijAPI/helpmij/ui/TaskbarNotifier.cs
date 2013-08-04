using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mvdw.helpmij.ui
{
    public partial class TaskbarNotifier : Form
    {
        public TaskbarNotifier()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sluit de TaskbarNotifier
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Arguments</param>
        private void lnkClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
