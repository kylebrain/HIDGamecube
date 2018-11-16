using System;
using System.Linq;
using HidLibrary;

namespace GameCubeHIDInterface
{
    public class GameCubeController
    {
        private const int VendorId = 0x0079;
        private const int ProductId = 0x1844;

        public uint ID
        {
            get
            {
                return controllerID;
            }
        }

        private HidDevice device;
        private uint controllerID;

        public GameCubeController(uint id)
        {
            HidDevice[] devices = HidDevices.Enumerate(VendorId, ProductId).ToArray();
            if(id > devices.Length || id == 0)
            {
                throw new System.ArgumentOutOfRangeException("Id is invalid!");
            }
            device = devices[id - 1];
            if(device == null)
            {
                throw new System.Exception("Controller at this id is null!");
            }
            controllerID = id;

        }

        public void Rumble(float rumbleAmount)
        {
            if (rumbleAmount < 0 || rumbleAmount > 1)
            {
                throw new System.ArgumentOutOfRangeException("Amount must be between 0 and 1!");
            }

            int max = 0xF0;
            int min = 0x60;

            byte value;

            if (rumbleAmount == 0)
            {
                value = 0;
            }
            else
            {
                value = (byte)((max - min) * rumbleAmount + min);
            }

            device.Write(new byte[2] {
                0x00, value
            });
        }


    }
}
