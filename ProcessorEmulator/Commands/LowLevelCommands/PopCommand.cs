using ProcessorEmulator.Arguments.Base;
using ProcessorEmulator.Commands.Base;
using ProcessorEmulator.HardwareEmulation;

namespace ProcessorEmulator.Commands.LowLevelCommands;

class pop : ICommand
{
    private readonly IDestination _dest;

    private pop(IDestination dest)
    {
        _dest = dest;
    }

    public ICommand d()
    {
        Console.Write($"pop {_dest.GetName()}");

        return this;
    }

    public ICommand e(ref int i)
    {
        Stack.Instance.Pop(out int value);
        _dest.SetValue(value);

        i++;

        return this;
    }

    public static ICommand i(params IArgument[] args)
    {
        if (args.Length != 1)
            throw new ArgumentException();
        if (args[0] is IDestination dest )
            return new pop(dest);
        else
            throw new NotImplementedException();
    }
}
