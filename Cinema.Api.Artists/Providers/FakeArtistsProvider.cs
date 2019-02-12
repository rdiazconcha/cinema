using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Api.Artists.Models;

namespace Cinema.Api.Artists.Providers
{
    public class FakeArtistsProvider : IArtistsProvider
    {
        private readonly List<Artist> repo = new List<Artist>();

        public FakeArtistsProvider()
        {
            repo.Add(new Artist() { Id = 1, Name = "Al Pacino" });
            repo.Add(new Artist() { Id = 2, Name = "Robert De Niro" });
            repo.Add(new Artist() { Id = 3, Name = "Marlon Brando" });
            repo.Add(new Artist() { Id = 4, Name = "Diane Keaton" });
            repo.Add(new Artist() { Id = 5, Name = "Joe Pesci" });
            repo.Add(new Artist() { Id = 6, Name = "Lorraine Bracco" });
            repo.Add(new Artist() { Id = 7, Name = "Sean Penn" });
            repo.Add(new Artist() { Id = 8, Name = "Emile Hirsch" });
            repo.Add(new Artist() { Id = 9, Name = "Miles Teller" });
            repo.Add(new Artist() { Id = 10, Name = "Melissa Benoist" });
            repo.Add(new Artist() { Id = 11, Name = "Damien Chazelle" });
            repo.Add(new Artist() { Id = 12, Name = "Frances McDormand" });
            repo.Add(new Artist() { Id = 13, Name = "Emma Stone" });
        }

        public Task<ICollection<Artist>> GetAllAsync()
        {
            return Task.FromResult((ICollection<Artist>)repo.ToList());
        }

        public Task<Artist> GetAsync(int id)
        {
            return Task.FromResult(repo.FirstOrDefault(a => a.Id == id));
        }
    }
}