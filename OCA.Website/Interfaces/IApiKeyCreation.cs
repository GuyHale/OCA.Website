namespace OCA.Website.Interfaces
{
    public interface IApiKeyCreation
    {
        Task<ICustomResponse> CreateApiKey(string apiKey);
    }
}
