using ProcessorEmulator.Arguments.Base;
using ProcessorEmulator.Commands.Base;

namespace ProcessorEmulator.Commands.LowLevelCommands
{
    class add : ICommand
    {
        private readonly IObject _reciever;
        private readonly IValue _source;

        private add(IObject rec, IValue src)
        {
            _reciever = rec;
            _source = src;
        }

        public ICommand d()
        {
            Console.Write($"add {_reciever.GetName()}, {_source.GetName()}");

            return this;
        }

        public ICommand e(ref int i)
        {
            var value = _reciever.GetValue() + _source.GetValue();
            _reciever.SetValue(value);

            i++;

            return this;
        }

        public static ICommand i(params IArgument[] args)
        {
            if (args.Length != 2)
                throw new ArgumentException();
            if (args[0] is IObject rec && args[1] is IValue src)
                return new add(rec, src);
            else
                throw new NotImplementedException();
        }
    }
}
