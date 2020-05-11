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

namespace TPA_Desktop.Views
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
    }
}