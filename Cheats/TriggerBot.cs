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
                if (Main.S.TriggerbotEnabled)
                {
                    bool canshoot = true;
                    Console.WriteLine(Globals.LocalPlayer.CrosshairID);
                    if (Globals.LocalPlayer.CrosshairID != 0 && Globals.LocalPlayer.CrosshairID < 64)
                    {
                        Entity Player = new Entity(Tools.GetEntityBaseFromCrosshair(Globals.LocalPlayer.CrosshairID));
                        if (Player.Valid && Player.IsTeammate == false)
                        {
                            if (Main.S.OnlyScoped && !Globals.LocalPlayer.Scoped)
                                canshoot = false;
                            if (Main.S.OnlyNotMoving && !Globals.LocalPlayer.IsStill)
                                canshoot = false;

                            if (canshoot)
                            {
                                Thread.Sleep(Main.S.ShotDelay);
                                Tools.Shoot();
                                Thread.Sleep(Main.S.Firerate);
                            }
                        }
                    }
                }
                Thread.Sleep(1);
            }
        }
    }
}
