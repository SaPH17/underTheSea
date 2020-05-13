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

namespace TPA_Desktop.Views.DiningRoomD
{
    /// <summary>
    /// Interaction logic for CheckTicketView.xaml
    /// </summary>
    public partial class CheckTicketView : Window
    {
        public CheckTicketView()
        {
            InitializeComponent();
        }

        private void checkTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            string ticketIDStr = ticketIDTxt.Text.Trim();
            int ticketID;
            bool success = int.TryParse(ticketIDStr, out ticketID);
            if (!success)
            {
                errorLbl.Text = "Ticket ID must be a number";
            }
            else
            {
                TicketMediator mediator = new TicketMediator();
                Ticket ticket = mediator.getTicket(ticketID);
                if(ticket == null)
                {
                    MessageBox.Show("Ticket doesn't exist");
                }
                else
                {
                    if(((DateTime)ticket.dateCreated).Date == DateTime.Now.Date)
                    {
                        MessageBox.Show("Ticket is valid!");
                    }
                    else
                    {
                        MessageBox.Show("Ticket is invalid!");
                    }
                }
            }
        }
    }
}
