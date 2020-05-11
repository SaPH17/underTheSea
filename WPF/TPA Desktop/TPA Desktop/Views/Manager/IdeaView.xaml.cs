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
    /// Interaction logic for IdeaView.xaml
    /// </summary>
    public partial class IdeaView : Window
    {
        public IdeaView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            IdeaMediator mediator = new IdeaMediator();
            ideaView.ItemsSource = mediator.getAllIdea("Pending");
            reasonLbl.Visibility = Visibility.Hidden;
            reasonTxt.Visibility = Visibility.Hidden;
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            string ideaIDStr = ideaIDTxt.Text.Trim();
            int ideaID;
            string reason = reasonTxt.Text.Trim();

            bool success = int.TryParse(ideaIDStr, out ideaID);
            if (!success)
            {
                errorLbl.Text = "IdeaID must be a number";
            }
            else if (responseComboBox.SelectedItem == null || ((string)((ComboBoxItem)responseComboBox.SelectedValue).Content == "Decline" && reason == ""))
            {
                errorLbl.Text = "Please input all field!";
            }
            else
            {
                string response = (string)((ComboBoxItem)responseComboBox.SelectedValue).Content;

                IdeaMediator mediator = new IdeaMediator();
                Idea idea = mediator.getIdea(ideaID);
                if (idea == null || idea.status != "Pending")
                {
                    errorLbl.Text = "Idea doesn't exist!";
                }
                else
                {
                    if (response == "Accept")
                    {
                        response += "ed";
                    }
                    else
                    {
                        response += "d";
                    }

                    idea.status = response;
                    if (response == "Declined")
                    {
                        idea.response = reason;
                    }
                    Idea i = mediator.updateIdea(ideaID, idea);
                    if (i == null)
                    {
                        MessageBox.Show("Idea response failed");
                    }
                    else
                    {
                        MessageBox.Show("Idea response success");
                    }
                    refresh();
                }
            }
        }

        private void responseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (string)((ComboBoxItem)responseComboBox.SelectedValue).Content;
            if (text == "Decline")
            {
                reasonLbl.Visibility = Visibility.Visible;
                reasonTxt.Visibility = Visibility.Visible;
            }
            else
            {
                reasonLbl.Visibility = Visibility.Hidden;
                reasonTxt.Visibility = Visibility.Hidden;
            }
        }
    }
}
