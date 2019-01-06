using Binjector.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Binjector.Cheats
{
    class Misc
    {
        public static void Start()
        {
            while (true)
            {
                if (Main.NoflashEnabled && Globals.LocalPlayer.FlashDuration > 0)
                {
                    Globals.LocalPlayer.FlashDuration = 0;
                }
                Thread.Sleep(1);
            }
        }
    }
}
