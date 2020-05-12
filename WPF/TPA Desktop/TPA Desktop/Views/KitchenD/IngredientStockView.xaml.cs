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
using TPA_Desktop.Mediator;
using TPA_Desktop.Views.All;

namespace TPA_Desktop.Views.KitchenD
{
    /// <summary>
    /// Interaction logic for IngredientStockView.xaml
    /// </summary>
    public partial class IngredientStockView : Window
    {
        public IngredientStockView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IngredientStockMediator mediator = new IngredientStockMediator();
            ingredientStockView.ItemsSource = mediator.getAllIngredientStock();
        }

        private void addPurchaseRequestBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddPurchaseRequestView().Show();
        }
    }
}
