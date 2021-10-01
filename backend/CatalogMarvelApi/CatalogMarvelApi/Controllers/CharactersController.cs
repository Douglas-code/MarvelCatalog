using CatalogMarvelApi.DataTransferObject;
using CatalogMarvelApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CatalogMarvelApi.Controllers
{
    [Route("v1/characters")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CharactersController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        public CredentialsDataTransferObject Get()
        {
            MD5HashGenerator md5HashGenerator = new MD5HashGenerator();
            MarvelCredentialsService marvelCredentialsService = new MarvelCredentialsService(md5HashGenerator, this._configuration);
            return marvelCredentialsService.GenerateCredentials();
        }
    }
}
