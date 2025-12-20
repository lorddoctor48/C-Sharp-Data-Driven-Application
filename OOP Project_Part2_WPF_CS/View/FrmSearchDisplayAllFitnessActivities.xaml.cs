using FileHelpers;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OOP_Project_Part2_WPF_CS
{
    ///<summary>
    ///Form for searching and displaying fitness activities.
    ///Provides functionality to search and view fitness activities.
    ///</summary>

    public partial class FrmSearchDisplayAllFitnessActivities : Window
    {
        /// <summary>
        /// Initialize components for searching and displaying all Fitness activities.
        /// </summary>
        public FrmSearchDisplayAllFitnessActivities()
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
            dgFitnessActivities.ItemsSource = null;
        }

        ///<DisplayAllFitnessActivities_Click name = "btnDisplayAllFitnessActivities_Click" >
        ///<summary>
        ///Handles the click event for the "Display All Fitness Activities" button.
        ///Retrieves and displays all fitness activities from the database in a ListView.
        ///</summary>
        ///</DisplayAllFitnessActivities_Click>

        private void btnDisplayAllFitnessActivities_Click(object sender, RoutedEventArgs e)
        {
            //var engine = new FileHelperEngine<Fitness>();

            //var records = engine.ReadFile("FitnessActivities.csv");

            //dgFitnessActivities.ItemsSource = records;

            var controller = new DisplaySearchFitnessController();
            dgFitnessActivities.ItemsSource = controller.GetAllFitnessActivities();
        }

        ///<btnSearchAllFitnessActivities_Click name = "SearchAllFitnessActivities_Click" >
        ///<summary>
        ///Handles the click event for the "Search All Activities" button.
        ///Searches for fitness activities based on user-defined search
        ///criteria based on before, after, or on a specific date inputted in the DateTimePicker
        ///Displays the results in a ListView.
        ///</summary>
        ///</btnSearchAllFitnessActivities_Click>

        private void btnSearchAllFitnessActivities_Click(object sender, RoutedEventArgs e)
        {
            //DateTime inputDate = dpSearchDate.SelectedDate ?? DateTime.MinValue;

            //var engine = new FileHelperEngine<Fitness>();

            //var records = engine.ReadFile("FitnessActivities.csv");

            //var filteredRecords = new List<Fitness>();

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

            //dgFitnessActivities.ItemsSource = filteredRecords;

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

            var controller = new DisplaySearchFitnessController();
            var activities = controller.GetSearchFitnessActivities(searchDate, operatorValue);
            dgFitnessActivities.ItemsSource = activities;
        }
    }
}
