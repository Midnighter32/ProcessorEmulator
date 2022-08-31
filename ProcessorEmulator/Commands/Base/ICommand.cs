using ProcessorEmulator.Arguments.Base;

namespace ProcessorEmulator.Commands.Base;

interface ICommand
{
    ICommand Execute();

    ICommand Dump();

    static abstract ICommand Create(params IArgument[] args);
}
