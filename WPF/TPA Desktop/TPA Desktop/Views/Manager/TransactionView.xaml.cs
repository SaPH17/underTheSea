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
using TPA_Desktop.Model;

namespace TPA_Desktop.Views.Manager
{
    /// <summary>
    /// Interaction logic for TransactionView.xaml
    /// </summary>
    public partial class TransactionView : Window
    {
        public TransactionView()
        {
            InitializeComponent();
            transactionIDTxt.Visibility = Visibility.Hidden;
            transactionIDLbl.Visibility = Visibility.Hidden;
            transactionDetailView.Visibility = Visibility.Hidden;
        }

        private void viewHotelIncomeBtn_Click(object sender, RoutedEventArgs e)
        {
            HotelTransactionMediator mediator = new HotelTransactionMediator();
            transactionView.ItemsSource = mediator.getAllHotelTransaction();
            totalIncomeLbl.Text = "Total Income = Rp. " + mediator.getHotelIncome().ToString();


            transactionIDTxt.Visibility = Visibility.Hidden;
            transactionIDLbl.Visibility = Visibility.Hidden;
            transactionDetailView.Visibility = Visibility.Hidden;

        }

        private void viewRestaurantIncomeBtn_Click(object sender, RoutedEventArgs e)
        {
            RestaurantTransactionMediator mediator = new RestaurantTransactionMediator();
            transactionView.ItemsSource = mediator.getAllRestaurantTransaction();
            totalIncomeLbl.Text = "Total Income = Rp. " + mediator.getRestaurantIncome().ToString();

            transactionIDTxt.Visibility = Visibility.Visible;
            transactionIDLbl.Visibility = Visibility.Visible;
            transactionDetailView.Visibility = Visibility.Visible;
        }

        private void viewTicketIncomeBtn_Click(object sender, RoutedEventArgs e)
        {

            int ticketPrice = 1000;

            TicketTransactionMediator mediator = new TicketTransactionMediator();
            List<TicketTransaction> transactionList = mediator.getAllTicketTransaction();
            totalIncomeLbl.Text = "Total Income = Rp. " + (transactionList.Count * ticketPrice).ToString();
            transactionView.ItemsSource = transactionList;
            transactionIDTxt.Visibility = Visibility.Hidden;
            transactionIDLbl.Visibility = Visibility.Hidden;
            transactionDetailView.Visibility = Visibility.Hidden;
        }

        private void transactionIDTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            string transactionIDStr = transactionIDTxt.Text.Trim();
            int transactionID;

            bool success = int.TryParse(transactionIDStr, out transactionID);
            if (!success && transactionIDTxt.Text != "")
            {
                errorLbl.Text = "Transaction ID is not a number";
            }
            else
            {
                errorLbl.Text = "";
                RestaurantTransactionMediator mediator = new RestaurantTransactionMediator();
                if (mediator.getAllDetailRestaurantTransaction(transactionID) == null)
                {
                    transactionDetailView.ItemsSource = null;
                    return;
                }
                transactionDetailView.ItemsSource = mediator.getAllDetailRestaurantTransaction(transactionID);
            }
        }
    }
}
