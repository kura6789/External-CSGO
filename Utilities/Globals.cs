using Binjector.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Binjector.Utilities
{
    public class Globals
    {
        public static Entity LocalPlayer;
        public static int GlowObjectManager;
        public static int ClientState;
        public static float[] ViewMatrix = new float[16];
        public static Vector3 ViewAngles;
        public static List<Entity> EntityList = new List<Entity>();
    }
}
