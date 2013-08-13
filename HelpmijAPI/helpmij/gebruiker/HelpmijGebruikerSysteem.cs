using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Net;

using mvdw.helpmijapi.gebruiker;
using mvdw.helpmij.utils;

namespace mvdw.helpmij.gebruiker
{
    /// <summary>
    /// Helpmij Gebruiker Systeem
    /// </summary>
    internal class HelpmijGebruikerSysteem : GebruikerSysteem
    {
        /// <summary>
        /// HM Gebruiker Data
        /// </summary>
        private static HMGebruikerData s = new HMGebruikerData();

        /// <summary>
        /// Nickname
        /// </summary>
        private String nickname = null;
        /// <summary>
        /// Functie
        /// </summary>
        private String functie = null;
        /// <summary>
        /// Systeemkast
        /// </summary>
        private String systeemkast = null;
        /// <summary>
        /// Moederbord
        /// </summary>
        private String moederbord = null;
        /// <summary>
        /// Processor
        /// </summary>
        private String processor = null;
        /// <summary>
        /// Geheugen
        /// </summary>
        private String geheugen = null;
        /// <summary>
        /// CPU koeler
        /// </summary>
        private String koeler = null;
        /// <summary>
        /// Case Fan
        /// </summary>
        private String casefan = null;
        /// <summary>
        /// Hard disk
        /// </summary>
        private String harddisk = null;
        /// <summary>
        /// Video kaart
        /// </summary>
        private String videokaart = null;
        /// <summary>
        /// Monitor
        /// </summary>
        private String monitor = null;
        /// <summary>
        /// Brander
        /// </summary>
        private String brander = null;
        /// <summary>
        /// CD/DVD Drives
        /// </summary>
        private String cddvddrives = null;
        /// <summary>
        /// Speakers
        /// </summary>
        private String speakers = null;
        /// <summary>
        /// Geluidskaart
        /// </summary>
        private String geluidskaart = null;
        /// <summary>
        /// Netwerkkaart
        /// </summary>
        private String netwerkkaart = null;
        /// <summary>
        /// Muis
        /// </summary>
        private String muis = null;
        /// <summary>
        /// Toetsenbord
        /// </summary>
        private String toetsenbord = null;
        /// <summary>
        /// Scanner
        /// </summary>
        private String scanner = null;
        /// <summary>
        /// Printer
        /// </summary>
        private String printer = null;
        /// <summary>
        /// Internet Verbinding
        /// </summary>
        private String internetverbinding = null;
        /// <summary>
        /// Bestuuringssysteem
        /// </summary>
        private String besturingssysteem = null;
        /// <summary>
        /// Voeding
        /// </summary>
        private String voeding = null;
        /// <summary>
        /// Extra
        /// </summary>
        private String extra = null;
        /// <summary>
        /// Temperatuur
        /// </summary>
        private String temperatuur = null;
        /// <summary>
        /// Systeem Foto
        /// </summary>
        private Image foto = null;

        /// <summary>
        /// Save een gebruikers systeem
        /// </summary>
        /// <param name="system">System</param>
        /// <returns>Boolean - Result</returns>
        public static Boolean SaveSystem(GebruikerSysteem system, Gebruiker user)
        {
            // Stel pakket op
            Dictionary<string, object> postParameters = new Dictionary<string, object>();
            postParameters.Add("0",system.Nickname);
            postParameters.Add("1", system.Functie);
            postParameters.Add("2", system.Systeemkast);
            postParameters.Add("3", system.Moederbord);
            postParameters.Add("4", system.Processor);
            postParameters.Add("5", system.Geheugen);
            postParameters.Add("6", system.Koeler);
            postParameters.Add("7", system.Casefan);
            postParameters.Add("8", system.Harddisk);
            postParameters.Add("9", system.Videokaart);
            postParameters.Add("10", system.Monitor);
            postParameters.Add("11", system.Brander);
            postParameters.Add("12", system.CdDvdDrives);
            postParameters.Add("13", system.Speakers);
            postParameters.Add("14", system.Geluidskaart);
            postParameters.Add("15", system.Netwerkkaart);
            postParameters.Add("16", system.Muis);
            postParameters.Add("17", system.Toetsenbord);
            postParameters.Add("18", system.Scanner);
            postParameters.Add("19", system.Printer);
            postParameters.Add("20", system.Internetverbinding);
            postParameters.Add("21", system.Besturingssysteem);
            postParameters.Add("22", system.Voeding);
            postParameters.Add("23", system.Extra);
            postParameters.Add("24", system.Temperatuur);
            postParameters.Add("verzenden", "Toevoegen");
            HttpWebResponse webResponse = UtilsHTTP.MultipartFormDataPost(s.siteURL + s.privateSystemAddPHP, postParameters, user.GetCookies());

            // Process response
            StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
            String fullResponse = responseReader.ReadToEnd();
            if (fullResponse == "")
            {
                return true;
            }
            return false; // Failed
        }

        /// <summary>
        /// Get/Set de Nickname van het systeem
        /// </summary>
        public String Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                this.nickname = value;
            }
        }

        /// <summary>
        /// Get/Set de functie van het systeem
        /// </summary>
        public String Functie
        {
            get
            {
                return functie;
            }
            set
            {
                this.functie = value; // Save waarde
            }
        }

        /// <summary>
        /// Get/Set de systeemkast van het systeem
        /// </summary>
        public String Systeemkast
        {
            get
            {
                return systeemkast;
            }
            set
            {
                this.systeemkast = value; // Save waarde
            }
        }

        /// <summary>
        /// Get/Set het moederbord van het systeem
        /// </summary>
        public String Moederbord
        {
            get
            {
                return moederbord;
            }
            set
            {
                this.moederbord = value; // Save waarde
            }
        }

        /// <summary>
        /// Get/Set de processor van het systeem
        /// </summary>
        public String Processor
        {
            get
            {
                return processor;
            }
            set
            {
                this.processor = value; // Save waarde
            }
        }

        /// <summary>
        /// Get/Set het geheugen van het systeem
        /// </summary>
        public String Geheugen
        {
            get
            {
                return geheugen;
            }
            set
            {
                this.geheugen = value; // Save waarde
            }
        }

        /// <summary>
        /// Get/Set de koeler van het systeem
        /// </summary>
        public String Koeler
        {
            get
            {
                return koeler;
            }
            set
            {
                this.koeler = value; // Save waarde
            }
        }

        /// <summary>
        /// Get/Set de case fan van het systeem
        /// </summary>
        public String Casefan
        {
            get
            {
                return casefan;
            }
            set
            {
                this.casefan = value; // Save waarde
            }
        }

        /// <summary>
        /// Get/Set de harddisks van het systeem
        /// </summary>
        public String Harddisk
        {
            get
            {
                return harddisk;
            }
            set
            {
                this.harddisk = value; // Save waarde
            }
        }

        /// <summary>
        /// Get/Set de videokaart(en) van het systeem
        /// </summary>
        public String Videokaart
        {
            get
            {
                return videokaart;
            }
            set
            {
                this.videokaart = value; // Save waarde
            }
        }

        /// <summary>
        /// Get/Set de monitor(en) van het systeem
        /// </summary>
        public String Monitor
        {
            get
            {
                return monitor;
            }
            set
            {
                this.monitor = value; // Save waarde
            }
        }

        /// <summary>
        /// Get/Set de brander van het systeem
        /// </summary>
        public String Brander
        {
            get
            {
                return brander;
            }
            set
            {
                this.brander = value; // Save waarde
            }
        }

        /// <summary>
        /// Get/Set de cd/dvd drives van het systeem
        /// </summary>
        public String CdDvdDrives
        {
            get
            {
                return cddvddrives;
            }
            set
            {
                this.cddvddrives = value; // Save waarde
            }
        }

        /// <summary>
        /// Get/Set de speakers van het systeem
        /// </summary>
        public String Speakers
        {
            get
            {
                return speakers;
            }
            set
            {
                this.speakers = value; // Save waarde
            }
        }

        /// <summary>
        /// Get/Set de geluidskaart van het systeem
        /// </summary>
        public String Geluidskaart
        {
            get
            {
                return geluidskaart;
            }
            set
            {
                this.geluidskaart = value; // Save waarde
            }
        }

        /// <summary>
        /// Get/Set de netwerkkaart(en) van het systeem
        /// </summary>
        public String Netwerkkaart
        {
            get
            {
                return netwerkkaart;
            }
            set
            {
                this.netwerkkaart = value; // Save waarde
            }
        }

        /// <summary>
        /// Get/Set de muis van het systeem
        /// </summary>
        public String Muis
        {
            get
            {
                return muis;
            }
            set
            {
                this.muis = value; // Save waarde
            }
        }

        /// <summary>
        /// Get/Set het toetsenbord van het systeem
        /// </summary>
        public String Toetsenbord
        {
            get
            {
                return toetsenbord;
            }
            set
            {
                this.toetsenbord = value; // Save waarde
            }
        }

        /// <summary>
        /// Get/Set de scanner van het systeem
        /// </summary>
        public String Scanner
        {
            get
            {
                return scanner;
            }
            set
            {
                this.scanner = value; // Save waarde
            }
        }

        /// <summary>
        /// Get/Set de printer van het systeem
        /// </summary>
        public String Printer
        {
            get
            {
                return printer;
            }
            set
            {
                this.printer = value; // Save waarde
            }
        }

        /// <summary>
        /// Get/Set de internetverbinding van het systeem
        /// </summary>
        public String Internetverbinding
        {
            get
            {
                return internetverbinding;
            }
            set
            {
                this.internetverbinding = value; // Save waarde
            }
        }

        /// <summary>
        /// Get/Set het bestuuringssysteem
        /// </summary>
        public String Besturingssysteem
        {
            get
            {
                return besturingssysteem;
            }
            set
            {
                this.besturingssysteem = value; // Save waarde
            }
        }

        /// <summary>
        /// Get/Set de voeding van het systeem
        /// </summary>
        public String Voeding
        {
            get
            {
                return voeding;
            }
            set
            {
                this.voeding = value; // Save waarde
            }
        }

        /// <summary>
        /// Get/Set extra informatie over het systeem
        /// </summary>
        public String Extra
        {
            get
            {
                return extra;
            }
            set
            {
                this.extra = value; // Save waarde
            }
        }

        /// <summary>
        /// Get/Set de temperatuur van het systeem
        /// </summary>
        public String Temperatuur
        {
            get
            {
                return temperatuur;
            }
            set
            {
                this.temperatuur = value; // Save waarde
            }
        }

        /// <summary>
        /// Get/Set een foto van het systeem
        /// </summary>
        public Image Foto
        {
            get
            {
                return foto;
            }
            set
            {
                this.foto = value; // Save waarde
            }
        }
    }
}
