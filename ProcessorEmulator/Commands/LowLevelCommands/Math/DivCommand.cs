using ProcessorEmulator.Arguments;
using ProcessorEmulator.Arguments.Base;
using ProcessorEmulator.Commands.Base;

namespace ProcessorEmulator.Commands.LowLevelCommands
{
    class DivCommand : ICommand
    {
        private readonly IValue _source;

        private DivCommand(IValue src)
        {
            _source = src;
        }

        public ICommand Dump()
        {
            Console.Write($"div {_source.GetName()}");

            return this;
        }

        public ICommand Execute(ref int i)
        {
            Register rax = Register.Set(REG.RAX);
            Register rdx = Register.Set(REG.RDX);

            var value = Math.DivRem(rax.GetValue(), _source.GetValue(), out var reminder);

            rax.SetValue(value);
            rdx.SetValue(reminder);

            i++;

            return this;
        }

        public static ICommand Create(params IArgument[] args)
        {
            if (args.Length != 1)
                throw new ArgumentException();
            if (args[0] is IValue src)
                return new DivCommand(src);
            else
                throw new NotImplementedException();
        }
    }
}
