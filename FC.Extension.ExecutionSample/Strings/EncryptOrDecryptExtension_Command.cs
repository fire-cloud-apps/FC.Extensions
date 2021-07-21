using System;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using FC.Core.Extension.StringHandlers;

namespace FC.Extension.ExecutionSample.Strings
{
    [Command("Enc")]
    public class EncryptExtension_Command : ICommand
    {        
        [CommandOption("enc", 'e', Description = "Value that has to be encrypt")]
        public string Value { get; set; }

        [CommandOption("key", 'k', Description = "Key used to encrypt or Decrypt.")]
        public string Key { get; set; }

        public ValueTask ExecuteAsync(IConsole console)
        {
            string encryptedValue = Value.Encrypt(Key);
            console.Output.WriteLine($"Plan Text : {Value} Encrypted Value : {encryptedValue} Key : {Key}");
            return default;
        }
    }

    [Command("Dec")]
    public class DecryptExtension_Command : ICommand
    {
        [CommandOption("enc", 'e', Description = "Value that has to be encrypt")]
        public string Value { get; set; }

        [CommandOption("key", 'k', Description = "Key used to encrypt or Decrypt.")]
        public string Key { get; set; }

        public ValueTask ExecuteAsync(IConsole console)
        {
            string encryptedValue = Value.Encrypt(Key);
            string decryptedValue = encryptedValue.Decrypt(Key);
            console.Output.WriteLine($"Plan Text : {Value} Encrypted Value : {encryptedValue} Key : {Key}");
            console.Output.WriteLine($"Encrypted Text : {encryptedValue} Decrypted Value : {decryptedValue} Key : {Key}");
            return default;
        }
    }

}
