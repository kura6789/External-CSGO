using Binjector.Cheats;
using Binjector.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace Binjector
{
    public partial class Menu : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public Menu()
        {
            //AllocConsole();
            InitializeComponent();

            if (Main.RunStartup())
            {
                #region Start Cheats
                new Thread(() => {
                    Thread.CurrentThread.IsBackground = true; 
                    LoadH();
                }).Start();

                new Thread(() => {
                    Thread.CurrentThread.IsBackground = true; 
                    Bunnyhop.Start();
                }).Start();

                new Thread(() => {
                    Thread.CurrentThread.IsBackground = true; 
                    Triggerbot.Start();
                }).Start();

                new Thread(() => {
                    Thread.CurrentThread.IsBackground = true; 
                    Glow.Start();
                }).Start();

                new Thread(() => {
                    Thread.CurrentThread.IsBackground = true; 
                    Noflash.Start();
                }).Start();
                #endregion
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            
        }

        public void LoadH()
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.Volume = 40;  // 0...100
            synthesizer.Rate = 0;     // -10...10
            Console.WriteLine("Start");
            Main.RunStartup();

            while (true)
            {
                Tools.InitializeGlobals();

                #region Key Checks
                if ((Memory.GetAsyncKeyState(Keys.VK_F1) & 1) > 0)
                {
                    BunnyHopCheck.Checked = !BunnyHopCheck.Checked;
                    if (voiceconfirm.Checked)
                        synthesizer.SpeakAsync("Bunny Hop " + BunnyHopCheck.Checked);
                }
                if ((Memory.GetAsyncKeyState(Keys.VK_F2) & 1) > 0)
                {
                    TriggerBotCheck.Checked = !TriggerBotCheck.Checked;
                    if (voiceconfirm.Checked)
                        synthesizer.SpeakAsync("Trigger Bot " + TriggerBotCheck.Checked);
                }
                if ((Memory.GetAsyncKeyState(Keys.VK_F3) & 1) > 0)
                {
                    GlowCheck.Checked = !GlowCheck.Checked;
                    if (voiceconfirm.Checked)
                        synthesizer.SpeakAsync("Glow " + GlowCheck.Checked);
                }
                if ((Memory.GetAsyncKeyState(Keys.VK_F4) & 1) > 0)
                {
                    NoflashCheck.Checked = !NoflashCheck.Checked;
                    if (voiceconfirm.Checked)
                        synthesizer.SpeakAsync("No Flash " + NoflashCheck.Checked);
                }
                #endregion

                Main.BunnyhopEnabled = BunnyHopCheck.Checked;
                Main.TriggerbotEnabled = TriggerBotCheck.Checked;
                Main.GlowEnabled = GlowCheck.Checked;
                Main.NoflashEnabled = NoflashCheck.Checked;

                Thread.Sleep(1);
            }
        }
    }
}
