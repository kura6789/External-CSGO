using Binjector.Classes;
using hazedumper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Binjector.Utilities
{
    public class Tools
    {
        public static void InitializeGlobals()
        {
            Globals.LocalPlayer = new Entity(Memory.ReadMemory<int>((int)Memory.g_pClient + signatures.dwLocalPlayer));
            Globals.GlowObjectManager = Memory.ReadMemory<int>((int)Memory.g_pClient + signatures.dwGlowObjectManager);

            // Get Players
            var oldEntityList = new List<Entity>();

            oldEntityList.Clear();
            for (int i = 1; i <= 64; i++)
            {
                oldEntityList.Add(new Entity(GetEntityBase(i)));
            }
            Globals.EntityList = oldEntityList;
            Thread.Sleep(100);
        }

        public static int GetEntityBase(int PlayerLoopID)
        {
            return Memory.ReadMemory<int>((int)Memory.g_pClient + signatures.dwEntityList + (PlayerLoopID * 0x10));
        }

        public static int GetEntityBaseFromCrosshair(int CrosshairID)
        {
            return Memory.ReadMemory<int>((int)Memory.g_pClient + signatures.dwEntityList + (CrosshairID - 1) * 0x10);
        }

        public static void Shoot(int firerate = 20)
        {
            Memory.WriteMemory<int>((int)Memory.g_pClient + signatures.dwForceAttack, 5);
            Thread.Sleep(firerate);
            Memory.WriteMemory<int>((int)Memory.g_pClient + signatures.dwForceAttack, 4);
        }

        public static void Jump()
        {
            Memory.WriteMemory<int>((int)Memory.g_pClient + signatures.dwForceJump, 6);
        }
    }
}
