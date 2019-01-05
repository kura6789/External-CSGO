using Binjector.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Binjector.Cheats
{
    class Bunnyhop
    {
        public static void Start()
        {
            while (true)
            {
                if (Main.BunnyhopEnabled)
                {
                    if ((Memory.GetAsyncKeyState(Keys.VK_SPACE) & 0x8000) > 0)
                    {
                        Console.WriteLine("Holding Key");
                        Console.WriteLine(Globals.LocalPlayer.Flags);
                        //Standing         //Crouching
                        if (Globals.LocalPlayer.Flags == 257 || Globals.LocalPlayer.Flags == 263)
                        {
                            Console.WriteLine("Jumping");

                            Tools.Jump();
                        }
                    }
                    Thread.Sleep(1);
                }
            }
        }
    }
}
