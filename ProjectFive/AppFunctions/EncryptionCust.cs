﻿using System.Security.Cryptography;
using System.Text;

namespace ProjectFive.AppFunctions
{
    public static class EncryptionCust
    {
        private static byte[] keyAndIvBytes;

        static void EncryptionHelper()
        {
            keyAndIvBytes = UTF8Encoding.UTF8.GetBytes("tR7nR6wZHGjYMCuV");
        }

        public static string ByteArrayToHexString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public static string DecodeAndDecrypt(string cipherText)
        {
            EncryptionHelper();
            string DecodeAndDecrypt = AesDecrypt(StringToByteArray(cipherText));
            return (DecodeAndDecrypt);
        }

        public static string EncryptAndEncode(string plaintext)
        {
            EncryptionHelper();
            return ByteArrayToHexString(AesEncrypt(plaintext));
        }

        public static string AesDecrypt(Byte[] inputBytes)
        {
            Byte[] outputBytes = inputBytes;

            string plaintext = string.Empty;

            using (MemoryStream memoryStream = new MemoryStream(outputBytes))
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, GetCryptoAlgorithm().CreateDecryptor(keyAndIvBytes, keyAndIvBytes), CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(cryptoStream))
                    {
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }

            return plaintext;
        }

        public static byte[] AesEncrypt(string inputText)
        {
            byte[] inputBytes = UTF8Encoding.UTF8.GetBytes(inputText);//AbHLlc5uLone0D1q

            byte[] result = null;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, GetCryptoAlgorithm().CreateEncryptor(keyAndIvBytes, keyAndIvBytes), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(inputBytes, 0, inputBytes.Length);
                    cryptoStream.FlushFinalBlock();

                    result = memoryStream.ToArray();
                }
            }

            return result;
        }


        private static RijndaelManaged GetCryptoAlgorithm()
        {
            RijndaelManaged algorithm = new RijndaelManaged();
            //set the mode, padding and block size
            algorithm.Padding = PaddingMode.PKCS7;
            algorithm.Mode = CipherMode.CBC;
            algorithm.KeySize = 128;
            algorithm.BlockSize = 128;
            return algorithm;
        }

    }
}

