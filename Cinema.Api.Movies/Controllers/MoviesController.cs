using System;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Api.Movies.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cinema.Api.Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesProvider moviesProvider;
        private readonly ILogger<MoviesController> logger;

        public MoviesController(IMoviesProvider moviesProvider, ILogger<MoviesController> logger)
        {
            this.moviesProvider = moviesProvider;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await moviesProvider.GetAllAsync();

                if (result != null && result.Any())
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
                var result = await moviesProvider.GetAsync(id);

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