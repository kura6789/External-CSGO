using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using hazedumper;
using Binjector.Utilities;
using System.Threading;
using Binjector.Classes;
using System.Drawing;

namespace Binjector.Cheats
{
    class Glow
    {
        public static void Start()
        {
            Globals.GlowObjectManager = Memory.ReadMemory<int>((int)Memory.g_pClient + signatures.dwGlowObjectManager);
            while (true)
            {
                if (Main.GlowEnabled)
                {
                    for (int i = 0; i < 64; i++)
                    {
                        Entity Player = new Entity(Tools.GetEntityBase(i));
                        if (Player.Valid)
                        {
                            if (Player.IsTeammate)
                            {
                                Player.Glow(Main.TeamColor.R, Main.TeamColor.G, Main.TeamColor.B);
                            }
                            else
                            {
                                if (!Player.Spotted)
                                    Player.Spotted = true;

                                Player.Glow(Main.EnemyColor.R, Main.EnemyColor.G, Main.EnemyColor.B);
                            }
                        }
                    }
                }
                Thread.Sleep(1);
            }
        }
    }
}
