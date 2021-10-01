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

        public MarvelCredentialsService(IHashGenerator hashGenerator, IConfiguration configuration)
        {
            this._hashGenerator = hashGenerator;
            this._configuration = configuration;
        }

        public CredentialsDataTransferObject GenerateCredentials()
        {
            string apiKey = _configuration.GetSection("MarvelApi")["publicKey"];
            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            string privateKey = _configuration.GetSection("MarvelApi")["privateKey"];
            string hash = this._hashGenerator.Generate(timeStamp + privateKey + apiKey);

            return new CredentialsDataTransferObject(timeStamp, apiKey, hash);
        }
    }
}
