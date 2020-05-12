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
using TPA_Desktop.Factory;
using TPA_Desktop.Mediator;
using TPA_Desktop.Model;

namespace TPA_Desktop.Views.PurchasingD
{
    /// <summary>
    /// Interaction logic for AddPurchaseLogView.xaml
    /// </summary>
    public partial class AddPurchaseLogView : Window
    {
        public AddPurchaseLogView()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            string title = titleTxt.Text.Trim();
            string desc = descTxt.Text.Trim();
            DateTime? purchaseDate = this.purchaseDate.SelectedDate;
            string totalPriceStr = totalPriceTxt.Text.Trim();
            int totalPrice;

            bool success = int.TryParse(totalPriceStr, out totalPrice);
            if (!success)
            {
                errorLbl.Text = "Total price must be a number!";
            }
            else if(title == "" || desc == "" || !purchaseDate.HasValue)
            {
                errorLbl.Text = "Please input all field!";
            }
            else
            {
                PurchaseLogFactory factory = new PurchaseLogFactory();
                PurchaseLogMediator mediator = new PurchaseLogMediator();

                PurchaseLog purchaseLog = mediator.addPurchaseLog(factory.createNewPurchaseLog(title, desc, purchaseDate, totalPrice));

                if(purchaseLog == null)
                {
                    MessageBox.Show("Add purchase log failed!");
                }
                else
                {
                    MessageBox.Show("Add purchase log success!");
                }
                this.Close();
            }
        }
    }
}
