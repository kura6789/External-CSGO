using Binjector.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Binjector.Main;

namespace Binjector.Utilities
{
    public class ConfigManager
    {
        public static string CurrentConfig = "";

        public static void AddConfig(string name)
        {
            File.WriteAllText($@"{Application.StartupPath}\Configs\{name}.Config.json", "");
            SaveConfig(name);
        }

        public static void CreateEnvironment()
        {
            Directory.CreateDirectory($@"{Application.StartupPath}\Configs");
        }

        public static void SaveConfig(string name)
        {
            Settings sendtoconfig = S;
            string json = JsonConvert.SerializeObject(sendtoconfig, Formatting.Indented);
            File.WriteAllText($@"{Application.StartupPath}\Configs\{name}.Config.json", json);
        }
    }
}
