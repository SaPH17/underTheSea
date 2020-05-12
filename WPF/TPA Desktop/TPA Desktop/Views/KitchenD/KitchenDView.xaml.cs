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
using TPA_Desktop.Views.All;

namespace TPA_Desktop.Views.KitchenD
{
    /// <summary>
    /// Interaction logic for KitchenD.xaml
    /// </summary>
    public partial class KitchenDView : Window
    {
        public KitchenDView()
        {
            InitializeComponent();
            Biodata.Content = new BiodataView();
        }

        private void viewOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            new OrderView().Show();
        }

        private void viewIngredientStockBtn_Click(object sender, RoutedEventArgs e)
        {
            new IngredientStockView().Show();
        }

        private void viewRequestResponseBtn_Click(object sender, RoutedEventArgs e)
        {
            new RequestResponseView().Show();
        }
    }
}
