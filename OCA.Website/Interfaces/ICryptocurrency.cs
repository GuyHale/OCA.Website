using OCA.Website.Models;

namespace OCA.Website.Interfaces
{
    public interface ICryptocurrency
    {
        Task<IEnumerable<Cryptocurrency>> Get();
    }
}
