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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOP_Project_Part2_WPF_CS
{
    /// <summary>
    /// The main menu of the application, providing navigation to various features,
    /// including search and display entertainment activities, add new activities,
    /// search and display fitness activities.
    /// </summary>
    public partial class MainMenu : Window
    {
        /// <summary>
        /// Initialize components for Main Menu.
        /// </summary>
        public MainMenu()
        {
            InitializeComponent();
        }

        ///<AddActvities_Click name = "btnAddActivities_Click" >
        ///<summary>
        ///Handles the click event for the "Add Activities" button.
        ///Opens the FrmAddActivities form to allow users to add new entertainment activities
        ///to the system.
        ///</summary>
        ///</AddActvities_Click>
        private void BtnAddActivities_Click(object sender, RoutedEventArgs e)
        {
            AddActivities addActivitiesWindow = new AddActivities();
            addActivitiesWindow.Show();
            this.Close();
        }



        ///<SearchDisplayAllActivities_Click name = "btnSearchEntertainmentActivities_Click" >
        ///<summary>
        ///Handles the click event for the "Search and Display All Activities" button.
        ///Opens the FrmSearchDisplayAllActivities form to allow users to search and view
        ///all entertainment activities stored in the system.
        ///</summary>
        ///</SearchDisplayAllActivities_Click>
        private void btnSearchEntertainmentActivities_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var searchDisplayWindow = new FrmSearchDisplayAllEntertainmentActivities();
                searchDisplayWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening window: " + ex.Message);
            }

        }

        ///<SearchDisplayFitnessActivities_Click name = "btnSearchDisplayFitnessActivities_Click" >
        ///<summary>
        ///Handles the click event for the "Search and Display Fitness Activities" button.
        ///Opens the FrmSearchDisplayFitnessActivities form to allow users to search and view
        ///fitness activities stored in the system.
        ///</summary>
        ///</SearchDisplayFitnessActivities_Click>

        private void btnSearchFitnessActivities_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var searchDisplayWindow = new FrmSearchDisplayAllFitnessActivities();
                searchDisplayWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening window: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDeleteActivities_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var deleteActivitiesWindow = new DeleteActivities();
                deleteActivitiesWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening window: " + ex.Message);
            }
        }
    }
}