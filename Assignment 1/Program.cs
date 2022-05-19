using Assignment_1.Models;


Console.WriteLine("Enter your name : ");
string fullName = Console.ReadLine();

Console.WriteLine("\n=======================StringToBinary======================\n");
BinaryConverter base2 = new BinaryConverter();
string binarydata = base2.StringToBinary(fullName);
base2.BinaryToString(binarydata);

Console.WriteLine("\n=======================Hexadecimal Converter======================\n");
HexadecimalConverter base16 = new HexadecimalConverter();
base16.hexaConverter(fullName);

Console.WriteLine("\n=======================Base64 Converter======================\n");
Base64Converter base64 = new Base64Converter();
base64.Base64Encode(fullName);

string plaintext = fullName;
int encryptionDepth = 15;
Console.WriteLine("\n ======================= encryption decryption ======================\n");
int[] key = plaintext.ToString().Select(o => Convert.ToInt32(o)).ToArray();
for (int i = 0; i < key.Length; i++)
{
    Console.Write(key[i] + "\t");
}
Console.WriteLine("\n\n");
string cipherasString = String.Join(",", key.Select(x => x.ToString())); //For display purposes
//EncryptDecrypt encrypter = new EncryptDecrypt(plaintext, key, encryptionDepth);
EncryptDecrypt encrypter = new EncryptDecrypt(plaintext, key, encryptionDepth);
//Single Level Encrytion
string nameEncryptWithCipher = EncryptDecrypt.EncryptWithCipher(plaintext, key);
Console.WriteLine($"Encrypted once using the cipher {{{cipherasString}}} {nameEncryptWithCipher}");
string nameDecryptWithCipher = EncryptDecrypt.DecryptWithCipher(nameEncryptWithCipher, key);
Console.WriteLine($"Decrypted once using the cipher {{{cipherasString}}} {nameDecryptWithCipher}");
//Deep Encrytion
Console.WriteLine("\n");
string nameDeepEncryptWithCipher = EncryptDecrypt.DeepEncryptWithCipher(plaintext, key, encryptionDepth);
Console.WriteLine($"Deep Encrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepEncryptWithCipher}");
string nameDeepDecryptWithCipher = EncryptDecrypt.DeepDecryptWithCipher(nameDeepEncryptWithCipher, key, encryptionDepth);
Console.WriteLine($"Deep Decrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepDecryptWithCipher}");