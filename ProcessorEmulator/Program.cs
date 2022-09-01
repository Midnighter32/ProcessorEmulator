using ProcessorEmulator.Arguments;
using ProcessorEmulator.Arguments.Base;
using ProcessorEmulator.Commands.Base;
using ProcessorEmulator.Commands.LowLevelCommands;
using ProcessorEmulator.LowLevelCommands;
using ProcessorEmulator.UtilityCommands;
using static ProcessorEmulator.Arguments.Base.RegDef;

var commands = new ICommand[]
{
    /**/
        mov.i(reg.s(rax),           con.s(10)),         // mov rax, 10
        mov.i(adr.s(con.s(0x2)),    con.s(15)),         // mov ptr [2h], 15
        mov.i(reg.s(rcx),           con.s(0x2)),        // mov rcx, 2
        mov.i(reg.s(rdi),           adr.s(reg.s(rcx))), // mov rdi, [rcx]
        mov.i(adr.s(con.s(0x1)),    reg.s(rax)),        // mov ptr [1h], rax
        add.i(reg.s(rax),           adr.s(con.s(0x1))), // add rax, ptr [1h]
        sub.i(adr.s(con.s(0x1)),    con.s(5)),          // sub ptr [1h], 5
        mul.i(reg.s(rax),           adr.s(con.s(0x1))), // mul rax, ptr [1h]
        mov.i(adr.s(con.s(0x2)),    reg.s(rax)),        // mov ptr [2h], rax
        div.i(con.s(33)),                               // div 33
        mov.i(reg.s(rsi),           reg.s(rdx)),        // mov rsi, rdx
    /**/

    /**/

        push.i(con.s(5)),                               // push 5
        push.i(con.s(4)),                               // push 4
        push.i(con.s(3)),                               // push 3
        push.i(con.s(2)),                               // push 2
        push.i(con.s(1)),                               // push 1
        dump.i(),                                       // dump
        pop.i(reg.s(rdx)),                              // pop rdx

    /**/

    dump.i()                                            // dump
};

for (int i = 0; i < commands.Length;)
{
    commands[i].d().e(ref i);

    Console.WriteLine();
}

Console.ReadKey(true);