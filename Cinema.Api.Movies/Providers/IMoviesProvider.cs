using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Api.Movies.Models;

namespace Cinema.Api.Movies.Providers
{
    public interface IMoviesProvider
    {
        Task<ICollection<Movie>> GetAllAsync();

        Task<Movie> GetAsync(int id);
    }
}