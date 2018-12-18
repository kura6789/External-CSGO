using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binjector_CSGO_V2.Utilities;

namespace Binjector_CSGO_V2.Cheats
{
    class Bunnyhop
    {
        public static void Start()
        {
            Vars.Flag = Tools.GetFlags();

            if ((Memory.GetAsyncKeyState(0x20) & 0x8000) > 0)
            {
            Console.WriteLine("Holding Key");
            Console.WriteLine(Vars.Flag);

                if (Vars.Flag == 257)
                {
                    Console.WriteLine("Jumping");

                    Tools.Jump();
                }
            }
        }
    }
}
