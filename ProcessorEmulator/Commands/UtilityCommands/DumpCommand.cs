using ProcessorEmulator.Arguments.Base;
using ProcessorEmulator.Commands.Base;
using ProcessorEmulator.HardwareEmulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessorEmulator.UtilityCommands
{
    class DumpCommand : ICommand
    {
        private DumpCommand()
        {
        }

        public ICommand Dump()
        {
            Console.Write("dump");

            return this;
        }

        public ICommand Execute(ref int i)
        {
            Console.WriteLine();

            Console.WriteLine("=========\nreg:");
            Registers.Instance.Dump();
            Console.WriteLine("\nmem:");
            MemoryHeap.Instance.Dump();
            Console.WriteLine("=========");

            i++;

            return this;
        }

        public static ICommand Create(params IArgument[] args)
        {
            if (args.Length != 0)
                throw new NotImplementedException();

            return new DumpCommand();
        }
    }
}
