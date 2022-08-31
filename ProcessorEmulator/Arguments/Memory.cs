using ProcessorEmulator.Arguments.Base;
using ProcessorEmulator.HardwareEmulation;

namespace ProcessorEmulator.Arguments;

class Memory : IObject
{
    private Memory(int Address)
    {
        _address = Address;
    }

    private int _address;

    public string GetName()
    {
        return $"ptr [{_address}h]";
    }

    public int GetValue()
    {
        MemoryHeap.Instance.Read(_address, out int value);
        return value;
    }

    public void SetValue(int value)
    {
        MemoryHeap.Instance.Write(_address, value);
    }

    public static Memory Set(int Address)
    {
        return new Memory(Address);
    }
}
