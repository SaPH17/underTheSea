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
    /// Interaction logic for CheckInView.xaml
    /// </summary>
    public partial class CheckInView : Window
    {
        public CheckInView()
        {
            InitializeComponent();
            nameLbl.Visibility = Visibility.Hidden;
            nameTxt.Visibility = Visibility.Hidden;
            dateOfBirthLbl.Visibility = Visibility.Hidden;
            dateOfBirthPicker.Visibility = Visibility.Hidden;
            addressLbl.Visibility = Visibility.Hidden;
            addressTxt.Visibility = Visibility.Hidden;
            genderLbl.Visibility = Visibility.Hidden;
            genderComboBox.Visibility = Visibility.Hidden;
            registerBtn.Visibility = Visibility.Hidden;
        }

        private void showField()
        {
            nameLbl.Visibility = Visibility.Visible;
            nameTxt.Visibility = Visibility.Visible;
            dateOfBirthLbl.Visibility = Visibility.Visible;
            dateOfBirthPicker.Visibility = Visibility.Visible;
            addressLbl.Visibility = Visibility.Visible;
            addressTxt.Visibility = Visibility.Visible;
            genderLbl.Visibility = Visibility.Visible;
            genderComboBox.Visibility = Visibility.Visible;
            registerBtn.Visibility = Visibility.Visible;
        }

        private void checkInBtn_Click(object sender, RoutedEventArgs e)
        {
            int roomID;
            string customerCardID = customerCardIDTxt.Text.Trim();
            string roomIDStr = roomIDTxt.Text.Trim();
            DateTime? checkInDate = checkInDatepicker.SelectedDate;
            DateTime? checkOutDate = checkOutDatepicker.SelectedDate;

            bool success = int.TryParse(roomIDStr, out roomID);

            if (!success)
            {
                errorLbl.Text = "Room ID must be a number";
            }
            else if(DateTime.Now.Hour >= 10)
            {
                errorLbl.Text = "Check in time is 10 AM";
            }
            else if(customerCardID == "" || !checkInDate.HasValue || !checkOutDate.HasValue)
            {
                errorLbl.Text = "Please input all field!";
            }
            else
            {
                RoomMediator rmediator = new RoomMediator();
                Room room = rmediator.getRoom(roomID);
                if(room == null || room.status == "Not Available")
                {
                    errorLbl.Text = "Room is not available";
                }
                else
                {
                    CustomerMediator cmediator = new CustomerMediator();
                    Customer customer = cmediator.getCustomer(customerCardID);
                    if(customer == null)
                    {
                        showField();
                        errorLbl.Text = "Please register customer!";
                    }
                    else
                    {
                        ReservationMediator mediator = new ReservationMediator();
                        ReservationFactory factory = new ReservationFactory();
                        Reservation reservation = mediator.addReservation(factory.createNewReservation(customer.customerID, roomID, checkInDate, checkOutDate));
                        room.status = "Not Available";
                        room = rmediator.updateRoom(roomID, room);
                        totalPriceTxt.Text = "Total Price = Rp. " + room.price;
                        if(reservation == null)
                        {
                            MessageBox.Show("Reservation failed!");
                        }
                        else
                        {
                            MessageBox.Show("Reservation success!");
                        }
                    }
                }
            }


        }

        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            string idCardNumber = customerCardIDTxt.Text.Trim();
            string name = nameTxt.Text.Trim();
            string address = addressTxt.Text.Trim();
            DateTime? dateOfBirth = dateOfBirthPicker.SelectedDate;

            if(idCardNumber == "" || name == "" || address == "" || !dateOfBirth.HasValue || genderComboBox.SelectedItem == null)
            {
                errorLbl.Text = "Please input all field!";
            }
            else
            {
                string gender = (string)((ComboBoxItem)genderComboBox.SelectedValue).Content;

                CustomerMediator mediator = new CustomerMediator();
                CustomerFactory factory = new CustomerFactory();
                Customer customer = mediator.addCustomer(factory.createNewCustomer(idCardNumber, name, dateOfBirth, address, gender));
                if(customer == null)
                {
                    MessageBox.Show("Register customer failed!");
                }
                else
                {
                    MessageBox.Show("Register customer success!");
                }
            }
        }
    }
}
