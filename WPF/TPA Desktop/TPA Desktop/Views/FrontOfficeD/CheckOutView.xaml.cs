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

namespace TPA_Desktop.Views.FrontOfficeD
{
    /// <summary>
    /// Interaction logic for CheckOutView.xaml
    /// </summary>
    public partial class CheckOutView : Window
    {
        int totalPrice;
        public CheckOutView()
        {
            InitializeComponent();
        }

        private void checkOutBtn_Click(object sender, RoutedEventArgs e)
        {
            string reservationIDStr = reservationIDTxt.Text.Trim();
            string damageCostStr = damageCostTxt.Text.Trim();
            string paymentStr = paymentTxt.Text.Trim();
            int reservationID, damageCost, payment;

            bool success = int.TryParse(reservationIDStr, out reservationID);
            bool success2 = int.TryParse(damageCostStr, out damageCost);
            bool success3 = int.TryParse(paymentStr, out payment);
            if (!success || !success2 || !success3)
            {
                errorLbl.Text = "Reservation ID, Damage Cost, Payment must be a number!";
            }
            else if(DateTime.Now.Hour >= 8)
            {
                errorLbl.Text = "Check out time is 8 AM";
            }
            else
            {
                int change = totalPrice - payment;
                if(change > 0)
                {
                    errorLbl.Text = "Payment is not enough!";
                }
                else if(change <= 0)
                {
                    HotelTransactionMediator mediator = new HotelTransactionMediator();
                    RoomMediator romediator = new RoomMediator();
                    ReservationMediator rmediator = new ReservationMediator();
                    HotelTransactionFactory factory = new HotelTransactionFactory();

                    changeLbl.Text = "Change = Rp. " +  Math.Abs(change).ToString();

                    Reservation reservation = rmediator.getReservation(reservationID);
                    HotelTransaction transaction = mediator.addHotelTransaction(factory.createNewHotelTransaction((int)reservation.customerID, (int)reservation.roomID, reservation.checkInDate, reservation.checkOutDate));
                    if(transaction == null)
                    {
                        MessageBox.Show("Checkout failed!");
                    }
                    else
                    {
                        MessageBox.Show("Checkout success!");
                    }

                    reservation.status = "Finished";
                    reservation = rmediator.updateReservation(reservation.reservationID, reservation);
                    Room room = romediator.getRoom((int)reservation.roomID);
                    room.status = "Available";
                    room = romediator.updateRoom(room.roomID, room);

                }
            }
        }

        private void checkRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            string reservationIDStr = reservationIDTxt.Text.Trim();
            int reservationID;

            bool success = int.TryParse(reservationIDStr, out reservationID);
            if (!success)
            {
                errorLbl.Text = "Reservation ID must be a number!";
            }
            else
            {
                ReservationMediator mediator = new ReservationMediator();
                Reservation reservation = mediator.getReservation(reservationID);
                if(reservation == null || reservation.status == "Finished")
                {
                    errorLbl.Text = "Reservation doesn't exist";
                }
                else
                {
                    CleaningScheduleMediator cmediator = new CleaningScheduleMediator();
                    CleaningScheduleFactory cfactory = new CleaningScheduleFactory();
                    CleaningSchedule cleaningSchedule = cmediator.addCleaningSchedule(cfactory.createNewCleaningSchedule((int)reservation.roomID, DateTime.Now));
                    if(cleaningSchedule == null)
                    {
                        MessageBox.Show("Check room failed!");
                    }
                    else
                    {
                        MessageBox.Show("Check room success! Please wait for house keeping division");
                    }
                }
            }
        }

        private void checkPriceBtn_Click(object sender, RoutedEventArgs e)
        {
            string reservationIDStr = reservationIDTxt.Text.Trim();
            string damageCostStr = damageCostTxt.Text.Trim();
            int reservationID, damageCost = 0;

            bool success = int.TryParse(reservationIDStr, out reservationID);
            bool success2 = int.TryParse(damageCostStr, out damageCost);
            if (!success || !success2)
            {
                errorLbl.Text = "Reservation ID and Damage Cost must be a number!";
            }
            else
            {

                RoomMediator mediator = new RoomMediator();
                ReservationMediator rmediator = new ReservationMediator();

                Reservation reservation = rmediator.getReservation(reservationID);
                Room room = mediator.getRoom((int)reservation.roomID);
                totalPrice = (int)room.price + damageCost;
                totalPriceLbl.Text = "Total Price = Rp. " + (totalPrice).ToString();
            }
        }
    }
}
