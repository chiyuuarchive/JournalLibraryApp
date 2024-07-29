using JLWPF.MVVM.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace JLWPF.MVVM.Views
{
    /// <summary>
    /// Interaction logic for LibraryView.xaml
    /// </summary>
    public partial class LibraryView : UserControl
    {
        LibraryViewModel _vm;

        public LibraryView()
        {
            InitializeComponent();
        }


        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
                _vm.NavigateToHome();
        }

        private void ArticleDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            if (ArticleDataGrid.Columns.Count > 0)
            {
                ArticleDataGrid.Columns.Last().Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
        }

        private void ArticleDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_vm != null)
                _vm.UpdateSelectedArticle(this);

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is LibraryViewModel)
            {
                _vm = (LibraryViewModel)DataContext;
                if (_vm != null)
                    _vm.InitializeView(this, Window.GetWindow(this));
            }
        }
    }
}
