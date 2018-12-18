using Binjector_CSGO_V2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Binjector_CSGO_V2
{
    public class Tools
    {
        public static bool IsOnTeam(int EntityBase)
        {
            int entityteam = Memory.ReadMemory<int>(EntityBase + Offsets.m_iTeamNum);

            if (entityteam == Vars.MyTeam)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int GetEntityBase(int PlayerLoopID)
        {
            return Memory.ReadMemory<int>((int)Memory.g_pClient + Offsets.dwEntityList + (PlayerLoopID * 0x10));
        }

        public static int GetEntityBaseFromCrosshair(int CrosshairID)
        {
            return Memory.ReadMemory<int>((int)Memory.g_pClient + Offsets.dwEntityList + (CrosshairID - 1) * 0x10);
        }

        public static int GetHealth(int EntityBase)
        {
            return Memory.ReadMemory<int>(EntityBase + Offsets.m_iHealth);
        }

        public static int GetGlowIndex(int EntityBase)
        {
            return Memory.ReadMemory<int>(EntityBase + Offsets.m_iGlowIndex);
        }

        public static int GetTeam(int EntityBase)
        {
            return Memory.ReadMemory<int>(EntityBase + Offsets.m_iTeamNum);
        }

        public static int GetCrosshair()
        {
            return Memory.ReadMemory<int>(Vars.LocalPlayer + Offsets.m_iCrosshairId);
        }

        public static void Shoot(int firerate = 20)
        {
            Memory.WriteMemory<int>((int)Memory.g_pClient + Offsets.dwForceAttack, 5);
            Thread.Sleep(firerate);
            Memory.WriteMemory<int>((int)Memory.g_pClient + Offsets.dwForceAttack, 4);
        }

        public static void Jump()
        {
            Memory.WriteMemory<int>((int)Memory.g_pClient + Offsets.dwForceJump, 6);
        }

        public static int GetFlags()
        {
            return Memory.ReadMemory<int>(Vars.LocalPlayer + Offsets.m_fFlags);
        }
    }
}
