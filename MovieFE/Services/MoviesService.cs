using System.Net.Http;
using Agero.Core.DIContainer.Attributes;

namespace MoviesBE
{
    public partial class MoviesService : IMoviesService
    {
        [Inject]
        public MoviesService()
        {
            BaseUrl = "http://localhost:12137";
            _httpClient = new HttpClient();
            _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(CreateSerializerSettings);
        }
    }

    public interface IMoviesService
    {
        /// <returns>OK</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Collections.Generic.IDictionary<string, Movie>> GetMoviesAsync();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>OK</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Collections.Generic.IDictionary<string, Movie>> GetMoviesAsync(System.Threading.CancellationToken cancellationToken);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task CreateMovieAsync(Movie body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>OK</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task CreateMovieAsync(Movie body, System.Threading.CancellationToken cancellationToken);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task DeleteMovieAsync(System.Guid? guid);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>OK</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task DeleteMovieAsync(System.Guid? guid, System.Threading.CancellationToken cancellationToken);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task EditMovieAsync(Movie body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>OK</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task EditMovieAsync(Movie body, System.Threading.CancellationToken cancellationToken);
    }
}
