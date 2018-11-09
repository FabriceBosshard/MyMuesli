using System.Windows;
using MyMuesli.ViewModel;

namespace MyMuesli.Views
{
    /// <summary>
    ///     Interaction logic for DetailsView.xaml
    /// </summary>
    public partial class DetailsView
    {
        public DetailsView(CerealViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}