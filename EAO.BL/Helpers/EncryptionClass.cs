
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
//using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace EAO.BL.Helpers
{
    public class EncryptionClass
    {
         static string  key = "b14ca5898a4e4133c2ce2ea2315a1916";
        public static string EncryptAesManaged(string raw)
        {
            try
            {
                // Create Aes that generates a new key and initialization vector (IV).    
                // Same key must be used in encryption and decryption    
                using (AesManaged aes = new AesManaged())
                {
                    // Encrypt string    
                    byte[] encrypted = Encrypt(raw, aes.Key, aes.IV);
                    // Print encrypted string    
                    // Console.WriteLine($ "Encrypted data: {System.Text.Encoding.UTF8.GetString(encrypted)}");
                    // Decrypt the bytes to a string. 
                    /* for decrypt*/
                    //string decrypted = Decrypt(encrypted, aes.Key, aes.IV);
                    // Print decrypted string. It should be same as raw data    
                    // Console.WriteLine($ "Decrypted data: {decrypted}");
                    string bitString = BitConverter.ToString(encrypted);
                    return bitString;
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                return "";
            }
            // Console.ReadKey();
        }
        public static IEnumerable<byte> GetBytesFromByteString(string s)
        {
            for (int index = 0; index < s.Length; index += 2)
            {
                yield return Convert.ToByte(s.Substring(index, 2), 16);
            }
        }
        public static string DecryptAesManaged(string raw)
        {
            try
            {
                // Create Aes that generates a new key and initialization vector (IV).    
                // Same key must be used in encryption and decryption    
                using (AesManaged aes = new AesManaged())
                {
                    // Encrypt string    
                    UTF8Encoding utf8Encoder = new UTF8Encoding();
                    //byte[] rawByte = utf8Encoder.GetBytes(raw);
                    //byte[] cipherTextBytes = Convert.FromBase64String(raw.Replace(" ", "-"));
                    //var bytes = GetBytesFromByteString(raw).ToArray();
                    //byte[] result = Convert.FromBase64String(raw);
                    //byte[] rawByte = raw.Split('-').Select(s => Convert.ToByte(s, 16)).ToArray();
                    //byte[] rawByte = SoapHexBinary.Parse(raw.Replace("-", " ")).Value;
                     byte[] rawByte = StrToByteArray(raw);

                    
                    // Print encrypted string    
                    // Console.WriteLine($ "Encrypted data: {System.Text.Encoding.UTF8.GetString(encrypted)}");
                    // Decrypt the bytes to a string. 
                    /* for decrypt*/
                    //byte[] encrypted = Encrypt(raw, aes.Key, aes.IV);
                    string decrypted = Decrypt(rawByte, aes.Key, aes.IV);
                    // Print decrypted string. It should be same as raw data    
                    // Console.WriteLine($ "Decrypted data: {decrypted}");
                    //string bitString = BitConverter.ToString(encrypted);
                    return decrypted;
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                return "";
            }
            // Console.ReadKey();
        }
        public static byte[] StrToByteArray(string str)
        {
            if (str.Length == 0)
                throw new Exception("Invalid string value in StrToByteArray");

            byte val;
            byte[] byteArr = new byte[str.Length / 3];
            int i = 0;
            int j = 0;
            do
            {
                val = byte.Parse(str.Substring(i, 3));
                byteArr[j++] = val;
                i += 3;
            }
            while (i < str.Length);
            return byteArr;
        }
        public static string DecryptTwoWay(string strEncrypted)
        {
            string roundtrip = null;
            UnicodeEncoding textConverter = new UnicodeEncoding();
            RijndaelManaged myRijndael = new RijndaelManaged();
            byte[] fromEncrypt = null;
            byte[] encrypted = new byte[129];
            Encoding unicode = Encoding.Unicode;
            string strEnc = null;
            byte[] Key = { 0x5, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8, 0x9, 0xa,
            0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
            byte[] IV = { 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8, 0x9, 0xa,
            0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
            strEnc = strEncrypted;
            int i = 0;



            byte[] encrypted8 = new byte[strEnc.Length / 3];
            string strDigit = null;

            i = 0;
            while (i < strEnc.Length)
            {
                strDigit = strEnc.Substring(i, 3);
                encrypted8[i / 3] = Convert.ToByte(Convert.ToInt16(strDigit));

                i += 3;
            }

            encrypted = encrypted8;
            ICryptoTransform decryptor = myRijndael.CreateDecryptor(Key, IV);
            MemoryStream msDecrypt = new MemoryStream(encrypted);
            CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);

            fromEncrypt = new byte[encrypted.Length + 1];
            csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);
            roundtrip = textConverter.GetString(fromEncrypt);
            string rt = "";
            int intLen = roundtrip.Length - 1;
            while ((int)(char.Parse(roundtrip.Substring(intLen - 1, 1))) == 0)
            {
                intLen -= 1;
            }
            rt = roundtrip.Substring(0, intLen);
            return rt;
        }
        public static byte[] Encrypt(string plainText, byte[] Key, byte[] IV)
        {
            byte[] encrypted;
            // Create a new AesManaged.    
            using (AesManaged aes = new AesManaged())
            {
                // Create encryptor    
                ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
                // Create MemoryStream    
                using (MemoryStream ms = new MemoryStream())
                {
                    // Create crypto stream using the CryptoStream class. This class is the key to encryption    
                    // and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream    
                    // to encrypt    
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        // Create StreamWriter and write data to a stream    
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(plainText);
                        encrypted = ms.ToArray();
                    }
                }
            }
            // Return encrypted data    
            return encrypted;
        }
        static string Decrypt(byte[] cipherText, byte[] Key, byte[] IV)
        {
            string plaintext = null;
            // Create AesManaged    
            using (AesManaged aes = new AesManaged())
            {
                // Create a decryptor    
                ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);
                // Create the streams used for decryption.    
                using (MemoryStream ms = new MemoryStream(cipherText))
                {
                    // Create crypto stream    
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        // Read crypto stream    
                        //cs.Write(cipherText, 0, cipherText.Length);
                        using (StreamReader reader = new StreamReader(cs))
                            plaintext = reader.ReadToEnd();
                    }
                }
            }
            return plaintext;
        }
       public static string Decrypt1(byte[] cipherText1, byte[] Key, byte[] IV)
        {
            using (Aes aes = new AesManaged())
            {
                aes.Padding = PaddingMode.PKCS7;
                aes.KeySize = 128;          // in bits
                aes.Key = new byte[128 / 8];  // 16 bytes for 128 bit encryption
                aes.IV = new byte[128 / 8];   // AES needs a 16-byte IV
                                              // Should set Key and IV here.  Good approach: derive them from 
                                              // a password via Cryptography.Rfc2898DeriveBytes 
                byte[] cipherText = null;
                byte[] plainText = null;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherText1, 0, cipherText1.Length);
                    }

                    cipherText = ms.ToArray();
                }


                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherText, 0, cipherText.Length);
                    }

                    plainText = ms.ToArray();
                }
                string s = System.Text.Encoding.Unicode.GetString(plainText);
                return s;
            }
            }



        #region My Decrption
         
        public static string DecryptString( string cipherText)
        {
           
            try
            {
                byte[] iv = new byte[16];
                byte[] buffer = Convert.FromBase64String(cipherText);
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = iv;
                    aes.Padding = PaddingMode.PKCS7; // For remove Padding and empty space 
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                            {
                                return streamReader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                return string.Empty;
            }
        }



        #endregion

        public static string EncryptString( string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

    
    }

    }
