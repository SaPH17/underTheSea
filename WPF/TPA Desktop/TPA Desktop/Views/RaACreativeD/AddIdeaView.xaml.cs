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

namespace TPA_Desktop.Views.RaACreativeD
{
    /// <summary>
    /// Interaction logic for AddIdeaView.xaml
    /// </summary>
    public partial class AddIdeaView : Window
    {
        public AddIdeaView()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTxt.Text;
            string desc = descTxt.Text;

            if(name == "" || desc == "" || typeComboBox.SelectedItem == null || categoryComboBox.SelectedItem == null)
            {
                errorLbl.Text = "Please input all field!";
            }
            else
            {
                string type = (string)((ComboBoxItem)typeComboBox.SelectedValue).Content;
                string category = (string)((ComboBoxItem)categoryComboBox.SelectedValue).Content;

                IdeaMediator mediator = new IdeaMediator();
                IdeaFactory factory = new IdeaFactory();
                Idea idea = mediator.addIdea(factory.createNewIdea(name, desc, type, category));
                if(idea == null)
                {
                    MessageBox.Show("Add idea failed!");
                }
                else
                {
                    MessageBox.Show("Add idea success!");
                }
                this.Visibility = Visibility.Hidden;
            }
        }
    }
}
