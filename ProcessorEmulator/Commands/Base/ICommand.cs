using ProcessorEmulator.Arguments.Base;

namespace ProcessorEmulator.Commands.Base;

interface ICommand
{
    /// <summary>
    /// Execute Command
    /// </summary>
    /// <param name="i">Command Identifier</param>
    /// <returns>Return ICommand for method chaining</returns>
    ICommand e(ref int i);

    /// <summary>
    /// Dump Command info in Console
    /// </summary>
    /// <returns>Return ICommand for method chaining</returns>
    ICommand d();

    /// <summary>
    /// Create ICommand instance
    /// </summary>
    /// <param name="args">Command arguments</param>
    /// <returns>ICommand instance</returns>
    static abstract ICommand i(params IArgument[] args);
}
