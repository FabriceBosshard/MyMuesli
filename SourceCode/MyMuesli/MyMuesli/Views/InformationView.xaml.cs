using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MyMuesli.ViewModel;

namespace MyMuesli.Views
{
    /// <summary>
    /// Interaction logic for InformationView.xaml
    /// </summary>
    public partial class InformationView : Window
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
