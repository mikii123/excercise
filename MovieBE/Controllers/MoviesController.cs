using Microsoft.AspNetCore.Mvc;
using MovieBE.Models;
using MovieBE.Services.Db;

namespace MovieBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieDb _movieDb;
        private readonly ILogger<MoviesController> _logger;

        public MoviesController(ILogger<MoviesController> logger, IMovieDb movieDb)
        {
            _logger = logger;
            _movieDb = movieDb;
        }

        [HttpGet(Name = "GetMovies")]
        public Dictionary<Guid, Movie> Get()
        {
            return _movieDb.GetMovies();
        }

        [HttpPut(Name = "CreateMovie")]
        public IActionResult Put(Movie movie)
        {
            return _movieDb.CreateMovie(movie) ? Ok() : BadRequest();
        }

        [HttpDelete(Name = "DeleteMovie")]
        public IActionResult Delete(Guid guid)
        {
            return _movieDb.DeleteMovie(guid) ? Ok() : BadRequest();
        }

        [HttpPost(Name = "EditMovie")]
        public IActionResult Post(Movie movie)
        {
            return _movieDb.EditMovie(movie) ? Ok() : BadRequest();
        }
    }
}
