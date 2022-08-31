using ProcessorEmulator.Arguments;
using ProcessorEmulator.Arguments.Base;
using ProcessorEmulator.Commands.Base;
using ProcessorEmulator.Commands.LowLevelCommands;
using ProcessorEmulator.LowLevelCommands;
using ProcessorEmulator.UtilityCommands;

var commands = new ICommand[]
{
    MovCommand.Create(Register.Set(REG.RAX), Constant.Set(10)),             // mov rax, 10
    MovCommand.Create(Memory.Set(0x2),       Constant.Set(15)),             // mov ptr [2h], 15
    MovCommand.Create(Register.Set(REG.RCX), Constant.Set(0x2)),            // mov rcx, 2
    MovCommand.Create(Register.Set(REG.RDI), Register.Address(REG.RCX)),    // mov rdi, [rcx]
    MovCommand.Create(Memory.Set(0x1),       Register.Set(REG.RAX)),        // mov ptr [1h], rax
    AddCommand.Create(Register.Set(REG.RAX), Memory.Set(0x1)),              // add rax, ptr [1h]
    SubCommand.Create(Memory.Set(0x1),       Constant.Set(5)),              // sub ptr [1h], 5
    MulCommand.Create(Register.Set(REG.RAX), Memory.Set(0x1)),              // mul rax, ptr [1h]
    MovCommand.Create(Memory.Set(0x2),       Register.Set(REG.RAX)),        // mov ptr [2h], rax
    DivCommand.Create(Constant.Set(33)),                                    // div 33
    MovCommand.Create(Register.Set(REG.RSI), Register.Set(REG.RDX)),        // mov rsi, rdx
    DumpCommand.Create()                                                    // dump
};

for (int i = 0; i < commands.Length; i++)
{
    commands[i].Dump().Execute();

    Console.WriteLine();
}

Console.ReadKey(true);