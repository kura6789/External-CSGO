using Binjector.Classes;
using Binjector.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Binjector.Cheats
{
    class Misc
    {
        public static void Start()
        {
            while (true)
            {
                if (Main.S.NoflashEnabled && Globals.LocalPlayer.FlashDuration > 0)
                {
                    Globals.LocalPlayer.FlashDuration = 0;
                }

                

                foreach (Entity Player in Globals.EntityList)
                {
                    if (Main.S.RadarEnabled)
                    {
                        if (!Player.Spotted)
                            Player.Spotted = true;
                    }
                    if (!Main.S.ChamsEnabled)
                        Player.ResetChams();
                    else if (!Main.S.ChamTeam && Player.IsTeammate)
                        Player.ResetChams();

                }
                Thread.Sleep(1);
            }
        }
    }
}
