namespace CatalogMarvelApi.Interfaces
{
    public interface IHashGenerator
    {
        string Generate(string text);
        string DecryptHash(string hash);
    }
}
