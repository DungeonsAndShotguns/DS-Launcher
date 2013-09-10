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

      public static CookieContainer login(string url, string username, string password)
      {
         if (url.Length == 0 || username.Length == 0 || password.Length == 0)
         {
            Console.WriteLine("Information missing");
            return null;
         }

         CookieContainer myContainer = new CookieContainer();

         HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
         request.CookieContainer = new CookieContainer();

         // Set type to POST
         request.Method = "POST";
         request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
         request.ContentType = "application/x-www-form-urlencoded";

         // Build the new header, this isn't a multipart/form, so it's very simple
         StringBuilder data = new StringBuilder();
         data.Append("username=" + Uri.EscapeDataString(username));
         data.Append("&password=" + Uri.EscapeDataString(password));
         data.Append("&login=Login");

         // Create a byte array of the data we want to send
         byte[] byteData = UTF8Encoding.UTF8.GetBytes(data.ToString());

         // Set the content length in the request headers
         request.ContentLength = byteData.Length;

         Stream postStream;
         try
         {
            postStream = request.GetRequestStream();
         }
         catch (Exception e)
         {
            Console.WriteLine("Login - " + e.Message.ToString() + " (GRS)");
            return null;
         }

         // Write data
         postStream.Write(byteData, 0, byteData.Length);

         HttpWebResponse response;
         try
         {
            response = (HttpWebResponse)request.GetResponse();
         }
         catch (Exception e)
         {
            Console.WriteLine("Login - " + e.Message.ToString() + " (GR)");
            return null;
         }

         bool isLoggedIn = false;

         // Store the cookies
         foreach (Cookie c in response.Cookies)
         {
            if (c.Name.Contains("_u"))
            {
               if (Convert.ToInt32(c.Value) > 1)
               {
                  isLoggedIn = true;
               }
            }
            myContainer.Add(c);
         }

         if (isLoggedIn)
         {
            return myContainer;
         }
         else
         {
            return null;
         }
      }

    }
}
