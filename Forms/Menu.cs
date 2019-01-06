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
        #region Overlay shit
        public const string WindName = "Counter-Strike: Global Offensive";
        IntPtr handle = FindWindow(null, WindName);

        public struct RECT
        {
            public int left, top, right, bottom;
        }

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);
        #endregion

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
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    LoadH();
                }).Start();

                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    Bunnyhop.Start();
                }).Start();

                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    Triggerbot.Start();
                }).Start();

                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    Glow.Start();
                }).Start();

                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    Misc.Start();
                }).Start();
                #endregion
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            TopMost = true;
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
                #region Colors
                Main.TeamColor = Color.FromArgb(TeamR.Value, TeamG.Value, TeamB.Value);
                Main.EnemyColor = Color.FromArgb(EnemR.Value, EnemG.Value, EnemB.Value);

                TeamGlowHeader.ForeColor = Main.TeamColor;
                EnemyGlowHeader.ForeColor = Main.EnemyColor;

                TeamRLabel.Text = "R: " + TeamR.Value.ToString();
                TeamGLabel.Text = "G: " + TeamG.Value.ToString();
                TeamBLabel.Text = "B: " + TeamB.Value.ToString();

                EnemyRLabel.Text = "R: " + EnemR.Value.ToString();
                EnemyGLabel.Text = "G: " + EnemG.Value.ToString();
                EnemyBLabel.Text = "B: " + EnemB.Value.ToString();
                #endregion

                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    Tools.InitializeGlobals();
                }).Start();

                #region Key Checks
                if ((Memory.GetAsyncKeyState(Keys.VK_F1) & 1) > 0)
                    BunnyhopToggle.Toggled = !BunnyhopToggle.Toggled;
                if ((Memory.GetAsyncKeyState(Keys.VK_F2) & 1) > 0)
                    TriggerbotToggle.Toggled = !TriggerbotToggle.Toggled;
                if ((Memory.GetAsyncKeyState(Keys.VK_F3) & 1) > 0)
                    GlowToggle.Toggled = !GlowToggle.Toggled;
                if ((Memory.GetAsyncKeyState(Keys.VK_F4) & 1) > 0)
                    AntiFlashToggle.Toggled = !AntiFlashToggle.Toggled;

                if ((Memory.GetAsyncKeyState(Keys.VK_INSERT) & 1) > 0)
                {
                    Visible = !Visible;

                    if (Visible)
                        FormContainer.Focus();
                }
                #endregion

                Main.BunnyhopEnabled = BunnyhopToggle.Toggled;
                Main.TriggerbotEnabled = TriggerbotToggle.Toggled;
                Main.GlowEnabled = GlowToggle.Toggled;
                Main.NoflashEnabled = AntiFlashToggle.Toggled;


                Thread.Sleep(1);
            }
        }

        private void monoFlat_ThemeContainer1_Click(object sender, EventArgs e)
        {

        }

        private void monoFlat_Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void monoFlat_Label3_Click(object sender, EventArgs e)
        {

        }
    }
}
