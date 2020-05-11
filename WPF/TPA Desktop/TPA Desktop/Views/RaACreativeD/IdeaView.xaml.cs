using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            ideaView.ItemsSource = mediator.getAllIdea();
        }

        private void executeBtn_Click(object sender, RoutedEventArgs e)
        {
            string ideaIDStr = ideaIDTxt.Text.Trim();
            string desc = descTxt.Text.Trim();
            int ideaID;

            bool success = int.TryParse(ideaIDStr, out ideaID);

            if (!success)
            {
                errorLbl.Text = "IdeaID must be a number!";
            }
            else if(desc == "")
            {
                errorLbl.Text = "Please input all field!";
            }
            else
            {
                IdeaMediator mediator = new IdeaMediator();
                Idea idea = mediator.getIdea(ideaID);
                if(idea.status != "Accepted")
                {
                    errorLbl.Text = "Idea can't be executed";
                }
                else
                {
                    TaskMediator tmediator = new TaskMediator();
                    TaskFactory tfactory = new TaskFactory();
                    Task task = tmediator.addTask(tfactory.createNewTask(ideaID, desc));
                    if(task == null)
                    {
                        MessageBox.Show("Execute idea failed!");
                    }
                    else
                    {
                        idea.status = "On Progress";
                        mediator.updateIdea(ideaID, idea);
                        if(idea.type == "Add")
                        {
                            AttractionRideMediator amediator = new AttractionRideMediator();
                            AttractionRideFactory afactory = new AttractionRideFactory();
                            amediator.addAttractionOrRide(afactory.createNewAttractionOrRide(idea.name, idea.category, idea.description));
                        }
                        MessageBox.Show("Execute idea success!");
                    }
                    refresh();
                }
            }
        }
    }
}
