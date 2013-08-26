using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace MinecraftHelper
{
    public static class NetHelper
    {
        // The stream of data retrieved from the web server
        private static Stream strResponse;
        // The stream of data that we write to the harddrive
        private static Stream strLocal;
        // The request to the web server for file information
        private static HttpWebRequest webRequest;
        // The response from the web server containing information about the file
        private static HttpWebResponse webResponse;

        /// <summary>
        /// Exicute a web post. Taken from MCLuncher.net, it was just that good.
        /// </summary>
        /// <param name="targetURL"></param>
        /// <param name="urlParameters"></param>
        /// <returns></returns>
        public static String excutePost(String targetURL, String urlParameters)
        {
            // create a request
            HttpWebRequest request = (HttpWebRequest)
            WebRequest.Create(targetURL); request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";

            // turn our request string into a byte stream
            byte[] postBytes = Encoding.ASCII.GetBytes(urlParameters);

            // this is important - make sure you specify type this way
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postBytes.Length;
            Stream requestStream = request.GetRequestStream();

            // now send it
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();

            // grab te response and print it out to the console along with the status code
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        /// <summary>
        /// Scooped from MCLauncher.net
        /// </summary>
        /// <param name="targetURL"></param>
        /// <param name="urlParameters"></param>
        /// <returns></returns>
        public static String excuteGet(String targetURL, String urlParameters)
        {
            // create a request
            HttpWebRequest request = (HttpWebRequest)
            WebRequest.Create(targetURL + "?" + urlParameters); request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "GET";

            // turn our request string into a byte stream
            byte[] postBytes = Encoding.ASCII.GetBytes(urlParameters);

            // this is important - make sure you specify type this way
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postBytes.Length;
            Stream requestStream = request.GetRequestStream();

            // now send it
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();

            // grab te response and print it out to the console along with the status code
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        public static string Download(string URL)
        {
            using (WebClient DownloadClient = new WebClient())
            {
                return DownloadClient.DownloadString(URL);
            }
        }

        public static void DownloadFile(string URL, string DownloadLocation)
        {
            using (WebClient DownloadFile = new WebClient())
            {
                DownloadFile.DownloadFile(new Uri(URL), DownloadLocation);
            }
        }

    }
}
