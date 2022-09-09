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
    abstract ICommand d();
}
