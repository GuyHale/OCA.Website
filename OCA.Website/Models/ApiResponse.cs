namespace OCA.Website.Models
{
    public sealed class ApiResponse
    {
        public IEnumerable<Cryptocurrency> Cryptocurrencies { get; set; } = Enumerable.Empty<Cryptocurrency>();
        public string RequestError { get; set; } = string.Empty;
        public bool IsValid { get; set; } = false;
        public int RequestStatusCode { get; set; }       
    }
}
