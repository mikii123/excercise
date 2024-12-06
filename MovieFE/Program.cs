using System;
using System.Windows.Forms;
using Agero.Core.DIContainer;
using MoviesBE;
using MoviesFE.Presenters;
using MoviesFE.Views;

namespace MoviesFE
{
    internal static class Program
    {
        public static IContainer Container;
        
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Container = ContainerFactory.Create();

            // services
            Container.RegisterImplementation<IMoviesService, MoviesService>(Lifetime.PerContainer);

            // views & presenters
            Container.RegisterImplementation<IMovieListView, MovieListView>();
            Container.RegisterImplementation<IMovieListPresenter, MovieListPresenter>();
            Container.RegisterImplementation<IMovieEditView, MovieEditView>();
            Container.RegisterImplementation<IMovieEditPresenter, MovieEditPresenter>();

            var movieListPresenter = Container.Get<IMovieListPresenter>();
            Application.Run(movieListPresenter.View.Form);
        }
    }
}
