using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agero.Core.DIContainer.Attributes;
using MoviesBE;
using MoviesFE.Views;

namespace MoviesFE.Presenters;

public interface IMovieEditPresenter
{
    Task<MovieEditResult> ShowView(bool edit = false, Movie movie = null);
}

public class MovieEditResult
{
    public bool Cancelled;
    public Movie Movie;

    public MovieEditResult(bool cancelled, Movie movie)
    {
        Cancelled = cancelled;
        Movie = movie;
    }
}

public class MovieEditPresenter : IMovieEditPresenter
{
    private readonly IMovieEditView _movieEditView;
    private readonly IMoviesService _moviesService;

    [Inject]
    public MovieEditPresenter(IMovieEditView movieEditView, IMoviesService moviesService)
    {
        _movieEditView = movieEditView;
        _moviesService = moviesService;

        movieEditView.Confirm += OnConfirm;
        movieEditView.Cancel += OnCancel;
    }

    public async Task<MovieEditResult> ShowView(bool edit = false, Movie movie = null)
    {
        MovieEditResult editResult = _movieEditView.Show(edit, movie);
        if (editResult.Cancelled)
        {
            return editResult;
        }

        _movieEditView.SetEnabled(false);

        if (edit)
        {
            await Update(editResult.Movie);
        }
        else
        {
            await Create(editResult.Movie);
        }

        _movieEditView.SetEnabled(true);

        return editResult;
    }

    private void OnConfirm(string title, DateTime date)
    {
        ValidationResult result = Validate(title, date);
        if (!result.Title || !result.Date)
        {
            MessageBox.Show($"There were following issues:\n{result.TitleReason}\n{result.DateReason}", "Validation error", MessageBoxButtons.OK);
            return;
        }

        _movieEditView.Close(DialogResult.OK);
    }

    private void OnCancel()
    {
        _movieEditView.Close(DialogResult.Cancel);
    }

    private ValidationResult Validate(string title, DateTime date)
    {
        var validationResult = new ValidationResult();

        if (string.IsNullOrEmpty(title))
        {
            validationResult.Title = false;
            validationResult.TitleReason = "Title is required";
        }
        else if (title.Length > 200)
        {
            validationResult.Title = false;
            validationResult.TitleReason = "Title cannot be longer than 200 characters";
        }

        if (date.Year is < 1900 or > 2200)
        {
            validationResult.Date = false;
            validationResult.DateReason = "Date year must be between 1900 - 2200";
        }

        return validationResult;
    }

    private async Task Update(Movie movie)
    {
        try
        {
            await _moviesService.EditMovieAsync(movie);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Error");
        }
    }

    private async Task Create(Movie movie)
    {
        try
        {
            await _moviesService.CreateMovieAsync(movie);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Error");
        }
    }

    private class ValidationResult
    {
        public bool Title = true;
        public string TitleReason = "";
        public bool Date = true;
        public string DateReason = "";
    }
}
