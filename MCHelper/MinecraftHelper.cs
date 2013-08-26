using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MinecraftHelper
{
    public static class MinecraftStatic
    {
        public static MinecraftInfo LoginCheck(string UserName, string Password)
        {
            MinecraftInfo InfoToReturn = new MinecraftInfo();

            // Create the login call
            String parameters = "user=" + HttpUtility.UrlEncode(UserName)
                        + "&password=" + HttpUtility.UrlEncode(Password)
                        + "&version=" + 99;//53;

            // post the login call
            string ResultOfCall = NetHelper.excutePost("https://login.minecraft.net/", parameters);

            InfoToReturn.Result = ResultOfCall;

            if (ResultOfCall == null)
            {
                // could not connect
                Console.WriteLine("Error connecting to the Minecraft Login server");
                InfoToReturn.Error = "Error connecting to the Minecraft Login server";
                return InfoToReturn;
            }

            if (ResultOfCall.Contains(':') == false)
            {
                // We have an error message coming in hence the lack of : char
                switch (ResultOfCall.Trim())
                {
                    case "Bad login":
                        Console.WriteLine("Bad User Name");
                        InfoToReturn.Error = "Bad User Name";
                        break;
                    case "Old version":
                        Console.WriteLine("Outdated Luncher...???");
                        InfoToReturn.Error = "Outdated Luncher...??";
                        break;
                    default:
                        Console.WriteLine("New Message: " + ResultOfCall);
                        InfoToReturn.Error = "Other Error: " + ResultOfCall;
                        break;
                }

                return InfoToReturn;
            }

            // We have a valid Login lets out put it to the console for now

            string[] ValuesOfGoodCall = ResultOfCall.Split(new char[] { ':' });

            Console.WriteLine("Full Result: " + ResultOfCall);

            Console.WriteLine("User Name: " + ValuesOfGoodCall[2]);
            InfoToReturn.UserName = ValuesOfGoodCall[2];

            Console.WriteLine("SessionID: " +  ValuesOfGoodCall[3]);
            InfoToReturn.SessionID = ValuesOfGoodCall[3];

            InfoToReturn.Password = Password;

            InfoToReturn.LoginPassed = true;

            return InfoToReturn;
        }

        public static string GetJavaExe()
        {
            string environmentPath = Environment.GetEnvironmentVariable("JAVA_HOME");
            if (!string.IsNullOrEmpty(environmentPath))
            {
                return environmentPath + "\\bin\\java.exe";
            }

            string javaKey = "SOFTWARE\\JavaSoft\\Java Runtime Environment\\";
            using (Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(javaKey))
            {
                string currentVersion = rk.GetValue("CurrentVersion").ToString();
                using (Microsoft.Win32.RegistryKey key = rk.OpenSubKey(currentVersion))
                {
                    return key.GetValue("JavaHome").ToString() + "\\bin\\java.exe";
                }
            }
        }
    }
}
