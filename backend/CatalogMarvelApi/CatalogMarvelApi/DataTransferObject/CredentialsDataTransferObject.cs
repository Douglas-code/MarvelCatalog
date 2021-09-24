namespace CatalogMarvelApi.DataTransferObject
{
    public class CredentialsDataTransferObject
    {
        public CredentialsDataTransferObject(string timeStamp, string apiKey, string hash)
        {
            this.TimeStamp = timeStamp;
            this.ApiKey = apiKey;
            this.Hash = hash;
        }

        public string TimeStamp { get; private set; }

        public string ApiKey { get; private set; }

        public string Hash { get; private set; }
    }
}
