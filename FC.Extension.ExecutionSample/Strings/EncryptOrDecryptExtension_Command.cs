using System;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using FC.Core.Common.Extension;
using FC.Core.Extension.StringHandlers;

namespace FC.Extension.ExecutionSample.Strings
{
    [Command("Crypto")]
    public class EncryptExtension_Command : ICommand
    {        
        

        [CommandOption("Crypto", 'c', Description = "Crypto Option")]
        public CryptoOption Crypto { get; set; }

        public ValueTask ExecuteAsync(IConsole console)
        {
           
            console.Output.WriteLine($"Option : {Crypto}");
            string value = string.Empty;
            string key = string.Empty;
            string encryptedValue = string.Empty;
            string decryptedValue = string.Empty;   
            switch (Crypto)
            {
                case CryptoOption.Encrypt:
                    console.Output.WriteLine("Please input a value to Encrypt");
                    value = console.Input.ReadLine();
                    console.Output.WriteLine("Please input a key");
                    key = console.Input.ReadLine();
                    encryptedValue = value.Encrypt(key);
                    console.Output.WriteLine($"Plan Text : {value} Encrypted Value : {encryptedValue} Key : {key}");
                    break;
                case CryptoOption.Decrypt:
                    console.Output.WriteLine("Please input a value to Encrypt");
                    value = console.Input.ReadLine();
                    console.Output.WriteLine("Please input a key");
                    key = console.Input.ReadLine();
                    encryptedValue = value.Encrypt(key);                    
                    console.Output.WriteLine($"Plan Text : {value} Encrypted Value : {encryptedValue} Key : {key}");
                    decryptedValue = encryptedValue.Decrypt(key);
                    console.Output.WriteLine($"Plan Text : {value} Decrypted Value : {decryptedValue} Key : {key}");
                    break;
                case CryptoOption.GenerateHash:
                    console.Output.WriteLine("Please input a value to Hash");
                    string plainText = console.Input.ReadLine();
                    foreach (HashAlgorithms algorithms in Enum.GetValues(typeof(HashAlgorithms)))
                    {
                        console.Output.WriteLine($"Algorithm : {algorithms.ToString()} Hash Value :{plainText.SecureHash(algorithms)}");
                    }                     
                    break;
                default:
                    break;
            }
            //console.Output.WriteLine($"IsDecrypt : {IsDecrypt}");
            //string encryptedValue = Value2Encrypt.Encrypt(Key);
            //console.Output.WriteLine($"Plan Text : {Value2Encrypt} Encrypted Value : {encryptedValue} Key : {Key}");
            return default;
        }

        public enum CryptoOption
        {
            Encrypt,
            Decrypt,
            GenerateHash
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
