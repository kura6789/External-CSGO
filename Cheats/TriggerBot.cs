using Binjector_CSGO_V2.Utilities;
using System;
using System.Threading;

namespace Binjector_CSGO_V2.Cheats
{
    class TriggerBot
    {
        public static void Start()
        {
            int Crosshair = Tools.GetCrosshair();
            Console.WriteLine(Crosshair);
            if (Crosshair != 0 && Crosshair < 64)
            {
                int Entity = Tools.GetEntityBaseFromCrosshair(Crosshair);
                int EnemyTeam = Tools.GetTeam(Entity);
                int EnemyHealth = Tools.GetHealth(Entity);
                if (EnemyTeam != Vars.MyTeam && EnemyHealth > 0)
                {
                    Console.WriteLine("Shoot");
                    Tools.Shoot();
                }
            }
        }
    }
}
