using CatalogMarvelApi.DataTransferObject;
using CatalogMarvelApi.Interfaces;
using Microsoft.Extensions.Configuration;
using System;

namespace CatalogMarvelApi.Services
{
    public class MarvelCredentialsService
    {
        private readonly IHashEncrypt _hashEncrypt;
        private readonly IConfiguration _configuration;
        private readonly IHashDecrypt _hashDecrypt;

        public MarvelCredentialsService(IHashEncrypt hashEncrypt, IConfiguration configuration, IHashDecrypt hashDecrypt)
        {
            this._hashEncrypt = hashEncrypt;
            this._configuration = configuration;
            this._hashDecrypt = hashDecrypt;
        }

        public CredentialsDataTransferObject GenerateCredentials(string text)
        {
            string apiKey = _hashDecrypt.Decrypt(_configuration.GetSection("MarvelApi")["publicKey"]);
            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            string hash = _hashEncrypt.Encrypt(text);

            return new CredentialsDataTransferObject(timeStamp, apiKey, hash);
        }
    }
}
