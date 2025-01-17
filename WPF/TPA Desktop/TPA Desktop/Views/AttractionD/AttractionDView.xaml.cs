﻿using System;
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
using TPA_Desktop.Views.DiningRoomD;

namespace TPA_Desktop.Views.AttractionD
{
    /// <summary>
    /// Interaction logic for AttractionD.xaml
    /// </summary>
    public partial class AttractionDView : Window
    {
        public AttractionDView()
        {
            InitializeComponent();
            Biodata.Content = new BiodataView();
        }

        private void checkTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            new CheckTicketView().Show();
        }

        private void sellTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            new SellTicketView().Show();
        }
    }
}
