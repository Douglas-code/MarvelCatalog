using CatalogMarvelApi.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace CatalogMarvelApi.Services
{
    public class MD5HashGenerator : IHashGenerator
    {
        public string Generate(string text)
        {
			MD5 md5 = new MD5CryptoServiceProvider();

			md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

			byte[] result = md5.Hash;

			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < result.Length; i++)
			{
				stringBuilder.Append(result[i].ToString("x2"));
			}

			return stringBuilder.ToString();
		}
    }
}
