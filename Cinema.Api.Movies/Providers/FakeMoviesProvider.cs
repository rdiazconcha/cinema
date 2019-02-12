using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Api.Movies.Models;

namespace Cinema.Api.Movies.Providers
{
    public class FakeMoviesProvider : IMoviesProvider
    {
        private readonly List<Movie> repo = new List<Movie>();

        public FakeMoviesProvider()
        {
            repo.Add(new Movie() { Id = 1, Name = "The Godfather", Year = 1972 });
            repo.Add(new Movie() { Id = 2, Name = "The Godfather 2", Year = 1974 });
            repo.Add(new Movie() { Id = 3, Name = "Goodfellas", Year = 1990 });
            repo.Add(new Movie() { Id = 4, Name = "Into the wild", Year = 2007 });
            repo.Add(new Movie() { Id = 5, Name = "Whiplash", Year = 2014 });
            repo.Add(new Movie() { Id = 6, Name = "La La Land", Year = 2016 });
            repo.Add(new Movie() { Id = 7, Name = "Three Billboards Outside Ebbing, Missouri", Year = 2017});
        }

        public Task<ICollection<Movie>> GetAllAsync()
        {
            return Task.FromResult((ICollection<Movie>)repo.ToList());
        }

        public Task<Movie> GetAsync(int id)
        {
            return Task.FromResult(repo.FirstOrDefault(m => m.Id == id));
        }
    }
}