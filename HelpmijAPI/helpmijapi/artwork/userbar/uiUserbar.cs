using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace mvdw.helpmijapi.artwork.userbar
{
    /// <summary>
    /// Helpmij.nl Userbars
    /// </summary>
    public partial class uiUserbar : UserControl
    {
        /// <summary>
        /// Helpmij.nl Userbars
        /// </summary>
        public uiUserbar()
        {
            InitializeComponent();
            // Basis Userbar
            this.BackgroundImage = resUserbars.UB_Classic_img;
        }

        /// <summary>
        /// Basis Userbar
        /// </summary>
        public List<String> DefaultUserbar
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        private void uiUserbar_Load(object sender, EventArgs e)
        {

        }
    }
}
