```{=html}
<?xml version="1.0"?>
```
`<doc>`{=html} `<assembly>`{=html}
`<name>`{=html}FC.Core.Extension`</name>`{=html} `</assembly>`{=html}
`<members>`{=html}
`<member name="T:FC.Core.Common.Extension.HashAlgorithms">`{=html}
```{=html}
<summary>
```
Hash Algorithms
```{=html}
</summary>
```
        </member>
        <member name="T:FC.Core.Strings.Extension.EncryptOrDecryptExtension">
            <summary>
            Encrypt or Decrypt a string as a extension method. It uses RSA Standard algorithm to do this.
            </summary>
        </member>
        <member name="M:FC.Core.Strings.Extension.EncryptOrDecryptExtension.Encrypt(System.String,System.String)">
            <summary>
            Encryptes a string using the supplied key. Encoding is done using RSA encryption.
            </summary>
            <param name="stringToEncrypt">String that must be encrypted.</param>
            <param name="key">Encryptionkey.</param>
            <returns>A string representing a byte array separated by a minus sign.</returns>
            <exception cref="T:System.ArgumentException">Occurs when stringToEncrypt or key is null or empty.</exception>
        </member>
        <member name="M:FC.Core.Strings.Extension.EncryptOrDecryptExtension.Decrypt(System.String,System.String)">
            <summary>
            Decryptes a string using the supplied key. Decoding is done using RSA encryption.
            </summary>
            <param name="stringToDecrypt">String that must be decrypted.</param>
            <param name="key">Decryptionkey.</param>
            <returns>The decrypted string or null if decryption failed.</returns>
            <exception cref="T:System.ArgumentException">Occurs when stringToDecrypt or key is null or empty.</exception>
        </member>
        <member name="T:FC.Core.Strings.Extension.SecureHashExtension">
            <summary>
            Secure Hash - A Class extension to hash the string with various algorithms
            Ref: https://emn178.github.io/online-tools/sha256.html
            </summary>
        </member>
        <member name="M:FC.Core.Strings.Extension.SecureHashExtension.SecureHash(System.String,FC.Core.Common.Extension.HashAlgorithms)">
            <summary>
            Creates the Hash value for the String
            </summary>
            <param name="stringToHash">value of string to be hased</param>
            <param name="hashAlgorithms">An Algorithm which is used to Hash</param>
            <returns></returns>
        </member>
        <member name="M:FC.Core.Strings.Extension.SecureHashExtension.SHA256_Hash(System.String)">
            <summary>
            Uses SHA 256 for hasing
            </summary>
            <param name="stringToHash">string to hash</param>
            <returns>Returns hash value </returns>
        </member>
        <member name="M:FC.Core.Strings.Extension.SecureHashExtension.SHA_Hash(System.String,System.Security.Cryptography.HashAlgorithm)">
            <summary>
            Uses SHA for hasing
            </summary>
            <param name="stringToHash">string to hash</param>
            <param name="hashObject">Algorithm at runtime to hash</param>
            <returns>Returns hash value </returns>
        </member>
        <member name="M:FC.Core.Strings.Extension.SecureHashExtension.SHA512_Hash(System.String)">
            <summary>
            Uses SHA 512 for hasing
            </summary>
            <param name="stringToHash">string to hash</param>
            <returns>Returns hash value </returns>
        </member>
        <member name="T:FC.Core.Strings.Extension.ToJsonExtension">
            <summary>
            Converts String into JSON Value
            </summary>
        </member>
        <member name="M:FC.Core.Strings.Extension.ToJsonExtension.ToJSON``1(``0,System.Boolean)">
            <summary>
            Converts the object as a json string
            Can be used for logging object contents.
            </summary>
            <typeparam name="T">Type of the object.</typeparam>
            <param name="obj">The object to dump. Can be null</param>
            <param name="indent">To indent the result or not</param>
            <example>
            <code lang="csharp">
            string myvalue = "this is the large string";
            myvalue.Truncate(7);//will return this...
            </code>
            </example>
            <returns>the a string representing the object content</returns>
        </member>
        <member name="T:FC.Core.Strings.Extension.ToModelExtension">
            <summary>
            Extension class converts String to Model
            </summary>
        </member>
        <member name="M:FC.Core.Strings.Extension.ToModelExtension.ToModel``1(System.String)">
            <summary>
            Converts String to Model object
            </summary>
            <typeparam name="T">Model Type</typeparam>
            <param name="stringToDeserialize">model as json string</param>
            <returns>returns model object</returns>
        </member>
        <member name="M:FC.Core.Strings.Extension.ToPasswordHashExtension.ToPasswordHash(System.String,System.String)">
            <summary>
            Generates the password Hash in a most recommended way using 'KeyDerivation.Pbkdf2' and 'Rfc2898DeriveBytes'
            </summary>
            <param name="password">string that has to be hased</param>
            <param name="saltValue">Salt value, if null it will be genereted and returns the salt</param>
            <example>
            <code lang="csharp">
            string myvalue = "this is the large string";
            PasswordHashInfo pInfo = myvalue.ToPasswordHash();
            var pswd = pInfo.PasswordHash;
            var saltArray = pInfo.SaltAsByteArray;
            var saltString = pInfo.SaltAsString;
            </code>
            </example>
            <returns>returns PasswordHashInfo</returns>
        </member>
        <member name="M:FC.Core.Strings.Extension.ToPasswordHashExtension.ToPasswordHash(System.String,System.Byte[])">
            <summary>
            Generates the password Hash in a most recommended way using 'KeyDerivation.Pbkdf2' and 'Rfc2898DeriveBytes'
            </summary>
            <param name="password">string that has to be hased</param>
            <param name="saltValue">Salt value, if null it will be genereted and returns the salt</param>
            <example>
            <code lang="csharp">
            string myvalue = "this is the large string";
            PasswordHashInfo pInfo = myvalue.ToPasswordHash();
            var pswd = pInfo.PasswordHash;
            var saltArray = pInfo.SaltAsByteArray;
            var saltString = pInfo.SaltAsString;
            </code>
            </example>
            <returns>returns PasswordHashInfo</returns>
        </member>
        <member name="M:FC.Core.Strings.Extension.ToPasswordHashExtension.GetSaltAsByte">
            <summary>
            Get the salt value, which is used to hash the password.
            </summary>
            <returns>Returns salt as byte array</returns>
        </member>
        <member name="M:FC.Core.Strings.Extension.ToPasswordHashExtension.GetSaltAsString">
            <summary>
            Get the salt value, which is used to hash the password.
            </summary>
            <returns>Returns salt as String value</returns>
        </member>
        <member name="T:FC.Core.Strings.Extension.ToStreamExtension">
            <summary>
            Extension class which converts string to stream object
            </summary>
        </member>
        <member name="M:FC.Core.Strings.Extension.ToStreamExtension.ToStream(System.String)">
            <summary>
            Converts String to Stream Object
            </summary>
            <param name="this">string value</param>
            <example>
            <code>
            string value = "MyString";
            Stream stream = value.ToStream();
            </code>
            </example>
            <returns>returns stream object</returns>
        </member>
        <member name="M:FC.Core.Strings.Extension.TruncateExtension.Truncate(System.String,System.Int32)">
            <summary>
            Truncates the string to a specified length and replace the truncated to a ...
            </summary>
            <param name="text">string that will be truncated</param>
            <param name="maxLength">total length of characters required as output</param>
            <example>
            <code lang="csharp">
            string myvalue = "this is the large string";
            myvalue.Truncate(7);//will return this...
            </code>
            </example>
            <returns>truncated string</returns>
        </member>
        <member name="T:FC.Core.Strings.Extension.XMLToModelExtension">
            <summary>
            Extension class which converts XML Document to Model object
            </summary>
        </member>
        <member name="M:FC.Core.Strings.Extension.XMLToModelExtension.XMLToModel``1(System.String)">
            <summary>
            Converts XML Document to Model object
            </summary>
            <typeparam name="T">Model type</typeparam>
            <param name="this">xml document as string</param>
            <example>
            <code>
             string xml = File.ReadAllText(@"D:\file.xml");
             var catalog1 = xml.XMLToModel &lt;Model&gt; ();
            </code>
            </example>
            <returns>returns destination object type</returns>
        </member>
    </members>

`</doc>`{=html}
