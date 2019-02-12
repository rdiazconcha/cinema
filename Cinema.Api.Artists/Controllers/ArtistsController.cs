using System;
using System.Threading.Tasks;
using Cinema.Api.Artists.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cinema.Api.Artists.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistsProvider artistsProvider;
        private readonly ILogger<ArtistsController> logger;

        public ArtistsController(IArtistsProvider artistsProvider, ILogger<ArtistsController> logger)
        {
            this.artistsProvider = artistsProvider;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await artistsProvider.GetAllAsync();

                if (result != null)
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.Message);
                return StatusCode(503);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var result = await artistsProvider.GetAsync(id);

                if (result != null)
                {
                    return Ok(result);
                }

                return NotFound(id);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.Message);
                return StatusCode(503);
            }
        }
    }
}