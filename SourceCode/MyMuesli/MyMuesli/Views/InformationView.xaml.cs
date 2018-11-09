using System.Windows;
using MyMuesli.ViewModel;

namespace MyMuesli.Views
{
    /// <summary>
    ///     Interaction logic for InformationView.xaml
    /// </summary>
    public partial class InformationView
    {
        public InformationView(IngredientViewModel selectedIngredient)
        {
            InitializeComponent();
            DataContext = selectedIngredient;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}