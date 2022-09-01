using ProcessorEmulator.HardwareEmulation.Base;

namespace ProcessorEmulator.HardwareEmulation
{
    class Stack : IHardware
    {
        private Stack()
        {
        }

        Stack<int> _stack = new Stack<int>(16384);

        public void Dump()
        {
            foreach (var item in _stack)
            {
                Console.WriteLine(item);
            }
        }

        public void Read(int ind, out int value)
        {
            if (_stack.Count != 0)
                value = _stack.Pop();
            else value = 0;
        }

        public void Write(int ind, int value)
        {
            _stack.Push(value);
        }

        public void Pop(out int value) => Read(-1, out value);
        public void Push(int value) => Write(-1, value);

        public static Stack Instance = new Stack();
    }
}
