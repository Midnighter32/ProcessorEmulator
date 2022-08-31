using ProcessorEmulator.Arguments.Base;

namespace ProcessorEmulator.Arguments;

class Constant : IValue
{
    private Constant(int value)
    {
        _val = value;
    }

    private int _val;

    public string GetName()
    {
        return _val.ToString();
    }

    public int GetValue()
    {
        return _val;
    }

    public static Constant Set(int val)
    {
        return new Constant(val);
    }
}
