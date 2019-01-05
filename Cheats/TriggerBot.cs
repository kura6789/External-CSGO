using Binjector.Classes;
using Binjector.Utilities;
using System;
using System.Threading;

namespace Binjector.Cheats
{
    class Triggerbot
    {
        public static void Start()
        {
            while (true)
            {
                if (Main.TriggerbotEnabled)
                {
                    Console.WriteLine(Globals.LocalPlayer.CrosshairID);
                    if (Globals.LocalPlayer.CrosshairID != 0 && Globals.LocalPlayer.CrosshairID < 64)
                    {
                        Entity Player = new Entity(Tools.GetEntityBaseFromCrosshair(Globals.LocalPlayer.CrosshairID));
                        if (Player.Valid && Player.IsTeammate == false)
                        {
                            Console.WriteLine("Shoot");
                            Tools.Shoot();
                        }
                    }
                }
                Thread.Sleep(1);
            }
        }
    }
}
