using ProcessorEmulator.HardwareEmulation.Base;

namespace ProcessorEmulator.HardwareEmulation;

class MemoryHeap : IHardware
{
    private MemoryHeap()
    {
    }

    private readonly Dictionary<int, int> _ram = new();

    private int Check(int address)
    {
        if (!_ram.ContainsKey(address))
            _ram[address] = 0;

        return address;
    }

    public void Read(int address, out int value) => value = _ram[Check(address)];

    public void Write(int address, int value) => _ram[address] = value;

    public void Dump()
    {
        foreach (var (address, val) in _ram.OrderBy(x => x.Key))
        {
            Console.WriteLine($"[{address}h]={val}");
        }
    }

    public static MemoryHeap Instance = new MemoryHeap();
}
