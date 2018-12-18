using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Binjector_CSGO_V2.Cheats;
using Binjector_CSGO_V2.Utilities;

namespace Binjector_CSGO_V2
{
    public partial class Menu : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        public static bool ConsoleStarted = false;
        public static bool DebugEnabled = false;
        public Menu()
        {
            //AllocConsole();
            InitializeComponent();

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
                Thread MainThread = new Thread(Main);
                MainThread.Start();
            }
            else
            {
                MessageBox.Show("Start csgo.exe!", "Binjector V2", MessageBoxButtons.OK);
                Environment.Exit(1);
            }
        }
        
        public void Main()
        {
            Console.WriteLine("Starting Stuff");
            while (true)
            {
                Vars.LocalPlayer = Memory.ReadMemory<int>((int)Memory.g_pClient + Offsets.dwLocalPlayer);
                Vars.MyTeam = Memory.ReadMemory<int>(Vars.LocalPlayer + Offsets.m_iTeamNum);
                Vars.GlowObjectManager = Memory.ReadMemory<int>((int)Memory.g_pClient + Offsets.dwGlowObjectManager);

                if ((Memory.GetAsyncKeyState(0x70) & 1) > 0)
                    BunnyHopCheck.Checked = !BunnyHopCheck.Checked;
                if ((Memory.GetAsyncKeyState(0x71) & 1) > 0)
                    TriggerBotChecked.Checked = !TriggerBotChecked.Checked;
                if ((Memory.GetAsyncKeyState(0x72) & 1) > 0)
                    ESPChecked.Checked = !ESPChecked.Checked;
                if ((Memory.GetAsyncKeyState(0x79) & 1) > 0)
                    DebugEnabled = !DebugEnabled;

                if (BunnyHopCheck.Checked)
                    Bunnyhop.Start();
                if (TriggerBotChecked.Checked)
                    TriggerBot.Start();
                if (ESPChecked.Checked)
                    Wallhack.Start();

                if (ConsoleStarted == false && DebugEnabled)
                {
                    AllocConsole();
                    ConsoleStarted = true;
                }
                Thread.Sleep(1);
            }
        }
    }
}
