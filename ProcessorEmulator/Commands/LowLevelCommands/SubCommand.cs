﻿using ProcessorEmulator.Arguments.Base;
using ProcessorEmulator.Commands.Base;

namespace ProcessorEmulator.Commands.LowLevelCommands
{
    class SubCommand : ICommand
    {
        private readonly IObject _reciever;
        private readonly IValue _source;

        private SubCommand(IObject rec, IValue src)
        {
            _reciever = rec;
            _source = src;
        }

        public ICommand Dump()
        {
            Console.Write($"sub {_reciever.GetName()}, {_source.GetName()}");

            return this;
        }

        public ICommand Execute()
        {
            var value = _reciever.GetValue() - _source.GetValue();
            _reciever.SetValue(value);

            return this;
        }

        public static ICommand Create(params IArgument[] args)
        {
            if (args.Length != 2)
                throw new ArgumentException();
            if (args[0] is IObject rec && args[1] is IValue src)
                return new SubCommand(rec, src);
            else
                throw new NotImplementedException();
        }
    }
}
