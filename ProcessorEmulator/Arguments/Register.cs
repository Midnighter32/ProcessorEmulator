using ProcessorEmulator.Arguments.Base;
using ProcessorEmulator.HardwareEmulation;

namespace ProcessorEmulator.Arguments;

class reg : IObject
{
    private reg(RegDef ID)
    {
        _id = ID;
    }

    private readonly RegDef _id;

    public string GetName()
    {
        return _id.ToString().ToLower();
    }

    public void SetValue(int val)
    {
        Registers.Instance.Write((int)_id, val);
    }

    public int GetValue()
    {
        Registers.Instance.Read((int)_id, out var value);
        return value;
    }

    public static reg s(RegDef reg)
    {
        return new reg(reg);
    }
}
