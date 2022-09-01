using ProcessorEmulator.Arguments.Base;
using ProcessorEmulator.HardwareEmulation;

namespace ProcessorEmulator.Arguments
{
    class adr : IObject
    {
        private adr(IValue val)
        {
            _val = val;
        }

        private readonly IValue _val;

        public string GetName()
        {
            var format = _val is con ?
                "ptr [{0}h]" :
                "[{0}]";
            return string.Format(format, _val.GetName());
        }

        public int GetValue()
        {
            int address = _val.GetValue();
            MemoryHeap.Instance.Read(address, out int value);
            return value;
        }

        public void SetValue(int val)
        {
            int address = _val.GetValue();
            MemoryHeap.Instance.Write(address, val);
        }

        public static adr s(IValue val)
        {
            return new adr(val);
        }
    }
}
