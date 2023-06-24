using OCA.Website.Interfaces;

namespace OCA.Website.Models
{
    public class ApiKeyCreationResponse : ICustomResponse
    {
        public bool Success { get; set; }
        public IEnumerable<string> ErrorMessages { get; set; } = Enumerable.Empty<string>();
    }
}
