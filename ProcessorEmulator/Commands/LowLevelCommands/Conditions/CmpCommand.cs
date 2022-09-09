using ProcessorEmulator.Arguments.Base;
using ProcessorEmulator.Commands.Base;

namespace ProcessorEmulator.Commands.LowLevelCommands
{
    class cmp : ICommand
    {
        private readonly IValue _value;
        private readonly IObject _destination;

        private cmp(IObject left, IValue right)
        {
            _value = right;
            _destination = left;
        }

        public ICommand d()
        {
            Console.Write($"cmp {_destination.GetName()}, {_value.GetName()}");

            return this;
        }

        public ICommand e(ref int i)
        {
            int val1 = _destination.GetValue();
            int val2 = _value.GetValue();

            _ = val1 - val2;

            throw new NotImplementedException();
        }

        public static ICommand i(params IArgument[] args)
        {
            if (args.Length != 2)
                throw new ArgumentException();
            if (args[0] is IObject dest && args[1] is IValue val)
                return new cmp(dest, val);
            else
                throw new NotImplementedException();
        }
    }
}
