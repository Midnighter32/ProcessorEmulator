using ProcessorEmulator.Arguments.Base;
using ProcessorEmulator.Commands.Base;
using ProcessorEmulator.HardwareEmulation;

namespace ProcessorEmulator.Commands.LowLevelCommands;

class push : ICommand
{
    private readonly IValue _value;

    private push(IValue left)
    {
        _value = left;
    }

    public ICommand d()
    {
        Console.Write($"push {_value.GetName()}");

        return this;
    }

    public ICommand e(ref int i)
    {
        var value = _value.GetValue();
        Stack.Instance.Push(value);

        i++;

        return this;
    }

    public static ICommand i(params IArgument[] args)
    {
        if (args.Length != 1)
            throw new ArgumentException();
        if (args[0] is IValue val )
            return new push(val);
        else
            throw new NotImplementedException();
    }
}
