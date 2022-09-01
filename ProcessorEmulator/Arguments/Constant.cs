using ProcessorEmulator.Arguments.Base;

namespace ProcessorEmulator.Arguments;

class con : IValue
{
    private con(int value)
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

    public static con s(int val)
    {
        return new con(val);
    }
}
