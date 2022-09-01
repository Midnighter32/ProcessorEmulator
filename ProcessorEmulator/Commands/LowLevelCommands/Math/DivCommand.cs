using ProcessorEmulator.Arguments;
using ProcessorEmulator.Arguments.Base;
using ProcessorEmulator.Commands.Base;

namespace ProcessorEmulator.Commands.LowLevelCommands
{
    class div : ICommand
    {
        private readonly IValue _source;

        private div(IValue src)
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
            reg rax = reg.s(RegDef.rax);
            reg rdx = reg.s(RegDef.rdx);

            var value = Math.DivRem(rax.GetValue(), _source.GetValue(), out var reminder);

            rax.SetValue(value);
            rdx.SetValue(reminder);

            i++;

            return this;
        }

        public static ICommand i(params IArgument[] args)
        {
            if (args.Length != 1)
                throw new ArgumentException();
            if (args[0] is IValue src)
                return new div(src);
            else
                throw new NotImplementedException();
        }
    }
}
