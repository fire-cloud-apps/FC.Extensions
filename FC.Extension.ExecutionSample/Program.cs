using System;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;

namespace FC.Extension.ExecutionSample
{
    public static class Program
    {
        public static async Task<int> Main() =>
            await new CliApplicationBuilder()
                .AddCommandsFromThisAssembly()
                .Build()
                .RunAsync();
    }

    [Command("HellowWorld")]
    public class HelloWorldCommand : ICommand
    {
        public ValueTask ExecuteAsync(IConsole console)
        {
            console.Output.WriteLine("Hello world!");

            // Return default task if the command is not asynchronous
            return default;
        }
    }

    [Command("Log")]
    public class LogCommand : ICommand
    {
        // Order: 0
        [CommandParameter(0, Description = "Value whose logarithm is to be found.")]
        public double Value { get; set; }

        // Name: --base
        // Short name: -b
        [CommandOption("base", 'b', Description = "Logarithm base.")]
        public double Base { get; set; } = 10;

        public ValueTask ExecuteAsync(IConsole console)
        {
            var result = Math.Log(Value, Base);
            console.Output.WriteLine($"Value : {Value} Base {Base}");
            console.Output.WriteLine(result);

            return default;
        }
    }

}
