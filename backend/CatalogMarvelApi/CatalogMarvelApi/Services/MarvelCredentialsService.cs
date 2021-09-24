using CatalogMarvelApi.DataTransferObject;
using CatalogMarvelApi.Interfaces;
using Microsoft.Extensions.Configuration;
using System;

namespace CatalogMarvelApi.Services
{
    public class MarvelCredentialsService
    {
        private readonly IHashGenerator _hashGenerator;
        private readonly IConfiguration _configuration;

        public MarvelCredentialsService(IHashGenerator hashGenerator)
        {
            this._hashGenerator = hashGenerator;
        }

        public CredentialsDataTransferObject GenerateCredentials(string text)
        {
            string apiKey = _hashGenerator.DecryptHash(_configuration.GetSection("MarvelApi")["publicKey"]);
            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            string hash = _hashGenerator.Generate(text);

            return new CredentialsDataTransferObject(timeStamp, apiKey, hash);
        }
    }
}
