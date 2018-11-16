using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameCubeHIDInterface;
using HidLibrary;

namespace GameCubeHIDInterface
{
    class Program
    {

        static void Main(string[] args)
        {
            GameCubeController controller1 = new GameCubeController(1);
            GameCubeController controller2 = new GameCubeController(2);
            controller1.Rumble(1);
            System.Threading.Thread.Sleep(5000);
            controller1.Rumble(0);
            controller2.Rumble(1);
            System.Threading.Thread.Sleep(5000);
            controller2.Rumble(0);
        }

    }
}
