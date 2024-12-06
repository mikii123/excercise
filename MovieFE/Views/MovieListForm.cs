using System.Windows.Forms;
using Agero.Core.DIContainer.Attributes;

namespace MoviesFE.Views;

public partial class MovieListForm : Form
{
    [Inject]
    public MovieListForm()
    {
        InitializeComponent();
    }
}
