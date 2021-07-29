<a name='assembly'></a>
# FC.Core.Extension

## Contents

- [AgeExtension](#T-FC-Core-Extension-DateHandlers-AgeExtension 'FC.Core.Extension.DateHandlers.AgeExtension')
  - [Age(dateOfBirth)](#M-FC-Core-Extension-DateHandlers-AgeExtension-Age-System-DateTime- 'FC.Core.Extension.DateHandlers.AgeExtension.Age(System.DateTime)')
  - [AgeInMonth(dateOfBirth)](#M-FC-Core-Extension-DateHandlers-AgeExtension-AgeInMonth-System-DateTime- 'FC.Core.Extension.DateHandlers.AgeExtension.AgeInMonth(System.DateTime)')
- [DeleteFilesExtension](#T-FC-Core-Extension-FileHanders-DeleteFilesExtension 'FC.Core.Extension.FileHanders.DeleteFilesExtension')
  - [DeleteEmptyDirectory(rootDirectory)](#M-FC-Core-Extension-FileHanders-DeleteFilesExtension-DeleteEmptyDirectory-System-String- 'FC.Core.Extension.FileHanders.DeleteFilesExtension.DeleteEmptyDirectory(System.String)')
  - [DeleteExpiredFiles(directoryPath,expiryInDays,searchPattern,notContains)](#M-FC-Core-Extension-FileHanders-DeleteFilesExtension-DeleteExpiredFiles-System-String,System-Int32,System-String,System-String- 'FC.Core.Extension.FileHanders.DeleteFilesExtension.DeleteExpiredFiles(System.String,System.Int32,System.String,System.String)')
  - [DeleteFiles(folderPath,ext)](#M-FC-Core-Extension-FileHanders-DeleteFilesExtension-DeleteFiles-System-String,System-String- 'FC.Core.Extension.FileHanders.DeleteFilesExtension.DeleteFiles(System.String,System.String)')
  - [SmoothDelete(directoryPath,expiryInDays,searchPattern,notContains)](#M-FC-Core-Extension-FileHanders-DeleteFilesExtension-SmoothDelete-System-String,System-Int32,System-String,System-String- 'FC.Core.Extension.FileHanders.DeleteFilesExtension.SmoothDelete(System.String,System.Int32,System.String,System.String)')
- [DeletedFilesInfo](#T-FC-Core-Extension-FileHanders-DeletedFilesInfo 'FC.Core.Extension.FileHanders.DeletedFilesInfo')
  - [ExceptionDetail](#P-FC-Core-Extension-FileHanders-DeletedFilesInfo-ExceptionDetail 'FC.Core.Extension.FileHanders.DeletedFilesInfo.ExceptionDetail')
  - [FileName](#P-FC-Core-Extension-FileHanders-DeletedFilesInfo-FileName 'FC.Core.Extension.FileHanders.DeletedFilesInfo.FileName')
  - [Status](#P-FC-Core-Extension-FileHanders-DeletedFilesInfo-Status 'FC.Core.Extension.FileHanders.DeletedFilesInfo.Status')
- [EncryptOrDecryptExtension](#T-FC-Core-Extension-StringHandlers-EncryptOrDecryptExtension 'FC.Core.Extension.StringHandlers.EncryptOrDecryptExtension')
  - [Decrypt(stringToDecrypt,key)](#M-FC-Core-Extension-StringHandlers-EncryptOrDecryptExtension-Decrypt-System-String,System-String- 'FC.Core.Extension.StringHandlers.EncryptOrDecryptExtension.Decrypt(System.String,System.String)')
  - [Encrypt(stringToEncrypt,key)](#M-FC-Core-Extension-StringHandlers-EncryptOrDecryptExtension-Encrypt-System-String,System-String- 'FC.Core.Extension.StringHandlers.EncryptOrDecryptExtension.Encrypt(System.String,System.String)')
- [FileExtensions](#T-FC-Core-Extension-FileHanders-FileExtensions 'FC.Core.Extension.FileHanders.FileExtensions')
  - [GetFilesByLastModified(dirName,days,searchPattern,notContains)](#M-FC-Core-Extension-FileHanders-FileExtensions-GetFilesByLastModified-System-String,System-Int32,System-String,System-String- 'FC.Core.Extension.FileHanders.FileExtensions.GetFilesByLastModified(System.String,System.Int32,System.String,System.String)')
- [HashAlgorithms](#T-FC-Core-Common-Extension-HashAlgorithms 'FC.Core.Common.Extension.HashAlgorithms')
- [IEnumerableExtensions](#T-FC-Core-Extension-ListHandlers-IEnumerableExtensions 'FC.Core.Extension.ListHandlers.IEnumerableExtensions')
- [ImageUtility](#T-FC-Core-Extension-ImageHandlers-ImageUtility 'FC.Core.Extension.ImageHandlers.ImageUtility')
  - [GetImageAsByte(url)](#M-FC-Core-Extension-ImageHandlers-ImageUtility-GetImageAsByte-System-String- 'FC.Core.Extension.ImageHandlers.ImageUtility.GetImageAsByte(System.String)')
- [NumericUtility](#T-FC-Core-Extension-NumericHandlers-NumericUtility 'FC.Core.Extension.NumericHandlers.NumericUtility')
  - [GetRandomNumber(min,max)](#M-FC-Core-Extension-NumericHandlers-NumericUtility-GetRandomNumber-System-Int32,System-Int32- 'FC.Core.Extension.NumericHandlers.NumericUtility.GetRandomNumber(System.Int32,System.Int32)')
- [PropertyEquals](#T-FC-Core-Extension-GenericHandlers-PropertyEquals 'FC.Core.Extension.GenericHandlers.PropertyEquals')
  - [PublicInstancePropertiesEqual\`\`1(self,to,ignore)](#M-FC-Core-Extension-GenericHandlers-PropertyEquals-PublicInstancePropertiesEqual``1-``0,``0,System-String[]- 'FC.Core.Extension.GenericHandlers.PropertyEquals.PublicInstancePropertiesEqual``1(``0,``0,System.String[])')
- [SecureHashExtension](#T-FC-Core-Extension-StringHandlers-SecureHashExtension 'FC.Core.Extension.StringHandlers.SecureHashExtension')
  - [SHA256_Hash(stringToHash)](#M-FC-Core-Extension-StringHandlers-SecureHashExtension-SHA256_Hash-System-String- 'FC.Core.Extension.StringHandlers.SecureHashExtension.SHA256_Hash(System.String)')
  - [SHA512_Hash(stringToHash)](#M-FC-Core-Extension-StringHandlers-SecureHashExtension-SHA512_Hash-System-String- 'FC.Core.Extension.StringHandlers.SecureHashExtension.SHA512_Hash(System.String)')
  - [SHA_Hash(stringToHash,hashObject)](#M-FC-Core-Extension-StringHandlers-SecureHashExtension-SHA_Hash-System-String,System-Security-Cryptography-HashAlgorithm- 'FC.Core.Extension.StringHandlers.SecureHashExtension.SHA_Hash(System.String,System.Security.Cryptography.HashAlgorithm)')
  - [SecureHash(stringToHash,hashAlgorithms)](#M-FC-Core-Extension-StringHandlers-SecureHashExtension-SecureHash-System-String,FC-Core-Common-Extension-HashAlgorithms- 'FC.Core.Extension.StringHandlers.SecureHashExtension.SecureHash(System.String,FC.Core.Common.Extension.HashAlgorithms)')
- [ToDataTableExtension](#T-FC-Core-Extension-DataHandlers-ToDataTableExtension 'FC.Core.Extension.DataHandlers.ToDataTableExtension')
  - [ToDataTable\`\`1(items)](#M-FC-Core-Extension-DataHandlers-ToDataTableExtension-ToDataTable``1-System-Collections-Generic-IList{``0}- 'FC.Core.Extension.DataHandlers.ToDataTableExtension.ToDataTable``1(System.Collections.Generic.IList{``0})')
- [ToJsonExtension](#T-FC-Core-Extension-StringHandlers-ToJsonExtension 'FC.Core.Extension.StringHandlers.ToJsonExtension')
  - [ToJSON\`\`1(obj,indent)](#M-FC-Core-Extension-StringHandlers-ToJsonExtension-ToJSON``1-``0,System-Boolean- 'FC.Core.Extension.StringHandlers.ToJsonExtension.ToJSON``1(``0,System.Boolean)')
- [ToModelExtension](#T-FC-Core-Extension-StringHandlers-ToModelExtension 'FC.Core.Extension.StringHandlers.ToModelExtension')
  - [ToModel\`\`1(stringToDeserialize)](#M-FC-Core-Extension-StringHandlers-ToModelExtension-ToModel``1-System-String- 'FC.Core.Extension.StringHandlers.ToModelExtension.ToModel``1(System.String)')
- [ToPasswordHashExtension](#T-FC-Core-Extension-StringHandlers-ToPasswordHashExtension 'FC.Core.Extension.StringHandlers.ToPasswordHashExtension')
  - [GetSaltAsByte()](#M-FC-Core-Extension-StringHandlers-ToPasswordHashExtension-GetSaltAsByte 'FC.Core.Extension.StringHandlers.ToPasswordHashExtension.GetSaltAsByte')
  - [GetSaltAsString()](#M-FC-Core-Extension-StringHandlers-ToPasswordHashExtension-GetSaltAsString 'FC.Core.Extension.StringHandlers.ToPasswordHashExtension.GetSaltAsString')
  - [ToPasswordHash(password,saltValue)](#M-FC-Core-Extension-StringHandlers-ToPasswordHashExtension-ToPasswordHash-System-String,System-String- 'FC.Core.Extension.StringHandlers.ToPasswordHashExtension.ToPasswordHash(System.String,System.String)')
  - [ToPasswordHash(password,saltValue)](#M-FC-Core-Extension-StringHandlers-ToPasswordHashExtension-ToPasswordHash-System-String,System-Byte[]- 'FC.Core.Extension.StringHandlers.ToPasswordHashExtension.ToPasswordHash(System.String,System.Byte[])')
- [ToStreamExtension](#T-FC-Core-Extension-StringHandlers-ToStreamExtension 'FC.Core.Extension.StringHandlers.ToStreamExtension')
  - [ToStream(this)](#M-FC-Core-Extension-StringHandlers-ToStreamExtension-ToStream-System-String- 'FC.Core.Extension.StringHandlers.ToStreamExtension.ToStream(System.String)')
- [TruncateExtension](#T-FC-Core-Extension-StringHandlers-TruncateExtension 'FC.Core.Extension.StringHandlers.TruncateExtension')
  - [Truncate(text,maxLength)](#M-FC-Core-Extension-StringHandlers-TruncateExtension-Truncate-System-String,System-Int32- 'FC.Core.Extension.StringHandlers.TruncateExtension.Truncate(System.String,System.Int32)')
- [XMLToModelExtension](#T-FC-Core-Extension-StringHandlers-XMLToModelExtension 'FC.Core.Extension.StringHandlers.XMLToModelExtension')
  - [XMLToModel\`\`1(this)](#M-FC-Core-Extension-StringHandlers-XMLToModelExtension-XMLToModel``1-System-String- 'FC.Core.Extension.StringHandlers.XMLToModelExtension.XMLToModel``1(System.String)')

<a name='T-FC-Core-Extension-DateHandlers-AgeExtension'></a>
## AgeExtension `type`

##### Namespace

FC.Core.Extension.DateHandlers

##### Summary

Extension method to get age of a given person or product etc.

<a name='M-FC-Core-Extension-DateHandlers-AgeExtension-Age-System-DateTime-'></a>
### Age(dateOfBirth) `method`

##### Summary

Get the current age of a person or product

##### Returns

returns data in years

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dateOfBirth | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') | date of birth of a person or product |

##### Example

```csharp
var dt = new DateTime(year: 1984, month: 6, day: 14);
int myAge = dt.Age();
```

<a name='M-FC-Core-Extension-DateHandlers-AgeExtension-AgeInMonth-System-DateTime-'></a>
### AgeInMonth(dateOfBirth) `method`

##### Summary

Get the current age of a person or product

##### Returns

returns data in month which is the rounded value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dateOfBirth | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') | date of birth of a person or product |

##### Example

```csharp
var dt = new DateTime(year: 1984, month: 6, day: 14);
double myAge = dt.AgeInMonth();
```

<a name='T-FC-Core-Extension-FileHanders-DeleteFilesExtension'></a>
## DeleteFilesExtension `type`

##### Namespace

FC.Core.Extension.FileHanders

##### Summary

Deletes All the files with the given extension

<a name='M-FC-Core-Extension-FileHanders-DeleteFilesExtension-DeleteEmptyDirectory-System-String-'></a>
### DeleteEmptyDirectory(rootDirectory) `method`

##### Summary

Delete all the Empty Directory

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rootDirectory | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Root Folder to scan |

<a name='M-FC-Core-Extension-FileHanders-DeleteFilesExtension-DeleteExpiredFiles-System-String,System-Int32,System-String,System-String-'></a>
### DeleteExpiredFiles(directoryPath,expiryInDays,searchPattern,notContains) `method`

##### Summary

Deletes the List of Files that has not accessed based on the given days.

##### Returns

List of deleted files

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| directoryPath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Directory Path Name |
| expiryInDays | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Days in negative value |
| searchPattern | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | search pattern eg. *.txt, s* |
| notContains | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | skip the folder or file that contains the word or char eg. _t |

##### Example

```csharp
var fileList = FileExtensions.GetLastModified(@"C:\Test", -60, "web*");
```

##### Remarks

https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.enumeratefiles?view=net-5.0

<a name='M-FC-Core-Extension-FileHanders-DeleteFilesExtension-DeleteFiles-System-String,System-String-'></a>
### DeleteFiles(folderPath,ext) `method`

##### Summary

Deletes the files with the given extension

##### Returns

Status of deleted files

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| folderPath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Folder path to which the file to be searched |
| ext | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | extension eg. 'cs', 'xlsx', etc |

##### Example

```csharp
string path = @"C:\Temp\test";
path.DeleteFiles("cs"); // Deletes all files with a CS extension
```

<a name='M-FC-Core-Extension-FileHanders-DeleteFilesExtension-SmoothDelete-System-String,System-Int32,System-String,System-String-'></a>
### SmoothDelete(directoryPath,expiryInDays,searchPattern,notContains) `method`

##### Summary

Deletes the List of Files that has not accessed based on the given days.

##### Returns

List of deleted files

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| directoryPath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Directory Path Name |
| expiryInDays | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Days in negative value |
| searchPattern | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | search pattern eg. *.txt, s* |
| notContains | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | skip the folder or file that contains the word or char eg. _t |

##### Example

```csharp
 public void SmoothDeleteFiles_Test()
        {
            string path = @"C:\Test\MiniProfilerDemo";
        string[] folders = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
            foreach (var folder in folders)
            {
                _output.WriteLine($"Folder Name : {folder}");
                foreach(var file in folder.SmoothDelete(-45))
                {
                    _output.WriteLine($"---- Deleted File : {file.FileName}");
                }
}
        }
 
```

##### Remarks

https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.enumeratefiles?view=net-5.0

<a name='T-FC-Core-Extension-FileHanders-DeletedFilesInfo'></a>
## DeletedFilesInfo `type`

##### Namespace

FC.Core.Extension.FileHanders

##### Summary

Delete File helper class to get the details of file status

<a name='P-FC-Core-Extension-FileHanders-DeletedFilesInfo-ExceptionDetail'></a>
### ExceptionDetail `property`

##### Summary

Error information if status is false

<a name='P-FC-Core-Extension-FileHanders-DeletedFilesInfo-FileName'></a>
### FileName `property`

##### Summary

File Name

<a name='P-FC-Core-Extension-FileHanders-DeletedFilesInfo-Status'></a>
### Status `property`

##### Summary

Status false or true

<a name='T-FC-Core-Extension-StringHandlers-EncryptOrDecryptExtension'></a>
## EncryptOrDecryptExtension `type`

##### Namespace

FC.Core.Extension.StringHandlers

##### Summary

Encrypt or Decrypt a string as a extension method. It uses RSA Standard algorithm to do this.

<a name='M-FC-Core-Extension-StringHandlers-EncryptOrDecryptExtension-Decrypt-System-String,System-String-'></a>
### Decrypt(stringToDecrypt,key) `method`

##### Summary

Decryptes a string using the supplied key. Decoding is done using RSA encryption.

##### Returns

The decrypted string or null if decryption failed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| stringToDecrypt | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | String that must be decrypted. |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Decryptionkey. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Occurs when stringToDecrypt or key is null or empty. |

<a name='M-FC-Core-Extension-StringHandlers-EncryptOrDecryptExtension-Encrypt-System-String,System-String-'></a>
### Encrypt(stringToEncrypt,key) `method`

##### Summary

Encryptes a string using the supplied key. Encoding is done using RSA encryption.

##### Returns

A string representing a byte array separated by a minus sign.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| stringToEncrypt | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | String that must be encrypted. |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Encryptionkey. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Occurs when stringToEncrypt or key is null or empty. |

<a name='T-FC-Core-Extension-FileHanders-FileExtensions'></a>
## FileExtensions `type`

##### Namespace

FC.Core.Extension.FileHanders

<a name='M-FC-Core-Extension-FileHanders-FileExtensions-GetFilesByLastModified-System-String,System-Int32,System-String,System-String-'></a>
### GetFilesByLastModified(dirName,days,searchPattern,notContains) `method`

##### Summary

Get the List of Files that has not accessed based on the given days.

##### Returns

List of Files

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dirName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Directory Path Name |
| days | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Days in negative value |
| searchPattern | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | search pattern eg. *.txt, s* |
| notContains | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | skip the folder or file that contains the word or char eg. _t |

##### Example

```csharp
var fileList = FileExtensions.GetLastModified(@"C:\Test", -60, "web*");
```

##### Remarks

https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.enumeratefiles?view=net-5.0

<a name='T-FC-Core-Common-Extension-HashAlgorithms'></a>
## HashAlgorithms `type`

##### Namespace

FC.Core.Common.Extension

##### Summary

Hash Algorithms

<a name='T-FC-Core-Extension-ListHandlers-IEnumerableExtensions'></a>
## IEnumerableExtensions `type`

##### Namespace

FC.Core.Extension.ListHandlers

##### Summary

Extension method for IEnumerable

<a name='T-FC-Core-Extension-ImageHandlers-ImageUtility'></a>
## ImageUtility `type`

##### Namespace

FC.Core.Extension.ImageHandlers

##### Summary

Reads the image from the URL and return as Byte array

<a name='M-FC-Core-Extension-ImageHandlers-ImageUtility-GetImageAsByte-System-String-'></a>
### GetImageAsByte(url) `method`

##### Summary

Reads the image from the URL and return as Byte array

##### Returns

return as byte array

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| url | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | image url |

##### Example

```csharp
byte[] imageArray = ImageAsByte.GetImageAsByte("https://domain.com/file/avatar.png");
```

<a name='T-FC-Core-Extension-NumericHandlers-NumericUtility'></a>
## NumericUtility `type`

##### Namespace

FC.Core.Extension.NumericHandlers

##### Summary

Generats the random number

<a name='M-FC-Core-Extension-NumericHandlers-NumericUtility-GetRandomNumber-System-Int32,System-Int32-'></a>
### GetRandomNumber(min,max) `method`

##### Summary

Generate the random number

##### Returns

returns a random number

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| min | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | min value from where the random number should be picked |
| max | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | maximum value from where the random number should stop |

<a name='T-FC-Core-Extension-GenericHandlers-PropertyEquals'></a>
## PropertyEquals `type`

##### Namespace

FC.Core.Extension.GenericHandlers

<a name='M-FC-Core-Extension-GenericHandlers-PropertyEquals-PublicInstancePropertiesEqual``1-``0,``0,System-String[]-'></a>
### PublicInstancePropertiesEqual\`\`1(self,to,ignore) `method`

##### Summary

Compares the two class property and provides the list of difference

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [\`\`0](#T-``0 '``0') |  |
| to | [\`\`0](#T-``0 '``0') |  |
| ignore | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='T-FC-Core-Extension-StringHandlers-SecureHashExtension'></a>
## SecureHashExtension `type`

##### Namespace

FC.Core.Extension.StringHandlers

##### Summary

Secure Hash - A Class extension to hash the string with various algorithms
Ref: https://emn178.github.io/online-tools/sha256.html

<a name='M-FC-Core-Extension-StringHandlers-SecureHashExtension-SHA256_Hash-System-String-'></a>
### SHA256_Hash(stringToHash) `method`

##### Summary

Uses SHA 256 for hasing

##### Returns

Returns hash value

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| stringToHash | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | string to hash |

<a name='M-FC-Core-Extension-StringHandlers-SecureHashExtension-SHA512_Hash-System-String-'></a>
### SHA512_Hash(stringToHash) `method`

##### Summary

Uses SHA 512 for hasing

##### Returns

Returns hash value

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| stringToHash | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | string to hash |

<a name='M-FC-Core-Extension-StringHandlers-SecureHashExtension-SHA_Hash-System-String,System-Security-Cryptography-HashAlgorithm-'></a>
### SHA_Hash(stringToHash,hashObject) `method`

##### Summary

Uses SHA for hasing

##### Returns

Returns hash value

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| stringToHash | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | string to hash |
| hashObject | [System.Security.Cryptography.HashAlgorithm](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Security.Cryptography.HashAlgorithm 'System.Security.Cryptography.HashAlgorithm') | Algorithm at runtime to hash |

<a name='M-FC-Core-Extension-StringHandlers-SecureHashExtension-SecureHash-System-String,FC-Core-Common-Extension-HashAlgorithms-'></a>
### SecureHash(stringToHash,hashAlgorithms) `method`

##### Summary

Creates the Hash value for the String

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| stringToHash | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | value of string to be hased |
| hashAlgorithms | [FC.Core.Common.Extension.HashAlgorithms](#T-FC-Core-Common-Extension-HashAlgorithms 'FC.Core.Common.Extension.HashAlgorithms') | An Algorithm which is used to Hash |

<a name='T-FC-Core-Extension-DataHandlers-ToDataTableExtension'></a>
## ToDataTableExtension `type`

##### Namespace

FC.Core.Extension.DataHandlers

##### Summary

Convert Model List to DataTable Object

<a name='M-FC-Core-Extension-DataHandlers-ToDataTableExtension-ToDataTable``1-System-Collections-Generic-IList{``0}-'></a>
### ToDataTable\`\`1(items) `method`

##### Summary

Convert List of Model into DataTable

##### Returns

Model list as DataTable

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IList{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList 'System.Collections.Generic.IList{``0}') | List of Model |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Model Type |

##### Example

```csharp
DataTable dtModel = iListModel.ToDataTable();
```

<a name='T-FC-Core-Extension-StringHandlers-ToJsonExtension'></a>
## ToJsonExtension `type`

##### Namespace

FC.Core.Extension.StringHandlers

##### Summary

Converts String into JSON Value

<a name='M-FC-Core-Extension-StringHandlers-ToJsonExtension-ToJSON``1-``0,System-Boolean-'></a>
### ToJSON\`\`1(obj,indent) `method`

##### Summary

Converts the object as a json string
Can be used for logging object contents.

##### Returns

the a string representing the object content

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [\`\`0](#T-``0 '``0') | The object to dump. Can be null |
| indent | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | To indent the result or not |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of the object. |

##### Example

```csharp
string myvalue = "this is the large string";
myvalue.Truncate(7);//will return this...
```

<a name='T-FC-Core-Extension-StringHandlers-ToModelExtension'></a>
## ToModelExtension `type`

##### Namespace

FC.Core.Extension.StringHandlers

##### Summary

Extension class converts String to Model

<a name='M-FC-Core-Extension-StringHandlers-ToModelExtension-ToModel``1-System-String-'></a>
### ToModel\`\`1(stringToDeserialize) `method`

##### Summary

Converts String to Model object

##### Returns

returns model object

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| stringToDeserialize | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | model as json string |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Model Type |

<a name='T-FC-Core-Extension-StringHandlers-ToPasswordHashExtension'></a>
## ToPasswordHashExtension `type`

##### Namespace

FC.Core.Extension.StringHandlers

<a name='M-FC-Core-Extension-StringHandlers-ToPasswordHashExtension-GetSaltAsByte'></a>
### GetSaltAsByte() `method`

##### Summary

Get the salt value, which is used to hash the password.

##### Returns

Returns salt as byte array

##### Parameters

This method has no parameters.

<a name='M-FC-Core-Extension-StringHandlers-ToPasswordHashExtension-GetSaltAsString'></a>
### GetSaltAsString() `method`

##### Summary

Get the salt value, which is used to hash the password.

##### Returns

Returns salt as String value

##### Parameters

This method has no parameters.

<a name='M-FC-Core-Extension-StringHandlers-ToPasswordHashExtension-ToPasswordHash-System-String,System-String-'></a>
### ToPasswordHash(password,saltValue) `method`

##### Summary

Generates the password Hash in a most recommended way using 'KeyDerivation.Pbkdf2' and 'Rfc2898DeriveBytes'

##### Returns

returns PasswordHashInfo

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | string that has to be hased |
| saltValue | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Salt value, if null it will be genereted and returns the salt |

##### Example

```csharp
string myvalue = "this is the large string";
PasswordHashInfo pInfo = myvalue.ToPasswordHash();
var pswd = pInfo.PasswordHash;
var saltArray = pInfo.SaltAsByteArray;
var saltString = pInfo.SaltAsString;
```

<a name='M-FC-Core-Extension-StringHandlers-ToPasswordHashExtension-ToPasswordHash-System-String,System-Byte[]-'></a>
### ToPasswordHash(password,saltValue) `method`

##### Summary

Generates the password Hash in a most recommended way using 'KeyDerivation.Pbkdf2' and 'Rfc2898DeriveBytes'

##### Returns

returns PasswordHashInfo

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | string that has to be hased |
| saltValue | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Salt value, if null it will be genereted and returns the salt |

##### Example

```csharp
string myvalue = "this is the large string";
PasswordHashInfo pInfo = myvalue.ToPasswordHash();
var pswd = pInfo.PasswordHash;
var saltArray = pInfo.SaltAsByteArray;
var saltString = pInfo.SaltAsString;
```

<a name='T-FC-Core-Extension-StringHandlers-ToStreamExtension'></a>
## ToStreamExtension `type`

##### Namespace

FC.Core.Extension.StringHandlers

##### Summary

Extension class which converts string to stream object

<a name='M-FC-Core-Extension-StringHandlers-ToStreamExtension-ToStream-System-String-'></a>
### ToStream(this) `method`

##### Summary

Converts String to Stream Object

##### Returns

returns stream object

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| this | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | string value |

##### Example

```
string value = "MyString";
Stream stream = value.ToStream();
```

<a name='T-FC-Core-Extension-StringHandlers-TruncateExtension'></a>
## TruncateExtension `type`

##### Namespace

FC.Core.Extension.StringHandlers

<a name='M-FC-Core-Extension-StringHandlers-TruncateExtension-Truncate-System-String,System-Int32-'></a>
### Truncate(text,maxLength) `method`

##### Summary

Truncates the string to a specified length and replace the truncated to a ...

##### Returns

truncated string

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | string that will be truncated |
| maxLength | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | total length of characters required as output |

##### Example

```csharp
string myvalue = "this is the large string";
myvalue.Truncate(7);//will return this...
```

<a name='T-FC-Core-Extension-StringHandlers-XMLToModelExtension'></a>
## XMLToModelExtension `type`

##### Namespace

FC.Core.Extension.StringHandlers

##### Summary

Extension class which converts XML Document to Model object

<a name='M-FC-Core-Extension-StringHandlers-XMLToModelExtension-XMLToModel``1-System-String-'></a>
### XMLToModel\`\`1(this) `method`

##### Summary

Converts XML Document to Model object

##### Returns

returns destination object type

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| this | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | xml document as string |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Model type |

##### Example

```
 string xml = File.ReadAllText(@"D:\file.xml");
 var catalog1 = xml.XMLToModel &lt;Model&gt; ();
```
