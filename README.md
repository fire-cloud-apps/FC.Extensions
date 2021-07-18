## FC.Core.Extension ##

# T:FC.Core.Common.Extension.HashAlgorithms

 Hash Algorithms 



---
# T:FC.Core.Strings.Extension.EncryptOrDecryptExtension

 Encrypt or Decrypt a string as a extension method. It uses RSA Standard algorithm to do this. 



---
##### M:FC.Core.Strings.Extension.EncryptOrDecryptExtension.Encrypt(System.String,System.String)

 Encryptes a string using the supplied key. Encoding is done using RSA encryption. 

|Name | Description |
|-----|------|
|stringToEncrypt: |String that must be encrypted.|
|Name | Description |
|-----|------|
|key: |Encryptionkey.|
Returns: A string representing a byte array separated by a minus sign.

[[T:System.ArgumentException|T:System.ArgumentException]]: Occurs when stringToEncrypt or key is null or empty.



---
##### M:FC.Core.Strings.Extension.EncryptOrDecryptExtension.Decrypt(System.String,System.String)

 Decryptes a string using the supplied key. Decoding is done using RSA encryption. 

|Name | Description |
|-----|------|
|stringToDecrypt: |String that must be decrypted.|
|Name | Description |
|-----|------|
|key: |Decryptionkey.|
Returns: The decrypted string or null if decryption failed.

[[T:System.ArgumentException|T:System.ArgumentException]]: Occurs when stringToDecrypt or key is null or empty.



---
# T:FC.Core.Strings.Extension.SecureHashExtension

 Secure Hash - A Class extension to hash the string with various algorithms Ref: https://emn178.github.io/online-tools/sha256.html 



---
##### M:FC.Core.Strings.Extension.SecureHashExtension.SecureHash(System.String,FC.Core.Common.Extension.HashAlgorithms)

 Creates the Hash value for the String 

|Name | Description |
|-----|------|
|stringToHash: |value of string to be hased|
|Name | Description |
|-----|------|
|hashAlgorithms: |An Algorithm which is used to Hash|
Returns: 



---
##### M:FC.Core.Strings.Extension.SecureHashExtension.SHA256_Hash(System.String)

 Uses SHA 256 for hasing 

|Name | Description |
|-----|------|
|stringToHash: |string to hash|
Returns: Returns hash value 



---
##### M:FC.Core.Strings.Extension.SecureHashExtension.SHA_Hash(System.String,System.Security.Cryptography.HashAlgorithm)

 Uses SHA for hasing 

|Name | Description |
|-----|------|
|stringToHash: |string to hash|
|Name | Description |
|-----|------|
|hashObject: |Algorithm at runtime to hash|
Returns: Returns hash value 



---
##### M:FC.Core.Strings.Extension.SecureHashExtension.SHA512_Hash(System.String)

 Uses SHA 512 for hasing 

|Name | Description |
|-----|------|
|stringToHash: |string to hash|
Returns: Returns hash value 



---
# T:FC.Core.Strings.Extension.ToJsonExtension

 Converts String into JSON Value 



---
##### M:FC.Core.Strings.Extension.ToJsonExtension.ToJSON``1(``0,System.Boolean)

 Converts the object as a json string Can be used for logging object contents. 

|Name | Description |
|-----|------|
|T: |Type of the object.|
|Name | Description |
|-----|------|
|obj: |The object to dump. Can be null|
|Name | Description |
|-----|------|
|indent: |To indent the result or not|
_C# code_

```c#
    string myvalue = "this is the large string";
    myvalue.Truncate(7);//will return this...
    
```

Returns: the a string representing the object content



---
# T:FC.Core.Strings.Extension.ToModelExtension

 Extension class converts String to Model 



---
##### M:FC.Core.Strings.Extension.ToModelExtension.ToModel``1(System.String)

 Converts String to Model object 

|Name | Description |
|-----|------|
|T: |Model Type|
|Name | Description |
|-----|------|
|stringToDeserialize: |model as json string|
Returns: returns model object



---
##### M:FC.Core.Strings.Extension.ToPasswordHashExtension.ToPasswordHash(System.String,System.String)

 Generates the password Hash in a most recommended way using 'KeyDerivation.Pbkdf2' and 'Rfc2898DeriveBytes' 

|Name | Description |
|-----|------|
|password: |string that has to be hased|
|Name | Description |
|-----|------|
|saltValue: |Salt value, if null it will be genereted and returns the salt|
_C# code_

```c#
    string myvalue = "this is the large string";
    PasswordHashInfo pInfo = myvalue.ToPasswordHash();
    var pswd = pInfo.PasswordHash;
    var saltArray = pInfo.SaltAsByteArray;
    var saltString = pInfo.SaltAsString;
    
```

Returns: returns PasswordHashInfo



---
##### M:FC.Core.Strings.Extension.ToPasswordHashExtension.ToPasswordHash(System.String,System.Byte[])

 Generates the password Hash in a most recommended way using 'KeyDerivation.Pbkdf2' and 'Rfc2898DeriveBytes' 

|Name | Description |
|-----|------|
|password: |string that has to be hased|
|Name | Description |
|-----|------|
|saltValue: |Salt value, if null it will be genereted and returns the salt|
_C# code_

```c#
    string myvalue = "this is the large string";
    PasswordHashInfo pInfo = myvalue.ToPasswordHash();
    var pswd = pInfo.PasswordHash;
    var saltArray = pInfo.SaltAsByteArray;
    var saltString = pInfo.SaltAsString;
    
```

Returns: returns PasswordHashInfo



---
##### M:FC.Core.Strings.Extension.ToPasswordHashExtension.GetSaltAsByte

 Get the salt value, which is used to hash the password. 

Returns: Returns salt as byte array



---
##### M:FC.Core.Strings.Extension.ToPasswordHashExtension.GetSaltAsString

 Get the salt value, which is used to hash the password. 

Returns: Returns salt as String value



---
# T:FC.Core.Strings.Extension.ToStreamExtension

 Extension class which converts string to stream object 



---
##### M:FC.Core.Strings.Extension.ToStreamExtension.ToStream(System.String)

 Converts String to Stream Object 

|Name | Description |
|-----|------|
|this: |string value|
_C# code_

```c#
    string value = "MyString";
    Stream stream = value.ToStream();
    
```

Returns: returns stream object



---
##### M:FC.Core.Strings.Extension.TruncateExtension.Truncate(System.String,System.Int32)

 Truncates the string to a specified length and replace the truncated to a ... 

|Name | Description |
|-----|------|
|text: |string that will be truncated|
|Name | Description |
|-----|------|
|maxLength: |total length of characters required as output|
_C# code_

```c#
    string myvalue = "this is the large string";
    myvalue.Truncate(7);//will return this...
    
```

Returns: truncated string



---
# T:FC.Core.Strings.Extension.XMLToModelExtension

 Extension class which converts XML Document to Model object 



---
##### M:FC.Core.Strings.Extension.XMLToModelExtension.XMLToModel``1(System.String)

 Converts XML Document to Model object 

|Name | Description |
|-----|------|
|T: |Model type|
|Name | Description |
|-----|------|
|this: |xml document as string|
_C# code_

```c#
    string xml = File.ReadAllText(@"D:\file.xml");
    var catalog1 = xml.XMLToModel <Model> ();
   
```

Returns: returns destination object type



---


