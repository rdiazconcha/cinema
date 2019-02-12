using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Api.Artists.Models;

namespace Cinema.Api.Artists.Providers
{
    public interface IArtistsProvider
    {
        Task<ICollection<Artist>> GetAllAsync();

        Task<Artist> GetAsync(int id);
    }
}