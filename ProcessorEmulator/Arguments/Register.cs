using ProcessorEmulator.Arguments.Base;
using ProcessorEmulator.HardwareEmulation;

namespace ProcessorEmulator.Arguments;

class Register : IObject
{
    private Register(REG ID, bool isAddress = false)
    {
        _id = ID;
        _isAddress = isAddress;
    }

    private readonly bool _isAddress;
    private readonly REG _id;

    public string GetName()
    {
        return string.Format(_isAddress ? "[{0}]" : "{0}", _id.ToString().ToLower());
    }

    public void SetValue(int val)
    {
        Registers.Instance.Write((int)_id, val);
    }

    public int GetValue()
    {
        Registers.Instance.Read((int)_id, out var value);
        if (_isAddress)
            MemoryHeap.Instance.Read(value, out value);
        return value;
    }

    public static Register Set(REG reg)
    {
        return new Register(reg);
    }

    public static Register Address(REG reg)
    {
        return new Register(reg, true);
    }
}
