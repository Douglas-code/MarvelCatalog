using CatalogMarvelApi.Interfaces;

namespace HqsApi.Services
{
    public class MD5HashGenerator : IHashGenerator
    {
        public string DecryptHash(string hash)
        {
            return hash;
        }

        public string Generate(string text)
        {
            return text;
        }
    }
}
