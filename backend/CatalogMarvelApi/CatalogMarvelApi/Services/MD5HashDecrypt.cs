using CatalogMarvelApi.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace CatalogMarvelApi.Services
{
    public class MD5HashDecrypt : IHashDecrypt
    {
        public string Decrypt(string hash)
        {
            byte[] data = Convert.FromBase64String(hash);
            string textDecripted;

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripleDESCryptoServiceProvider.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    textDecripted = UTF8Encoding.UTF8.GetString(results);
                }
            }

            return textDecripted;
        }
    }
}
