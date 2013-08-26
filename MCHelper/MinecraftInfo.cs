using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinecraftHelper
{
    public class MinecraftInfo
    {
        public string UserName { get; set; }
        public string SessionID { get; set; }
        public string Password { get; set; }
        public string Result { get; set; }
        public string Error { get; set; }
        public bool LoginPassed { get; set; }

        public MinecraftInfo()
        {
            Result = "123:123:Player:123:123:123:123";
            UserName = "Player";
            SessionID = "123";
            Error = "Offline Mode";
            LoginPassed = false;
        }
    }
}
