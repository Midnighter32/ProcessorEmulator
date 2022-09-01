using ProcessorEmulator.Arguments.Base;
using ProcessorEmulator.Commands.Base;
using ProcessorEmulator.HardwareEmulation;

namespace ProcessorEmulator.Commands.LowLevelCommands;

class PushCommand : ICommand
{
    private readonly IValue _value;

    private PushCommand(IValue left)
    {
        _value = left;
    }

    public ICommand Dump()
    {
        Console.Write($"push {_value.GetName()}");

        return this;
    }

    public ICommand Execute(ref int i)
    {
        var value = _value.GetValue();
        Stack.Instance.Push(value);

        i++;

        return this;
    }

    public static ICommand Create(params IArgument[] args)
    {
        if (args.Length != 1)
            throw new ArgumentException();
        if (args[0] is IValue val )
            return new PushCommand(val);
        else
            throw new NotImplementedException();
    }
}
