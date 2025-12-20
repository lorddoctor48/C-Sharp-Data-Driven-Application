using FileHelpers;
using FileHelpers.DataLink;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OOP_Project_Part2_WPF_CS
{
    /// <summary>
    /// Form for searching and displaying all entertainment activities.
    /// Provides functionality to search and view entertainment activities.
    /// </summary>

    public partial class FrmSearchDisplayAllEntertainmentActivities : Window
    {
        /// <summary>
        /// Initialize components for searching and displaying all entertainment activities.
        /// </summary>
        public FrmSearchDisplayAllEntertainmentActivities()
        {
            InitializeComponent();
        }

        ///<MainMenu_Click name = "btnMainMenu_Click" >
        ///<summary>
        ///Handles the click event for the "Main Menu" button.
        ///Closes the current form and returns to the main menu (FrmMainMenu).
        ///</summary>
        ///</MainMenu_Click>

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenuWindow = new MainMenu();
            mainMenuWindow.Show();
            this.Close();
        }

        ///<Reset_Click name = "btnReset_Click" >
        ///<summary>
        ///Handles the click event for the "Reset" button.
        ///Resets the search criteria and clears the ListView displaying entertainment activities.
        ///</summary>
        ///</Reset_Click>

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            dgEntertainmentActivities.ItemsSource = null;
        }

        ///<DisplayAllEntertainmentActivities_Click name = "btnDisplayAllEntertainmentActivities_Click" >
        ///<summary>
        ///Handles the click event for the "Display All Entertainment Activities" button.
        ///Retrieves and displays all entertainment activities from the database in a ListView.
        ///</summary>
        ///</DisplayAllEntertainmentActivities_Click>
        private void btnDisplayAllEntertainmentActivities_Click(object sender, RoutedEventArgs e)
        {
            var controller = new DisplaySearchEntertainmentController();
            dgEntertainmentActivities.ItemsSource = controller.GetAllEntertainmentActivities();
        }

        ///<SearchAllEntertainmentActivities_Click name = "btnSearchAllEntertainmentActivities_Click" >
        ///<summary>
        ///Handles the click event for the "Search All Activities" button.
        ///Searches for entertainment activities based on user-defined search
        ///criteria based on before, after, or on a specific date inputted in the DateTimePicker.
        ///Displays the results in a ListView.
        ///</summary>
        ///</SearchAllEntertainmentActivities_Click>

        private void btnSearchAllEntertainmentActivities_Click(object sender, RoutedEventArgs e)
        {
            //DateTime inputDate = dpSearchDate.SelectedDate ?? DateTime.MinValue;

            //var engine = new FileHelperEngine<Entertainment>();

            //var records = engine.ReadFile("EntertainmentActivities.csv");

            //var filteredRecords = new List<Entertainment>();

            //if (radBefore.IsChecked == true)
            //{
            //    filteredRecords = records.Where(r =>
            //        DateTime.TryParse(r.DateStartTime, out DateTime activityDate) &&
            //        activityDate < inputDate).ToList();
            //}
            //if (radOn.IsChecked == true)
            //{
            //    filteredRecords = records.Where(r =>
            //        DateTime.TryParse(r.DateStartTime, out DateTime activityDate) &&
            //        activityDate.Date == inputDate.Date).ToList();
            //}
            //if (radAfter.IsChecked == true)
            //{
            //    filteredRecords = records.Where(r =>
            //        DateTime.TryParse(r.DateStartTime, out DateTime activityDate) &&
            //        activityDate > inputDate).ToList();
            //}

            if (dpSearchDate.SelectedDate == null)
            {
                MessageBox.Show("Please select a valid date.");
                return;
            }

            DateTime searchDate = dpSearchDate.SelectedDate.Value;

            string operatorValue = null;

            if (radBefore.IsChecked == true)
            {
                operatorValue = "before";
            }
            else if (radOn.IsChecked == true)
            {
                operatorValue = "on";
            }
            else if (radAfter.IsChecked == true)
            {
                operatorValue = "after";
            }

            if (operatorValue == null)
            {
                MessageBox.Show("Please select a search option (Before, On, After).");
                return;
            }

            var controller = new DisplaySearchEntertainmentController();
            var activities = controller.GetSearchEntertainmentActivities(searchDate, operatorValue);

            dgEntertainmentActivities.ItemsSource = activities;
        }
    }
}
