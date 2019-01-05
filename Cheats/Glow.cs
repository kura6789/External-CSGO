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
                                Player.Glow(0, 255, 0);
                            }
                            else
                            {
                                if (!Player.Spotted)
                                    Player.Spotted = true;

                                Player.Glow(255, 0, 0);
                            }
                        }
                    }
                }
                Thread.Sleep(1);
            }
        }
    }
}
