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
using System.Text;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using mvdw.helpmijapi;

namespace mvdw.helpmij.utils
{
    /// <summary>
    /// HTTP Utilities
    /// </summary>
    internal class UtilsHTTP
    {
        /// <summary>
        /// User Agent
        /// </summary>
        private static String userAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.2.11) Gecko/20101012 Firefox/3.6.11";

        /// <summary>
        /// Controlleer of er verbinding is met www.helpmij.nl
        /// </summary>
        /// <returns>Boolean - True bij verbinding</returns>
        public static Boolean IsInternetAvailable()
        {
            try
            {
                var ping = new Ping();
                // Constrolleer met google, want ICMP bij helpmij staat af
                var result = ping.Send("www.google.com");
                if (result.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                // False
                return false;
            }
        }

        /// <summary>
        /// Verkrijg de source code van een webpage
        /// </summary>
        /// <param name="postData">POST data</param>
        /// <param name="url">De url</param>
        /// <param name="cookies">De cookies</param>
        /// <returns>String - Broncode</returns>
        public static String GetPOSTSource(String postData, String url, ref CookieContainer cookies)
        {
            // Initializeer de request en response
            HttpWebResponse response;
            HttpWebRequest request;
            request = (HttpWebRequest)WebRequest.Create(url);
            // Request parameters instellen
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postData.Length;
            request.Method = "POST";
            request.AllowAutoRedirect = false;
            request.CookieContainer = cookies;
            request.UserAgent = userAgent;
            // Controlleer of er een proxy server moet worden gebruikt
            if (HelpmijConfig.PROXY == true)
                request.Proxy = HelpmijConfig.PROXY_SERVER;

            Stream requestStream = request.GetRequestStream();
            Byte[] postBytes = Encoding.ASCII.GetBytes(postData);
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Flush();
            requestStream.Close();
            response = (HttpWebResponse)request.GetResponse();

            // Save de cookies
            foreach (Cookie tempCookie in response.Cookies)
            {
                cookies.Add(tempCookie);
            }

            // Lees de broncode
            String source;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                source = reader.ReadToEnd();
            }
            // Get Download size [RAW}
            HelpmijAPI._downloadSize += source.Length;

            response.Close();

            // Return de source code
            return source;
        }

        /// <summary>
        /// Verkrijg de source code van een webpage
        /// </summary>
        /// <param name="url">De url</param>
        /// <param name="cookies">De cookies</param>
        /// <returns>String - Broncode</returns>
        public static String GetSource(String url, CookieContainer cookies)
        {
            // Initializeer de request en response
            HttpWebResponse response;
            HttpWebRequest request;
            request = (HttpWebRequest)WebRequest.Create(url);
            // Request parameters instellen
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "GET";
            request.AllowAutoRedirect = false;
            request.CookieContainer = cookies;
            request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.2.11) Gecko/20101012 Firefox/3.6.11";
            // Controlleer of er een proxy server moet worden gebruikt
            if (HelpmijConfig.PROXY == true)
                request.Proxy = HelpmijConfig.PROXY_SERVER;

            response = (HttpWebResponse)request.GetResponse();

            // Save de cookies
            foreach (Cookie tempCookie in response.Cookies)
            {
                cookies.Add(tempCookie);
            }

            // Lees de broncode
            String source;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                source = reader.ReadToEnd();
            }
            // Get Download size [RAW}
            HelpmijAPI._downloadSize += source.Length;

            response.Close();

            // Return de source code
            return source;
        }

        private static readonly Encoding encoding = Encoding.UTF8;

        public static HttpWebResponse MultipartFormDataPost(string postUrl, Dictionary<string, object> postParameters, CookieContainer cookies)
        {
            string formDataBoundary = String.Format("----------{0:N}", Guid.NewGuid());
            string contentType = "multipart/form-data; boundary=" + formDataBoundary;

            byte[] formData = GetMultipartFormData(postParameters, formDataBoundary);

            return PostForm(postUrl, contentType, formData, cookies);
        }
        private static HttpWebResponse PostForm(string postUrl, string contentType, byte[] formData, CookieContainer cookies)
        {
            HttpWebRequest request = WebRequest.Create(postUrl) as HttpWebRequest;

            if (request == null)
            {
                throw new NullReferenceException("request is not a http request");
            }

            // Set up the request properties.
            request.Method = "POST";
            request.ContentType = contentType;
            request.UserAgent = userAgent;
            request.CookieContainer = cookies;
            request.ContentLength = formData.Length;

            // You could add authentication here as well if needed:
            // request.PreAuthenticate = true;
            // request.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequested;
            // request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.Encoding.Default.GetBytes("username" + ":" + "password")));

            // Send the form data to the request.
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(formData, 0, formData.Length);
                requestStream.Close();
            }

            return request.GetResponse() as HttpWebResponse;
        }

        private static byte[] GetMultipartFormData(Dictionary<string, object> postParameters, string boundary)
        {
            Stream formDataStream = new System.IO.MemoryStream();
            bool needsCLRF = false;

            foreach (var param in postParameters)
            {
                // Thanks to feedback from commenters, add a CRLF to allow multiple parameters to be added.
                // Skip it on the first parameter, add it to subsequent parameters.
                if (needsCLRF)
                    formDataStream.Write(encoding.GetBytes("\r\n"), 0, encoding.GetByteCount("\r\n"));

                needsCLRF = true;

                if (param.Value is FileParameter)
                {
                    FileParameter fileToUpload = (FileParameter)param.Value;

                    // Add just the first part of this param, since we will write the file data directly to the Stream
                    string header = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\";\r\nContent-Type: {3}\r\n\r\n",
                        boundary,
                        param.Key,
                        fileToUpload.FileName ?? param.Key,
                        fileToUpload.ContentType ?? "application/octet-stream");

                    formDataStream.Write(encoding.GetBytes(header), 0, encoding.GetByteCount(header));

                    // Write the file data directly to the Stream, rather than serializing it to a string.
                    formDataStream.Write(fileToUpload.File, 0, fileToUpload.File.Length);
                }
                else
                {
                    string postData = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}",
                        boundary,
                        param.Key,
                        param.Value);
                    formDataStream.Write(encoding.GetBytes(postData), 0, encoding.GetByteCount(postData));
                }
            }

            // Add the end of the request.  Start with a newline
            string footer = "\r\n--" + boundary + "--\r\n";
            formDataStream.Write(encoding.GetBytes(footer), 0, encoding.GetByteCount(footer));

            // Dump the Stream into a byte[]
            formDataStream.Position = 0;
            byte[] formData = new byte[formDataStream.Length];
            formDataStream.Read(formData, 0, formData.Length);
            formDataStream.Close();

            return formData;
        }

        /// <summary>
        /// File Parameters
        /// </summary>
        public class FileParameter
        {
            public byte[] File { get; set; }
            public string FileName { get; set; }
            public string ContentType { get; set; }
            public FileParameter(byte[] file) : this(file, null) { }
            public FileParameter(byte[] file, string filename) : this(file, filename, null) { }
            public FileParameter(byte[] file, string filename, string contenttype)
            {
                File = file;
                FileName = filename;
                ContentType = contenttype;
            }
        }
    }
}
