using ProcessorEmulator.Arguments.Base;
using ProcessorEmulator.Commands.Base;
using ProcessorEmulator.HardwareEmulation;

namespace ProcessorEmulator.Commands.LowLevelCommands;

class PopCommand : ICommand
{
    private readonly IDestination _dest;

    private PopCommand(IDestination dest)
    {
        _dest = dest;
    }

    public ICommand Dump()
    {
        Console.Write($"pop {_dest.GetName()}");

        return this;
    }

    public ICommand Execute(ref int i)
    {
        Stack.Instance.Pop(out int value);
        _dest.SetValue(value);

        i++;

        return this;
    }

    public static ICommand Create(params IArgument[] args)
    {
        if (args.Length != 1)
            throw new ArgumentException();
        if (args[0] is IDestination dest )
            return new PopCommand(dest);
        else
            throw new NotImplementedException();
    }
}
