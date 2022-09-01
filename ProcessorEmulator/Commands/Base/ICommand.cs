using ProcessorEmulator.Arguments.Base;

namespace ProcessorEmulator.Commands.Base;

interface ICommand
{
    ICommand Execute(ref int i);

    ICommand Dump();

    static abstract ICommand i(params IArgument[] args);
}
