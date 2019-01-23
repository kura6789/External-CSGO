using Binjector.Classes;
using Binjector.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binjector.Forms
{
    public partial class Overlay : Form
    {
        StringFormat format = new StringFormat();
        Graphics g; // youre gonna use this to draw stuff if youre using the built in graphics library 
        public Overlay()
        {
            InitializeComponent();
        }

        private void Overlay_Load(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(1, 1, 1);
            TransparencyKey = Color.FromArgb(1, 1, 1);
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;

            // for some reason, while loops dont work for drawing stuff, so we use a timer
            RefreshTimer.Enabled = true;
            RefreshTimer.Interval = 1; // 1 ms

            // make sure the overlay is the same size of the csgo window
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                CheckSize();
            }).Start();
        }

        public void CheckSize()
        {
            while (true)
            {
                Memory.SetWindowLong(Handle, -20, Memory.GetWindowLong(Handle, -20) | 0x80000 | 0x20); // makes it so you can click through it
                Size = Main.ScreenSize;
                Top = Main.ScreenRect.top;
                Left = Main.ScreenRect.left;

                if (Tools.HoldingKey(Keys.VK_E) && Main.S.Aimbot)
                {
                    Entity aimplayer = Tools.GetFovPlayer();
                    if (aimplayer != null)
                    {
                        Vector2 headpos = Tools.WorldToScreen(aimplayer.HeadPosition);

                        Tools.MoveCursor(headpos);
                    }
                }

                Thread.Sleep(1); // how often it checks to make it the same size as the csgo window, change it to what you'd like
            }
        }

        private void Overlay_Paint(object sender, PaintEventArgs e)
        {
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;
            g = e.Graphics;
            g.DrawString("Binjector CS:GO", new Font("Arial", 16), new SolidBrush(Color.FromArgb(35, 168, 109)), 10, 10);



            if (Main.S.OverlayEnabled)
            {
                if (Main.S.ShowCrosshair)
                {
                    float x = Main.MidScreen.X;
                    float y = Main.MidScreen.Y;
                    float dy = Main.ScreenSize.Width / 145; // y value of aimpunch, this looks near perfect
                    float dx = Main.ScreenSize.Height / 90;
                    x -= (dx * (Globals.LocalPlayer.AimPunch.Y));
                    y += (dy * (Globals.LocalPlayer.AimPunch.X));

                    g.DrawEllipse(new Pen(Main.S.CrosshairColor), x - 5, y - 5, 10, 10);
                }
                if (Main.S.ShowFOV)
                {
                    g.DrawEllipse(new Pen(Main.S.FOVCircleColor), Main.MidScreen.X - Tools.MaxFOV, Main.MidScreen.Y - Tools.MaxFOV, Tools.MaxFOV * 2, Tools.MaxFOV * 2);
                }
                foreach (Entity Player in Globals.EntityList)
                {
                    if (Player.EntityBase != Globals.LocalPlayer.EntityBase)
                    {
                        Vector2 Player2DPos = Tools.WorldToScreen(Player.Position);
                        Vector2 Player2DHeadPos = Tools.WorldToScreen(Player.HeadPosition);
                        Vector2 Player2DNeckPos = Tools.WorldToScreen(Player.GetBonePosition(7));
                        if (!Tools.IsNullVector2(Player2DPos) && !Tools.IsNullVector2(Player2DHeadPos))
                        {
                            if (Main.S.Labels)
                            {
                                float h = Player2DPos.Y - Player2DHeadPos.Y;
                                float w = h / 2;
                                if (Player.IsTeammate)
                                {
                                    if (Main.S.TeamLabels)
                                    {
                                        GraphicsPath p = new GraphicsPath();
                                        p.AddString(
                                            Player.Health.ToString(),             // text to draw
                                            FontFamily.GenericMonospace,  // or any other font family
                                            (int)FontStyle.Regular,      // font style (bold, italic, etc.)
                                            g.DpiY * 11 / 72,       // em size
                                            new Point((int)Player2DPos.X, (int)Player2DPos.Y + 20),              // location where to draw text
                                            format);

                                        g.DrawPath(new Pen(Tools.HealthGradient(Tools.HealthToPercent(Player.Health))), p);
                                        // g.DrawString(Player.Health.ToString(), new Font("Arial", 11), new SolidBrush(Tools.HealthGradient(Tools.HealthToPercent(Player.Health))), Player2DPos.X, Player2DPos.Y + 20, format);
                                    }
                                }
                                else
                                {
                                    GraphicsPath p = new GraphicsPath();
                                    p.AddString(
                                        Player.Health.ToString(),             // text to draw
                                        FontFamily.GenericMonospace,  // or any other font family
                                        (int)FontStyle.Regular,      // font style (bold, italic, etc.)
                                        g.DpiY * 11 / 72,       // em size
                                        new Point((int)Player2DPos.X, (int)Player2DPos.Y + 20),              // location where to draw text
                                        format);

                                    g.DrawPath(new Pen(Tools.HealthGradient(Tools.HealthToPercent(Player.Health))), p);
                                    //g.DrawString(Player.Health.ToString(), new Font("Arial", 11), new SolidBrush(Tools.HealthGradient(Tools.HealthToPercent(Player.Health))), Player2DPos.X, Player2DPos.Y, format);

                                }

                            }

                            if (Main.S.Tracers)
                            {
                                if (Player.IsTeammate)
                                {
                                    if (Main.S.TracersTeam)
                                    {
                                        g.DrawLine(new Pen(Main.S.TracerTeamColor), Main.MidScreen.X, Main.MidScreen.Y + Main.MidScreen.Y, Player2DPos.X, Player2DPos.Y);
                                    }
                                }
                                else
                                {
                                    g.DrawLine(new Pen(Main.S.TracerEnemyColor), Main.MidScreen.X, Main.MidScreen.Y + Main.MidScreen.Y, Player2DPos.X, Player2DPos.Y);
                                }
                            }

                            if (Main.S.BoxESP)
                            {
                                float FromHeadToNeck = (Player2DNeckPos.Y - Player2DHeadPos.Y);
                                Player2DHeadPos.Y -= FromHeadToNeck * 2.3f;
                                Player2DPos.Y += FromHeadToNeck;
                                float BoxHeight = Player2DPos.Y - Player2DHeadPos.Y; // distance between headheight and feet position
                                float BoxWidth = (BoxHeight / 2) * 1.25f;

                                if (Player.IsTeammate)
                                {
                                    if (Main.S.ESPTeam)
                                    {
                                        g.DrawRectangle(new Pen(Main.S.ESPTeamColor), Player2DPos.X - (BoxWidth / 2), Player2DHeadPos.Y, BoxWidth, BoxHeight); // main box
                                        g.DrawRectangle(new Pen(Color.Black), (Player2DPos.X - (BoxWidth / 2)) + 1, Player2DHeadPos.Y + 1, BoxWidth - 2, BoxHeight - 2); // outline box
                                        g.DrawRectangle(new Pen(Color.Black), (Player2DPos.X - (BoxWidth / 2)) - 1, Player2DHeadPos.Y - 1, BoxWidth + 2, BoxHeight + 2); // outline box
                                    }
                                }
                                else
                                {
                                    g.DrawRectangle(new Pen(Main.S.ESPEnemyColor), Player2DPos.X - (BoxWidth / 2), Player2DHeadPos.Y, BoxWidth, BoxHeight); // main box
                                    g.DrawRectangle(new Pen(Color.Black), (Player2DPos.X - (BoxWidth / 2)) + 1, Player2DHeadPos.Y + 1, BoxWidth - 2, BoxHeight - 2); // outline box
                                    g.DrawRectangle(new Pen(Color.Black), (Player2DPos.X - (BoxWidth / 2)) - 1, Player2DHeadPos.Y - 1, BoxWidth + 2, BoxHeight + 2); // outline box
                                }
                            }
                        }
                    }
                }
            }

        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
