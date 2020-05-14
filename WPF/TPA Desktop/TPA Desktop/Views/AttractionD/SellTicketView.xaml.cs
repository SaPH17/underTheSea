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

namespace TPA_Desktop.Views.AttractionD
{
    /// <summary>
    /// Interaction logic for SellTicketView.xaml
    /// </summary>
    public partial class SellTicketView : Window
    {
        public SellTicketView()
        {
            InitializeComponent();
            nextBarcodeBtn.Visibility = Visibility.Hidden;
        }

        int totalPrice;
        int quantity;
        List<Ticket> ticketList;
        int counter = 0;
        QRCode qr;

        private void buyTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            string quantityStr = quantityTxt.Text.Trim();

            bool success = int.TryParse(quantityStr, out quantity);
            if (!success)
            {
                errorLbl.Text = "Quantity must be a number!";
            }
            else
            {
                totalPrice = quantity * 1000;
                totalPriceLbl.Text = "Total Price = \t\tRp. " + totalPrice.ToString();
            }
        }

        private void inputPaymentBtn_Click(object sender, RoutedEventArgs e)
        {
            string paymentStr = paymentTxt.Text.Trim();
            int payment;

            bool success = int.TryParse(paymentStr, out payment);
            if (!success)
            {
                errorLbl.Text = "Payment must be a number!";
            }
            else
            {
                int change = totalPrice - payment;
                if(change > 0)
                {
                    errorLbl.Text = "Payment is not enough!";
                }
                else
                {
                    TicketMediator mediator = new TicketMediator();
                    TicketFactory factory = new TicketFactory();

                    changeLbl.Text = "Change = \t\tRp. " + Math.Abs(change).ToString();

                    ticketList = new List<Ticket>();

                    for(int i = 0; i < quantity; i++)
                    {
                        ticketList.Add(mediator.addTicket(factory.generateTicket()));
                    }

                    TicketTransactionMediator tmediator = new TicketTransactionMediator();
                    TicketTransactionFactory tfactory = new TicketTransactionFactory();

                    foreach(Ticket ticket in ticketList)
                    {
                        TicketTransaction transaction = tmediator.addTicketTransaction(tfactory.createNewTicketTransaction(ticket.ticketID));
                        if(transaction == null)
                        {
                            MessageBox.Show("Buy ticket failed!");
                            return;
                        }
                    }

                    MessageBox.Show("Buy ticket success!");
                    nextBarcodeBtn.Visibility = Visibility.Visible;
                    qr = new QRCode(ticketList.ElementAt(counter));
                    qr.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    qr.Show();
                }
            }
        
        }

        private void nextBarcodeBtn_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            if(counter == quantity)
            {
                counter = 0;
            }
            qr.Close();
            qr = new QRCode(ticketList.ElementAt(counter));
            qr.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            qr.Show();
        }
    }
}
