using ProcessorEmulator.Arguments.Base;
using ProcessorEmulator.Commands.Base;

namespace ProcessorEmulator.LowLevelCommands;

class MovCommand : ICommand
{
    private readonly IValue _value;
    private readonly IDestination _destination;

    private MovCommand(IDestination left, IValue right)
    {
        _value = right;
        _destination = left;
    }

    public ICommand Dump()
    {
        Console.Write($"mov {_destination.GetName()}, {_value.GetName()}");

        return this;
    }

    public ICommand Execute(ref int i)
    {
        var value = _value.GetValue();
        _destination.SetValue(value);

        i++;

        return this;
    }

    public static ICommand Create(params IArgument[] args)
    {
        if (args.Length != 2)
            throw new ArgumentException();
        if (args[0] is IDestination dest && args[1] is IValue val)
            return new MovCommand(dest, val);
        else
            throw new NotImplementedException();
    }
}
