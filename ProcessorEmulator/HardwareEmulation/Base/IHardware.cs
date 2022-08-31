namespace ProcessorEmulator.HardwareEmulation.Base
{
    interface IHardware
    {
        public void Read(int ind, out int value);

        public void Write(int ind, int value);

        public void Dump();
    }
}
