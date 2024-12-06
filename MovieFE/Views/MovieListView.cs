using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Agero.Core.DIContainer.Attributes;
using MoviesBE;

namespace MoviesFE.Views;

public interface IMovieListView
{
    // had to do this to use it in Application.Run()
    Form Form { get; }

    event Action RefreshList;
    event Action<string> DeleteClick;
    event Action<string> EditClick;
    event Action CreateClick;

    void Show();
    void SetMovies(IDictionary<string, Movie> movies);
}

public class MovieListView : IMovieListView
{
    public event Action RefreshList;
    public event Action<string> DeleteClick;
    public event Action<string> EditClick;
    public event Action CreateClick;

    Form IMovieListView.Form => _form;

    private MovieListForm _form;
    private IList<Movie> _movies;

    [Inject]
    public MovieListView()
    {
        _form = new MovieListForm();
        SetMovies(null);
        _form.Shown += (_, _) => RefreshList?.Invoke();
        _form.listBox.SelectedIndexChanged += OnSelectedIndexChanged;
        _form.deleteButton.Click += DeleteButtonOnClick;
        _form.editButton.Click += EditButtonOnClick;
        _form.createButton.Click += CreateButtonOnClick;
    }

    public void Show()
    {
        _form.Show();
    }

    public void SetMovies(IDictionary<string, Movie> movies)
    {
        ListBox.ObjectCollection items = _form.listBox.Items;
        items.Clear();

        if (movies is not { Count: > 0 })
        {
            items.Add("No items");
        }
        else
        {
            _movies = movies.Values.ToList();
            items.AddRange(_movies.Select(movie => movie.Title).ToArray());
            OnSelectedIndexChanged(null, null);
        }
    }

    private void CreateButtonOnClick(object sender, EventArgs e)
    {
        CreateClick?.Invoke();
    }

    private void EditButtonOnClick(object sender, EventArgs e)
    {
        EditClick?.Invoke(_movies[_form.listBox.SelectedIndex].Id.ToString());
    }

    private void DeleteButtonOnClick(object sender, EventArgs e)
    {
        DeleteClick?.Invoke(_movies[_form.listBox.SelectedIndex].Id.ToString());
    }

    private void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (_movies == null || _form.listBox.SelectedIndex < 0 || _form.listBox.SelectedIndex > _movies.Count)
        {
            return;
        }

        Movie selected = _movies[_form.listBox.SelectedIndex];
        _form.titleLabel.Text = selected.Title;
        _form.dateLabel.Text = selected.ReleaseDate.ToString();
        _form.descriptionLabel.Text = selected.Description;
    }
}
