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

namespace TPA_Desktop.Views.SalesMarketingD
{
    /// <summary>
    /// Interaction logic for AddAdvertisementLogView.xaml
    /// </summary>
    public partial class AddAdvertisementLogView : Window
    {
        public AddAdvertisementLogView()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            string title = titleTxt.Text;
            string desc = descTxt.Text;

            if(title == "" || desc == "")
            {
                errorLbl.Text = "Please fill all field!";
            }
            else
            {
                AdvertisementMediator mediator = new AdvertisementMediator();
                AdvertisementFactory factory = new AdvertisementFactory();
                Advertisement advertisement = mediator.addAdvertisement(factory.createNewAdvertisement(title, desc));
                if(advertisement == null)
                {
                    MessageBox.Show("Add advertisement failed!");
                    this.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("Add advertisement success!");
                    this.Visibility = Visibility.Hidden;
                }
            }
        }
    }
}
