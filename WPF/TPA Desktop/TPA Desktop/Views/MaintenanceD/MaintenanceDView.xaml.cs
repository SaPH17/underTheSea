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
using TPA_Desktop.Views.ConstructionD;
using TPA_Desktop.Views.RaACreativeD;

namespace TPA_Desktop.Views.MaintenanceD
{
    /// <summary>
    /// Interaction logic for MaintenanceD.xaml
    /// </summary>
    public partial class MaintenanceDView : Window
    {
        public MaintenanceDView()
        {
            InitializeComponent();
            Biodata.Content = new BiodataView();
        }

        private void addMaintenanceScheduleBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddMaintenanceScheduleView().Show();
        }

        private void viewMaintenanceScheduleBtn_Click(object sender, RoutedEventArgs e)
        {
            new MaintenanceScheduleView().Show();
        }

        private void addMaintenanceLogBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddMaintenanceLogView().Show();
        }

        private void changeAttractionOrRideStatusBtn_Click(object sender, RoutedEventArgs e)
        {
            new ChangeAttractionRideStatusView().Show();
        }

        private void viewAttractionOrRideBtn_Click(object sender, RoutedEventArgs e)
        {
            new AttractionRideView().Show();
        }

        private void viewMaintenanceLogBtn_Click(object sender, RoutedEventArgs e)
        {
            new MaintenanceLogView().Show();
        }
    }
}
