using MovieBE.Models;

namespace MovieBE.Services.Db;

public class MockMovieDb : IMovieDb
{
    private Dictionary<Guid, Movie> _movieList;

    public MockMovieDb()
    {
        _movieList = new Dictionary<Guid, Movie>();
        var guid = Guid.NewGuid();
        _movieList.Add(guid, new Movie(guid, "Matrix", "A cool movie about guns and stuff.", DateTime.Parse("1999-03-31")));
        guid = Guid.NewGuid();
        _movieList.Add(guid, new Movie(guid, "Oppenheimer", "Oppenheimer is a 2023 biographical film written, produced, and directed by Christopher Nolan.", DateTime.Parse("2023-07-21")));
        guid = Guid.NewGuid();
        _movieList.Add(guid, new Movie(guid, "Joker", "Forever alone in a crowd, failed comedian Arthur Fleck seeks connection as he walks the streets of Gotham City.", DateTime.Parse("2019-08-28")));
    }

    public bool CreateMovie(Movie movie)
    {
        movie.Id = Guid.NewGuid();
        _movieList.Add(movie.Id, movie);

        return true;
    }

    public bool DeleteMovie(Guid id)
    {
        if (!_movieList.ContainsKey(id))
        {
            return false;
        }

        _movieList.Remove(id);
        return true;
    }

    public bool EditMovie(Movie movie)
    {
        if (!_movieList.ContainsKey(movie.Id))
        {
            return false;
        }

        _movieList[movie.Id] = movie;
        return true;
    }

    public Dictionary<Guid, Movie> GetMovies()
    {
        return _movieList;
    }
}
