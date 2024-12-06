using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agero.Core.DIContainer.Attributes;
using MoviesBE;
using MoviesFE.Views;

namespace MoviesFE.Presenters;

public interface IMovieListPresenter
{
    IMovieListView View { get; }
    void ShowView();
}

public class MovieListPresenter : IMovieListPresenter
{
    public IMovieListView View { get; }

    private readonly IMoviesService _moviesService;
    private IDictionary<string, Movie> _movies;

    [Inject]
    public MovieListPresenter(IMoviesService moviesService, IMovieListView movieListView)
    {
        _moviesService = moviesService;
        View = movieListView;

        movieListView.RefreshList += OnRefreshList;
        movieListView.DeleteClick += OnDeleteClick;
        movieListView.EditClick += OnEditClick;
        movieListView.CreateClick += OnCreateClick;
    }

    public void ShowView()
    {
        View.Show();
    }

    private async void OnCreateClick()
    {
        await EditOrCreate(false, null);
    }

    private async void OnEditClick(string guid)
    {
        await EditOrCreate(true, guid);
    }

    private async Task EditOrCreate(bool edit, string guid)
    {
        var movieEditPresenter = Program.Container.Get<IMovieEditPresenter>();
        MovieEditResult editResult = await movieEditPresenter.ShowView(edit, edit ? _movies[guid] : null);
        if (editResult.Cancelled)
        {
            return;
        }

        View.Form.Enabled = false;

        await Refresh();
        View.SetMovies(_movies);

        View.Form.Enabled = true;
    }
    
    private async void OnDeleteClick(string guid)
    {
        DialogResult dialogResult = MessageBox.Show($"Are you sure you want to delete: {_movies[guid].Title}?", "Delete", MessageBoxButtons.YesNo);
        switch (dialogResult)
        {
            case DialogResult.Yes:
                break;
            default:
                return;
        }

        View.Form.Enabled = false;

        await Delete(guid);
        await Refresh();
        View.SetMovies(_movies);

        View.Form.Enabled = true;
    }

    private async void OnRefreshList()
    {
        View.Form.Enabled = false;

        await Refresh();
        View.SetMovies(_movies);

        View.Form.Enabled = true;
    }

    private async Task Refresh()
    {
        try
        {
            _movies = await _moviesService.GetMoviesAsync();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Error");
        }
    }

    private async Task Delete(string guid)
    {
        try
        {
            await _moviesService.DeleteMovieAsync(Guid.Parse(guid));
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Error");
        }
    }
}
