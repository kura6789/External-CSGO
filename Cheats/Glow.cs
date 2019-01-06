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
            while (true)
            {
                if (Main.GlowEnabled)
                {
                    foreach(Entity Player in Globals.EntityList)
                    {
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
