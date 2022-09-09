using ProcessorEmulator.Arguments;
using ProcessorEmulator.Commands.Base;
using ProcessorEmulator.Commands.LowLevelCommands;
using ProcessorEmulator.UtilityCommands;
using static ProcessorEmulator.Arguments.Base.RegDef;

var commands = new ICommand[]
{
    /* 0  */ mov.i(reg.s(rax),           con.s(10)),         // mov rax, 10
    /* 1  */ mov.i(adr.s(con.s(0x2)),    con.s(15)),         // mov ptr [2h], 15
    /* 2  */ mov.i(reg.s(rcx),           con.s(0x2)),        // mov rcx, 2
    /* 3  */ mov.i(reg.s(rdi),           adr.s(reg.s(rcx))), // mov rdi, [rcx]
    /* 4  */ mov.i(adr.s(con.s(0x1)),    reg.s(rax)),        // mov ptr [1h], rax
    /* 5  */ add.i(reg.s(rax),           adr.s(con.s(0x1))), // add rax, ptr [1h]
    /* 6  */ sub.i(adr.s(con.s(0x1)),    con.s(5)),          // sub ptr [1h], 5
    /* 7  */ mul.i(reg.s(rax),           adr.s(con.s(0x1))), // mul rax, ptr [1h]
    /* 8  */ mov.i(adr.s(con.s(0x2)),    reg.s(rax)),        // mov ptr [2h], rax
    /* 9  */ div.i(con.s(33)),                               // div 33
    /* 10 */ mov.i(reg.s(rsi),           reg.s(rdx)),        // mov rsi, rdx

    /* 11 */ push.i(con.s(5)),                               // push 5
    /* 12 */ push.i(con.s(4)),                               // push 4
    /* 13 */ push.i(con.s(3)),                               // push 3
    /* 14 */ push.i(con.s(2)),                               // push 2
    /* 15 */ push.i(con.s(1)),                               // push 1
    /* 16 */ dump.i(),                                       // dump
    /* 17 */ pop.i(reg.s(rdx)),                              // pop rdx

    /* 18 */ dump.i()                                        // dump
};

for (int i = 0; i < commands.Length;)
{
    commands[i].d().e(ref i);

    Console.WriteLine();
}

Console.ReadKey(true);