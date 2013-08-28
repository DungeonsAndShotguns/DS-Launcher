using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using MinecraftHelper;

namespace LaunchDS
{
    public class Settings
    {
        public int MinMemory { get; set; }
        public int MaxMemory { get; set; }
        //public string LastLogin { get; set; }
        public Dictionary<string, string> Configs = new Dictionary<string, string>();


        public Settings()
        {
            MinMemory = 2048;
            MaxMemory = 2048;
            LoadSettingsFile();
        }

        public void LoadSettingsFile()
        {
            ArrayList ConfigFileds = new ArrayList();

            if (File.Exists("settings.cfg") == true)
            {
                using (StreamReader ReadConfigFile = new StreamReader("settings.cfg"))
                {
                    while (ReadConfigFile.EndOfStream != true)
                    {
                        ConfigFileds.Add(ReadConfigFile.ReadLine());   
                    }
                }

                string[] TempConfigPair = new string[2];

                foreach (string Row in ConfigFileds)
                {
                    if (string.IsNullOrEmpty(Row) != true)
                    {
                        TempConfigPair = Row.Split(new char[1] { '=' });
                        try
                        {
                            Configs.Add(TempConfigPair[0], TempConfigPair[1]);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            else
            {
               
            }

            if (Configs.ContainsKey("JavaPath") == false)
            {
                Configs.Add("JavaPath", MinecraftStatic.GetJavaExe());
            }
        }

        public void SaveSettingsFile()
        {
            if (File.Exists("settings.cfg") == true)
            {
                File.Delete("settings.cfg");
            }

            using (StreamWriter WriteConfig = new StreamWriter("settings.cfg"))
            {
                foreach (KeyValuePair<string, string> Row in Configs)
                {
                    WriteConfig.WriteLine(Row.Key + "=" + Row.Value);
                }

                WriteConfig.Flush();
            }
        }

        public void UpdateSetting(string Key, string Value)
        {
            if (Configs.ContainsKey(Key) == true)
            {
                Configs[Key] = Value;
            }
            else
            {
                Configs.Add(Key, Value);
            }
        }

        public string GetSetting(string Key)
        {
            if (Configs.ContainsKey(Key) == true)
            {
                return Configs[Key];
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
