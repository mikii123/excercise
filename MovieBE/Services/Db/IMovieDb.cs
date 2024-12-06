using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieBE.Models;

namespace MovieBE.Services.Db
{
    public interface IMovieDb
    {
        Dictionary<Guid, Movie> GetMovies();
        bool CreateMovie(Movie movie);
        bool EditMovie(Movie movie);
        bool DeleteMovie(Guid id);
    }
}