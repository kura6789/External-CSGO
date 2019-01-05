using Binjector.Utilities;
using hazedumper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Binjector.Classes
{
    public class Entity
    {
        int EntityBase;

        public Entity(int Base)
        {
            this.EntityBase = Base;
        }

        public int Health
        {
            get
            {
                return Memory.ReadMemory<int>(EntityBase + netvars.m_iHealth);
            }
        }

        public int GlowIndex
        {
            get
            {
                return Memory.ReadMemory<int>(EntityBase + netvars.m_iGlowIndex);
            }
        }

        public int Team
        {
            get
            {
                return Memory.ReadMemory<int>(EntityBase + netvars.m_iTeamNum);
            }
        }

        public int Flags
        {
            get
            {
                return Memory.ReadMemory<int>(EntityBase + netvars.m_fFlags);
            }
        }

        public bool IsTeammate
        {
            get
            {
                return Team == Globals.LocalPlayer.Team;
            }
        }

        public Vector3 Position
        {
            get
            {
                return Memory.ReadMemory<Vector3>(EntityBase + netvars.m_vecOrigin);
            }
        }

        public bool Spotted
        {
            get
            {
                return Memory.ReadMemory<bool>(EntityBase + netvars.m_bSpotted);
            }
            set
            {
                Memory.WriteMemory<bool>(EntityBase + netvars.m_bSpotted, Convert.ToByte(value));
            }
        }

        public int FlashDuration
        {
            get
            {
                return Memory.ReadMemory<int>(EntityBase + netvars.m_flFlashDuration);
            }
            set
            {
                Memory.WriteMemory<int>(EntityBase + netvars.m_flFlashDuration, value);
            }
        }

        public bool Dormant
        {
            get
            {
                return Memory.ReadMemory<bool>(EntityBase + signatures.m_bDormant);
            }
        }

        public int CrosshairID
        {
            get
            {
                return Memory.ReadMemory<int>(EntityBase + netvars.m_iCrosshairId);
            }
        }

        public void Glow(float r, float g, float b)
        {
            GlowStruct GlowObj = new GlowStruct();

            GlowObj = Memory.ReadMemory<GlowStruct>(Globals.GlowObjectManager + GlowIndex * 0x38);

            GlowObj.r = r / 255;
            GlowObj.g = g / 255;
            GlowObj.b = b / 255;
            GlowObj.a = 255 / 255;
            GlowObj.m_bRenderWhenOccluded = true;
            GlowObj.m_bRenderWhenUnoccluded = false;

            Memory.WriteMemory<GlowStruct>(Globals.GlowObjectManager + GlowIndex * 0x38, GlowObj);
        }

        public bool Alive
        {
            get
            {
                if (Health > 0)
                    return true;
                return false;
            }
        }

        public bool Dead
        {
            get
            {
                if (!(Health > 0))
                    return true;
                return false;
            }
        }

        public bool Valid
        {
            get
            {
                if (Dormant)
                    return false;
                if (Dead)
                    return false;
                if (Team == 0 || Team == 1)
                    return false;

                return true;
            }
        }
    }
}
