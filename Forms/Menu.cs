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
using Binjector.Forms;
using System.Numerics;

namespace Binjector
{
    public partial class Menu : Form
    {
        Overlay overlay = new Overlay();

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
            LastOffset.Text = "Last Offset Update: " + new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(Main.O.timestamp).ToLocalTime();
            UpdateConfigList();
        }

        public void CheckMenu()
        {
            

            Color Red = Color.FromArgb(255, 0, 0);
            Color Green = Color.FromArgb(0, 255, 0);
            TeamGlowColorBtn.BackColor = Green;
            EnemyGlowColorBtn.BackColor = Red;
            EnemyChamBtn.BackColor = Red;
            TeamChamBtn.BackColor = Green;
            EnemyESPColorBtn.BackColor = Red;
            TeamESPColorBtn.BackColor = Green;
            TeamTracerBtn.BackColor = Green;
            EnemyTracerBtn.BackColor = Red;
            TeamLabelBtn.BackColor = Green;
            EnemyLabelBtn.BackColor = Red;
            CrosshairBtn.BackColor = Color.Magenta;
            FovCircleBtn.BackColor = Color.Blue;

            while (true)
            {
                flatLabel45.Text = "FOV Max Pixel Distance: " + Tools.MaxFOV;
                #region Colors

                S.GlowTeamColor = TeamGlowColorBtn.BackColor;
                S.GlowEnemyColor = EnemyGlowColorBtn.BackColor;
                S.ChamTeamColor = TeamChamBtn.BackColor;
                S.ChamEnemyColor = EnemyChamBtn.BackColor;
                S.ESPEnemyColor = EnemyESPColorBtn.BackColor;
                S.ESPTeamColor = TeamESPColorBtn.BackColor;
                S.TracerEnemyColor = EnemyTracerBtn.BackColor;
                S.TracerTeamColor = TeamTracerBtn.BackColor;
                S.LabelEnemyColor = EnemyLabelBtn.BackColor;
                S.LabelTeamColor = TeamLabelBtn.BackColor;
                S.CrosshairColor = CrosshairBtn.BackColor;
                S.FOVCircleColor = FovCircleBtn.BackColor;
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
                S.ChamTeam = ChamTeam.Checked;
                S.ChamHealth = ChamHealth.Checked;
                S.OnlyNotMoving = OnlyNotMoving.Checked;
                S.OnlyScoped = OnlyScoped.Checked;
                S.Firerate = (int)Firerate.Value;
                S.ShotDelay = (int)delay.Value;
                S.OverlayEnabled = flatToggle1.Checked;
                S.BoxESP = BoxESPCheck.Checked;
                S.VisualsEnabled = OtherVisualsCheck.Checked;
                S.ESPTeam = ESPTeam.Checked;
                S.Tracers = Tracers.Checked;
                S.TracersTeam = TracersTeam.Checked;
                S.Labels = Labels.Checked;
                S.TeamLabels = TeamLabels.Checked;
                S.Aimbot = Aimbot.Checked;
                S.ShowFOV = ShowFOVCrosshair.Checked;
                S.FOVBar = flatTrackBar1.Value;
                Tools.MaxFOV = flatTrackBar1.Value;
                S.ShowCrosshair = recoilcircle.Checked;

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

        private void EnemyESPColorBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                EnemyESPColorBtn.BackColor = colorDialog1.Color;
            }
        }

        private void TeamESPColorBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                TeamESPColorBtn.BackColor = colorDialog1.Color;
            }
        }

        private void TeamTracerBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                TeamTracerBtn.BackColor = colorDialog1.Color;
            }
        }

        private void EnemyTracerBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                EnemyTracerBtn.BackColor = colorDialog1.Color;
            }
        }

        private void TeamLabelBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                TeamLabelBtn.BackColor = colorDialog1.Color;
            }
        }

        private void EnemyLabelBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                EnemyLabelBtn.BackColor = colorDialog1.Color;
            }
        }

        private void CrosshairBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                CrosshairBtn.BackColor = colorDialog1.Color;
            }
        }

        private void FovCircleBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                FovCircleBtn.BackColor = colorDialog1.Color;
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
            TeamGlowColorBtn.BackColor = s.GlowTeamColor;
            EnemyGlowColorBtn.BackColor = s.GlowEnemyColor;
            TeamChamBtn.BackColor = s.ChamTeamColor;
            EnemyChamBtn.BackColor = s.ChamEnemyColor;
            MiscToggle.Checked = s.MiscEnabled;
            ChamHealth.Checked = s.ChamHealth;
            ChamTeam.Checked = s.ChamTeam;
            OnlyScoped.Checked = s.OnlyScoped;
            OnlyNotMoving.Checked = s.OnlyNotMoving;
            RadarhackToggle.Checked = s.RadarEnabled;
            Firerate.Value = s.Firerate;
            delay.Value = s.ShotDelay;
            flatToggle1.Checked = s.OverlayEnabled;
            OtherVisualsCheck.Checked = s.VisualsEnabled;
            BoxESPCheck.Checked = s.BoxESP;
            ESPTeam.Checked = s.ESPTeam;
            Tracers.Checked = s.Tracers;
            TracersTeam.Checked = s.TracersTeam;
            Labels.Checked = s.Labels;
            TeamLabels.Checked = s.TeamLabels;
            EnemyESPColorBtn.BackColor = s.ESPEnemyColor;
            TeamESPColorBtn.BackColor = s.ESPTeamColor;
            EnemyLabelBtn.BackColor = s.LabelEnemyColor;
            TeamLabelBtn.BackColor = s.LabelTeamColor;
            EnemyTracerBtn.BackColor = s.TracerEnemyColor;
            TeamTracerBtn.BackColor = s.TracerTeamColor;
            CrosshairBtn.BackColor = s.CrosshairColor;
            FovCircleBtn.BackColor = s.FOVCircleColor;
            Aimbot.Checked = s.Aimbot;
            flatTrackBar1.Value = s.FOVBar;
            ShowFOVCrosshair.Checked = s.ShowFOV;
            recoilcircle.Checked = s.ShowCrosshair;

            if (s.OverlayEnabled)
                overlay.Show();
            else
                overlay.Hide();

        }

        private void flatToggle1_CheckedChanged(object sender)
        {
            if (flatToggle1.Checked)
                overlay.Show();
            else
                overlay.Hide();
        }


    }
}
