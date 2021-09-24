using CatalogMarvelApi.Interfaces;

namespace HqsApi.Services
{
    public class MD5HashGenerator : IHashGenerator
    {
        public string Generate(string text)
        {
            return text;
        }
    }
}
