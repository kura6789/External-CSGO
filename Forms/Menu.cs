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
using static Binjector.Main;
using System.IO;
using Newtonsoft.Json;
using Binjector.Classes;

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
            if (RunStartup())
            {
                OffsetUpdater.UpdateOffsets();
                #region Start Cheats
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    CheckMenu();
                }).Start();
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    Tools.InitializeGlobals();
                }).Start();
                /////////////////////////////////////////////////
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
                    Visuals.Start();
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
            UpdateConfigList();
        }

        public void CheckMenu()
        {
            TeamGlowColorBtn.BackColor = Color.FromArgb(0, 255, 0);
            EnemyGlowColorBtn.BackColor = Color.FromArgb(255, 0, 0);
            BomberGlowBtn.BackColor = Color.FromArgb(255, 255, 0);
            TeamChamBtn.BackColor = Color.FromArgb(0, 255, 0);
            EnemyChamBtn.BackColor = Color.FromArgb(255, 0, 0);
            ChamBomberBtn.BackColor = Color.FromArgb(255, 255, 0);

            while (true)
            {
                #region Colors

                S.GlowTeamColor = TeamGlowColorBtn.BackColor;
                S.GlowEnemyColor = EnemyGlowColorBtn.BackColor;
                S.GlowBomberColor = BomberGlowBtn.BackColor;

                S.ChamTeamColor = TeamChamBtn.BackColor;
                S.ChamEnemyColor = EnemyChamBtn.BackColor;
                S.ChamBomberColor = ChamBomberBtn.BackColor;
                #endregion
                #region Key Checks
                if ((Memory.GetAsyncKeyState(Keys.VK_INSERT) & 1) > 0)
                    Visible = !Visible;
                #endregion

                S.MiscEnabled = MiscToggle.Checked;
                S.BunnyhopEnabled = BunnyhopToggle.Checked;
                S.TriggerbotEnabled = TriggerbotToggle.Checked;
                S.GlowEnabled = GlowToggle.Checked;
                S.NoflashEnabled = NoflashToggle.Checked;
                S.RadarEnabled = RadarhackToggle.Checked;
                S.ChamsEnabled = ChamsToggle.Checked;
                S.GlowTeam = GlowTeam.Checked;
                S.GlowHealth = GlowHealth.Checked;
                S.GlowBomber = GlowBomber.Checked;
                S.ChamTeam = ChamTeam.Checked;
                S.ChamHealth = ChamHealth.Checked;
                S.ChamBomber = ChamBomber.Checked;
                S.OnlyNotMoving = OnlyNotMoving.Checked;
                S.OnlyScoped = OnlyScoped.Checked;
                S.Firerate = (int)Firerate.Value;
                S.AimEnabled = AimbotToggle.Checked;
                S.RCSEnabled = RcsToggle.Checked;

                Thread.Sleep(1);
            }
        }
        public void UpdateConfigList()
        {
            DirectoryInfo d = new DirectoryInfo($@"{Application.StartupPath}\Configs");
            FileInfo[] Files = d.GetFiles("*.json");
            ConfigDropdown.Items.Clear();
            foreach (FileInfo file in Files)
            {
                ConfigDropdown.Items.Add(file.Name.Substring(0, file.Name.Length - 12));
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HideButton_Click(object sender, EventArgs e)
        {
            Visible = !Visible;
        }
        #region Color button Checks
        private void TeamGlowColorBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                TeamGlowColorBtn.BackColor = colorDialog1.Color;
            }
        }

        private void EnemyGlowColorBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                EnemyGlowColorBtn.BackColor = colorDialog1.Color;
            }
        }

        private void BomberGlowBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                BomberGlowBtn.BackColor = colorDialog1.Color;
            }
        }

        private void TeamChamBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                TeamChamBtn.BackColor = colorDialog1.Color;
            }
        }

        private void EnemyChamBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                EnemyChamBtn.BackColor = colorDialog1.Color;
            }
        }

        private void ChamBomberBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ChamBomberBtn.BackColor = colorDialog1.Color;
            }
        }
        #endregion

        private void CreateConfig_Click(object sender, EventArgs e)
        {
            ConfigManager.AddConfig(ConfigTextbox.Text);
            ConfigTextbox.Text = "";

            foreach (string config in Configs)
            {
                ConfigDropdown.Items.Add(config);
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            UpdateConfigList();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            ConfigManager.SaveConfig(ConfigManager.CurrentConfig);
        }

        private void ConfigDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigManager.CurrentConfig = ConfigDropdown.Text;
            CurConfig.Text = "Using Config: " + ConfigManager.CurrentConfig;

            string json = File.ReadAllText($@"{Application.StartupPath}\Configs\{ConfigManager.CurrentConfig}.Config.json");
            Settings s = JsonConvert.DeserializeObject<Settings>(json);

            BunnyhopToggle.Checked = s.BunnyhopEnabled;
            TriggerbotToggle.Checked = s.TriggerbotEnabled;
            GlowToggle.Checked = s.GlowEnabled;
            NoflashToggle.Checked = s.NoflashEnabled;
            ChamsToggle.Checked = s.ChamsEnabled;
            GlowTeam.Checked = s.GlowTeam;
            GlowHealth.Checked = s.GlowHealth;
            GlowBomber.Checked = s.GlowBomber;
            TeamGlowColorBtn.BackColor = s.GlowTeamColor;
            EnemyGlowColorBtn.BackColor = s.GlowEnemyColor;
            BomberGlowBtn.BackColor = s.GlowBomberColor;
            TeamChamBtn.BackColor = s.ChamTeamColor;
            EnemyChamBtn.BackColor = s.ChamEnemyColor;
            ChamBomberBtn.BackColor = s.ChamBomberColor;
            MiscToggle.Checked = s.MiscEnabled;
            ChamHealth.Checked = s.ChamHealth;
            ChamTeam.Checked = s.ChamTeam;
            ChamBomber.Checked = s.ChamBomber;
            OnlyScoped.Checked = s.OnlyScoped;
            OnlyNotMoving.Checked = s.OnlyNotMoving;
            RadarhackToggle.Checked = s.RadarEnabled;
            Firerate.Value = s.Firerate;
            AimbotToggle.Checked = s.AimEnabled;
            RcsToggle.Checked = s.RCSEnabled;
        }
    }
}
