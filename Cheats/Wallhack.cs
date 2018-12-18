using Binjector_CSGO_V2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Binjector_CSGO_V2.Cheats
{
    class Wallhack
    {
        [StructLayout(LayoutKind.Explicit)]
        public struct GlowStruct
        {
            [FieldOffset(0x00)]
            public int EntityPointer;
            [FieldOffset(0x4)]
            public float r;
            [FieldOffset(0x8)]
            public float g;
            [FieldOffset(0xC)]
            public float b;
            [FieldOffset(0x10)]
            public float a;
            [FieldOffset(0x14)]
            public int jnk1;
            [FieldOffset(0x18)]
            public int jnk2;
            [FieldOffset(0x1C)]
            public float BloomAmount;
            [FieldOffset(0x20)]
            public int jnk3;

            [FieldOffset(0x24)]
            public bool m_bRenderWhenOccluded;
            [FieldOffset(0x25)]
            public bool m_bRenderWhenUnoccluded;
            [FieldOffset(0x2C)]
            public bool m_bFullBloom;
        };

        public static void Start()
        {
            for (int i = 0; i < 64; i++)
            {
                GlowStruct GlowObj = new GlowStruct();
                int Entity = Tools.GetEntityBase(i);
                int GlowIndex = Tools.GetGlowIndex(Entity);
                int EnemyTeam = Tools.GetTeam(Entity);
                if (EnemyTeam != Vars.MyTeam)
                {
                    bool IsSpotted = Memory.ReadMemory<bool>(Entity + Offsets.m_bSpotted);
                    if (!IsSpotted)
                    {
                        Memory.WriteMemory<bool>(Entity + Offsets.m_bSpotted, 1);
                    }

                    GlowObj = Memory.ReadMemory<GlowStruct>(Vars.GlowObjectManager + GlowIndex * 0x38);

                    GlowObj.r = 255 / 255;
                    GlowObj.g = 0 / 255;
                    GlowObj.b = 0 / 255;
                    GlowObj.a = 255 / 255;
                    GlowObj.m_bRenderWhenOccluded = true;
                    GlowObj.m_bRenderWhenUnoccluded = false;
                    GlowObj.m_bFullBloom = false;

                    Memory.WriteMemory<GlowStruct>(Vars.GlowObjectManager + GlowIndex * 0x38, GlowObj);
                }
                else
                {
                    GlowObj = Memory.ReadMemory<GlowStruct>(Vars.GlowObjectManager + GlowIndex * 0x38);

                    GlowObj.r = 0 / 255;
                    GlowObj.g = 255 / 255;
                    GlowObj.b = 0 / 255;
                    GlowObj.a = 255 / 255;
                    GlowObj.m_bRenderWhenOccluded = true;
                    GlowObj.m_bRenderWhenUnoccluded = false;
                    GlowObj.m_bFullBloom = false;

                    Memory.WriteMemory<GlowStruct>(Vars.GlowObjectManager + GlowIndex * 0x38, GlowObj);
                }
            }
        }
    }
}
