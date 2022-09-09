using ProcessorEmulator.Arguments.Base;
using ProcessorEmulator.HardwareEmulation.Base;

namespace ProcessorEmulator.HardwareEmulation
{
    internal class Registers : IHardware
    {
        private Registers()
        {
        }

        private readonly int[] reg = new int[8];

        public void Read(int ind, out int value) => value = reg[ind];

        public void Write(int ind, int value) => reg[ind] = value;

        public void Dump()
        {
            for (int i = 0; i < reg.Length; i++)
            {
                Console.WriteLine($"{((RegDef)i)}={reg[i]} ");
            }
        }

        public static Registers Instance = new Registers();
    }
}
