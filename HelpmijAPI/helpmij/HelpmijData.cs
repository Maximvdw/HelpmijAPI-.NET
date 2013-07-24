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

namespace mvdw.helpmij
{
    /// <summary>
    /// Helpmij.nl Constant Variables
    /// </summary>
    internal class HelpmijData
    {
        /// <summary>
        /// Chat message Prefix
        /// </summary>
        public static String messagePrefix = @"</span>";
        /// <summary>
        /// Chat message Suffix
        /// </summary>
        public static String messageSuffix = @"</li>";
        /// <summary>
        /// Chat message Username prefix
        /// </summary>
        public static String messageUsernamePrefix = @"<span class=""user"">";
        /// <summary>
        /// Chat message Username suffix
        /// </summary>
        public static String messageUsernameSuffix = @"</span>";
        /// <summary>
        /// Chat message Time prefix
        /// </summary>
        public static String messageTimePrefix = @"<span class=""time"">[";
        /// <summary>
        /// Chat message Time suffix
        /// </summary>
        public static String messageTimeSuffix = @"]</span>";
        /// <summary>
        /// Chat message Color Prefix
        /// </summary>
        public static String messageColorPrefix = @"color: ";
        /// <summary>
        /// Chat message Color Suffix
        /// </summary>
        public static String messageColorSuffix = @""">";
        /// <summary>
        /// Chat message ID Prefix
        /// </summary>
        public static String messageIDPrefix = @"<lid id=""";
        /// <summary>
        /// Chat message ID Suffix
        /// </summary>
        public static String messageIDSuffix = @""" style=""color:";
        /// <summary>
        /// Chat PHP file
        /// </summary>
        public static String chatPHP = "/process.php";
        /// <summary>
        /// Helpmij Chat URL
        /// </summary>
        public static String chatURL = "http://chat.helpmij.nl";
        /// <summary>
        /// Zend een bericht in de chat
        /// </summary>
        public static String chatSendMessage = "function=send&message=";
        /// <summary>
        /// Verkrijg de data van de chat sesise
        /// </summary>
        public static String chatGetState = "function=getState";
        /// <summary>
        /// Site URL (Helpmij)
        /// </summary>
        public static String siteURL = @"http://www.helpmij.nl";
        /// <summary>
        /// Publieke gebruikers gegevens
        /// </summary>
        public static String privateProfile = @"/forum/profile.php?do=editprofile";
        /// <summary>
        /// POST argument van de update acite
        /// </summary>
        public static String actionUpdateArg = "do=updateprofile";
        /// <summary>
        /// Bijkomende POST argumenten
        /// </summary>
        public static String additionalArgs = "s=&serverid=1";
        /// <summary>
        /// De prefix van de javascript var met de sectoken
        /// </summary>
        public static String vartokenPrefix = @"var SECURITYTOKEN = """;
        /// <summary>
        /// De suffix van de javascript var met de sectoken
        /// </summary>
        public static String vartokenSuffix = @""";";
        /// <summary>
        /// Security Token argument
        /// </summary>
        public static String tokenArg = "securitytoken";
        /// <summary>
        /// Avatar URL Prefix
        /// </summary>
        public static String avatarUrlPrefix = siteURL + @"/forum/image.php?u=";
        /// <summary>
        /// Error message prefix
        /// </summary>
        public static String errorPrefix = @"<div class=""blockrow restore"">";
        /// <summary>
        /// Error message suffix
        /// </summary>
        public static String errorSuffix = @"</div>";
        /// <summary>
        /// POST argument van de gebruikersnaam
        /// </summary>
        public static String usernameArg = "vb_login_username";
        /// <summary>
        /// POST argument van het wachtwoord
        /// </summary>
        public static String passwordArg = "vb_login_password";
        /// <summary>
        /// POST argument van het gehashte wachtwoord
        /// </summary>
        public static String passwordMD5Arg = "vb_login_md5password";
        /// <summary>
        /// POST argument van het gehashte wachtwoord UTF
        /// </summary>
        public static String passwordMD5utfArg = "vb_login_md5password_utf";
        /// <summary>
        /// POST argument van de login actie
        /// </summary>
        public static String actionLoginArg = "do=login";
        /// <summary>
        /// Patch naar login php file
        /// </summary>
        public static String loginPHP = @"/forum/login.php";
        /// <summary>
        /// Patch naar de signature php file
        /// </summary>
        public static String signaturePHP = @"/forum/profile.php?do=editsignature";
        /// <summary>
        /// De prefix van de javascript var met de userid
        /// </summary>
        public static String varidPrefix = "var LOGGEDIN = ";
        /// <summary>
        /// De suffix van de javascript var met de userid
        /// </summary>
        public static String varidSuffix = " >";
        /// <summary>
        /// De prefix van een nieuwe topic URL
        /// </summary>
        public static String newTopicUrlPrefix = @"<a href=""";
        /// <summary>
        /// De suffix van een nieuwe topic URL
        /// </summary>
        public static String newTopicUrlSuffix = @""" class=""last_title""";
        /// <summary>
        /// De prefix van een nieuwe topic TITEL
        /// </summary>
        public static String newTopicTitlePrefix = @"class=""last_title"" title=""";
        /// <summary>
        /// De suffix van een nieuwe topic TITEL
        /// </summary>
        public static String newTopicTitleSuffix = @"""><span>";
        /// <summary>
        /// De prefix van een nieuwe topic TIME
        /// </summary>
        public static String newTopicTimePrefix = @"""><span>";
        /// <summary>
        /// De suffix van een nieuwe topic TIME
        /// </summary>
        public static String newTopicTimeSuffix = @" &gt;";
        /// <summary>
        /// Tab pagina met laatste nieuwe topics
        /// </summary>
        public static String homepageTab1 = @"ui-tabs-panel"" id=""tab_latest_questions_1";
        /// <summary>
        /// Tab pagina met laatste onbeantwoorde topics
        /// </summary>
        public static String homepageTab2 = @"ui-tabs-panel"" id=""tab_latest_questions_2";
        /// <summary>
        /// Tab pagina met laatste topics van user
        /// </summary>
        public static String homepageTab3 = @"ui-tabs-panel"" id=""tab_latest_questions_3";
        /// <summary>
        /// Prefix van Member id-naam
        /// </summary>
        public static String memberPrefix = @" href=""member.php/";
        /// <summary>
        /// Suffix van Member id-naam
        /// </summary>
        public static String memberSuffix = @""" title=";
        /// <summary>
        /// Suffix van Member Author id-naam
        /// </summary>
        public static String authorSuffix = "?s=";
        /// <summary>
        /// Prefix van een Topic Title
        /// </summary>
        public static String titlePrefix = "<title> ";
        /// <summary>
        /// Suffix van een Topic Title
        /// </summary>
        public static String titleSuffix = "</title>";
        /// <summary>
        /// Prefix van de Keywords
        /// </summary>
        public static String metaKeywordPrefix = @"<meta name=""keywords"" content=""";
        /// <summary>
        /// Suffix van de Keywords
        /// </summary>
        public static String metaKeywordSuffix = @""" />";
        /// <summary>
        /// Prefix van een topic post
        /// </summary>
        public static String postPrefix = @"<blockquote class=""postcontent restore "">";
        /// <summary>
        /// Suffix van een topic post
        /// </summary>
        public static String postSuffix = @"</blockquote>";
        /// <summary>
        /// Prefix voor Forum data id-naam
        /// </summary>
        public static String forumPrefix = @"<a href=""forumdisplay.php/";
        /// <summary>
        /// Suffix voor Forum data id-naam zonder subforums
        /// </summary>
        public static String forumSuffix = @""">";
        /// <summary>
        /// Suffix voor Forum data id-naam met subforums
        /// </summary>
        public static String forumTopSuffix = @""" class=""forumtitle"">";
        /// <summary>
        /// Prefix van de gebruikers registratie
        /// </summary>
        public static String registratedPrefix = @"<dt>Geregistreerd</dt>.*?<dd>  ";
        /// <summary>
        /// Suffix van de gebruikers registratie
        /// </summary>
        public static String registratedSuffix = @"</dd>";
        /// <summary>
        /// Signagure - Field
        /// </summary>
        public static String signagureField = "message";
        /// <summary>
        /// Signature HTML - prefix
        /// </summary>
        public static String signatureHTMLPrefix = @"restore preview postcontainer"">";
        /// <summary>
        /// Signature HTML - suffix
        /// </summary>
        public static String signatureHTMLSuffix = @"</blockquote>";
        /// <summary>
        /// Signature BB - Prefix
        /// </summary>
        public static String signatureBBPrefix = @"vB_Editor_001_editor"" name=""message"" rows=""8"" cols=""60"" tabindex=""1"">";
        /// <summary>
        /// Signature BB - Suffix
        /// </summary>
        public static String signatureBBSuffix = @"</textarea>";
        /// <summary>
        /// Website DATA - Field
        /// </summary>
        public static String websiteField = "homepage";
        /// <summary>
        /// Website DATA - Prefix
        /// </summary>
        public static String websitePrefix = @"id=""tb_homepage"" value=""";
        /// <summary>
        /// Webiste DATA - Suffix
        /// </summary>
        public static String websiteSuffix = @""" maxlength=";
        /// <summary>
        /// MSN Data - Field
        /// </summary>
        public static String msnField = "msn";
        /// <summary>
        /// MSN DATA - Prefix
        /// </summary>
        public static String msnPrefix = @"name=""" + msnField + @""" value=""";
        /// <summary>
        /// MSN DATA - Suffix
        /// </summary>
        public static String msnSuffix = @""" maxlength=";
        /// <summary>
        /// ICQ Data - Field
        /// </summary>
        public static String icqField = "icq";
        /// <summary>
        /// ICQ DATA - Prefix
        /// </summary>
        public static String icqPrefix = @"name=""" + icqField + @""" value=""";
        /// <summary>
        /// ICQ DATA - Suffix
        /// </summary>
        public static String icqSuffix = @""" maxlength=";
        /// <summary>
        /// AIM Data - Field
        /// </summary>
        public static String aimField = "aim";
        /// <summary>
        /// AIM DATA - Prefix
        /// </summary>
        public static String aimPrefix = @"name=""" + aimField + @""" value=""";
        /// <summary>
        /// AIM DATA - Suffix
        /// </summary>
        public static String aimSuffix = @""" maxlength=";
        /// <summary>
        /// Yahoo Data - Field
        /// </summary>
        public static String yahooField = "yahoo";
        /// <summary>
        /// Yahoo DATA - Prefix
        /// </summary>
        public static String yahooPrefix = @"name=""" + yahooField + @""" value=""";
        /// <summary>
        /// Yahoo DATA - Suffix
        /// </summary>
        public static String yahooSuffix = @""" maxlength=";
        /// <summary>
        /// Skype Data - Field
        /// </summary>
        public static String skypeField = "skype";
        /// <summary>
        /// Skype DATA - Prefix
        /// </summary>
        public static String skypePrefix = @"name=""" + skypeField + @""" value=""";
        /// <summary>
        /// Skype DATA - Suffix
        /// </summary>
        public static String skypeSuffix = @""" maxlength=";
        /// <summary>
        /// Jabber Data - Field
        /// </summary>
        public static String jabberField = "userfield[field7]";
        /// <summary>
        /// Jabber DATA - Prefix
        /// </summary>
        public static String jabberPrefix = @"id=""cfield_7"" value=""";
        /// <summary>
        /// Jabber DATA - Suffix
        /// </summary>
        public static String jabberSuffix = @""" maxlength=";
        /// <summary>
        /// Biografie Data - Field
        /// </summary>
        public static String biografieField = "userfield[field1]";
        /// <summary>
        /// Biografie DATA - Prefix
        /// </summary>
        public static String biografiePrefix = @"id=""cfield_1"" rows=""0"" cols=""60"" tabindex=""1"">";
        /// <summary>
        /// Biografie DATA - Suffix
        /// </summary>
        public static String biografieSuffix = @"</textarea>";
        /// <summary>
        /// Woonplaats Data - Field
        /// </summary>
        public static String woonplaatsField = "userfield[field2]";
        /// <summary>
        /// Woonplaats DATA - Prefix
        /// </summary>
        public static String woonplaatsPrefix = @"id=""cfield_2"" value=""";
        /// <summary>
        /// Woonplaats DATA - Suffix
        /// </summary>
        public static String woonplaatsSuffix = @""" maxlength=";
        /// <summary>
        /// Hobbys Data - Field
        /// </summary>
        public static String hobbysField = "userfield[field3]";
        /// <summary>
        /// Hobbys DATA - Prefix
        /// </summary>
        public static String hobbysPrefix = @"id=""cfield_3"" value=""";
        /// <summary>
        /// Hobbys DATA - Suffix
        /// </summary>
        public static String hobbysSuffix = @""" maxlength=";
        /// <summary>
        /// Beroep Data - Field
        /// </summary>
        public static String beroepField = "userfield[field4]";
        /// <summary>
        /// Beroep DATA - Prefix
        /// </summary>
        public static String beroepPrefix = @"id=""cfield_4"" value=""";
        /// <summary>
        /// Beroep DATA - Suffix
        /// </summary>
        public static String beroepSuffix = @""" maxlength=";
        /// <summary>
        /// Jaar Data - Field
        /// </summary>
        public static String jaarField = "year";
        /// <summary>
        /// Jaar DATA - Prefix
        /// </summary>
        public static String jaarPrefix = @"name=""" + jaarField + @""" value=""";
        /// <summary>
        /// Jaar DATA - Suffix
        /// </summary>
        public static String jaarSuffix = @""" maxlength=";
        /// <summary>
        /// Maand Data - Field
        /// </summary>
        public static String maansField = "month";
        /// <summary>
        /// Dag Data - Field
        /// </summary>
        public static String dagField = "dag";
        /// <summary>
        /// Dropdown DATA - Prefix
        /// </summary>
        public static String selectedPrefix = @"<option value=""";
        /// <summary>
        /// Dropdown DATA - Suffix
        /// </summary>
        public static String selectedSuffix = @""" selected=""selected"">";
    }
}
