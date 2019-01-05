using Binjector.Cheats;
using Binjector.Utilities;
using hazedumper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binjector
{
    public class Main
    {
        public static bool BunnyhopEnabled;
        public static bool TriggerbotEnabled;
        public static bool GlowEnabled;
        public static bool NoflashEnabled;

        public static bool HackRunning = false;

        public static bool RunStartup()
        {
            var CSGO = Process.GetProcessesByName("csgo");
            if (CSGO.Length != 0)
            {
                Memory.g_pProcess = CSGO[0];
                Memory.g_pProcessHandle = Memory.OpenProcess(0x0008 | 0x0010 | 0x0020, false, Memory.g_pProcess.Id);
                foreach (ProcessModule Module in Memory.g_pProcess.Modules)
                {
                    if ((Module.ModuleName == "client_panorama.dll"))
                        Memory.g_pClient = Module.BaseAddress;

                    if ((Module.ModuleName == "engine.dll"))
                        Memory.g_pEngine = Module.BaseAddress;
                }
                Console.WriteLine("csgo process was found");
                return true;

            }
            else
            {
                Console.WriteLine("csgo process not found");
                MessageBox.Show("Please start CSGO before running Binjector", "Binjector", MessageBoxButtons.OK);
                Environment.Exit(1);
                return false; 
            }
        }
    }
}
