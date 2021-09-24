using CatalogMarvelApi.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace HqsApi.Services
{
    public class MD5HashEncrypt : IHashEncrypt
    {
        public string Encrypt(string text)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(text);
            string textEncrypted;

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(text));
                using (TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripleDESCryptoServiceProvider.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    textEncrypted = Convert.ToBase64String(results, 0, results.Length);
                }
            }

            return textEncrypted;
        }
    }
}
