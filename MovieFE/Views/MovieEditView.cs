using System;
using System.Windows.Forms;
using Agero.Core.DIContainer.Attributes;
using MoviesBE;
using MoviesFE.Presenters;

namespace MoviesFE.Views;

public interface IMovieEditView
{
    event Action<string, DateTime> Confirm;
    event Action Cancel;

    MovieEditResult Show(bool edit = false, Movie movie = null);
    void SetEnabled(bool value);
    void Close(DialogResult result);
}

public class MovieEditView : IMovieEditView
{
    public event Action<string, DateTime> Confirm;
    public event Action Cancel;
    
    private MovieEditForm _movieEditForm;

    [Inject]
    public MovieEditView()
    {
        _movieEditForm = new MovieEditForm();
        _movieEditForm.confirmButton.Click += ConfirmButtonOnClick;
        _movieEditForm.cancelButton.Click += CancelButtonOnClick;
    }

    public MovieEditResult Show(bool edit = false, Movie movie = null)
    {
        if (edit)
        {
            _movieEditForm.titleTextBox.Text = movie.Title;
            _movieEditForm.descriptionTextBox.Text = movie.Description;
            _movieEditForm.releaseDateTimePicker.Value = movie.ReleaseDate.Date;
        }

        DialogResult dialogResult = _movieEditForm.ShowDialog();
        switch (dialogResult)
        {
            case DialogResult.OK:
            case DialogResult.Yes:
                break;
            default:
                return new MovieEditResult(true, null);
        }

        return new MovieEditResult(
            false,
            new Movie
            {
                Id = edit ? movie.Id : Guid.NewGuid(),
                Title = _movieEditForm.titleTextBox.Text,
                ReleaseDate = _movieEditForm.releaseDateTimePicker.Value,
                Description = _movieEditForm.descriptionTextBox.Text
            });
    }

    public void SetEnabled(bool value)
    {
        _movieEditForm.Enabled = value;
    }

    public void Close(DialogResult result)
    {
        _movieEditForm.DialogResult = result;
        _movieEditForm.Close();
    }

    private void ConfirmButtonOnClick(object sender, EventArgs e)
    {
        Confirm?.Invoke(_movieEditForm.titleTextBox.Text, _movieEditForm.releaseDateTimePicker.Value);
    }

    private void CancelButtonOnClick(object sender, EventArgs e)
    {
        Cancel?.Invoke();
    }
}
