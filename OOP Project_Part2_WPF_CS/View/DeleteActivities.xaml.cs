using OOP_Project_Part2_WPF_CS.View_Mode;
using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for DeleteActivities.xaml
    /// </summary>
    public partial class DeleteActivities : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteActivities"/> class.
        /// </summary>

        public DeleteActivities()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Validates the inputs for deleting entertainment activities.
        /// </summary>
        /// <param name="dateStartTime"></param>
        /// <returns></returns>

        private bool ValidateEntertainmentActivitiesInputs(out DateTime dateStartTime)
        {
            dateStartTime = default;
            if (string.IsNullOrWhiteSpace(txtEntertainmentDateStartTime.Text))
            {
                MessageBox.Show("Please fill in all fields before saving.",
                    "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            string dateFormat = "dd/MM/yyyy HH:mm";

            string inputDate = txtEntertainmentDateStartTime.Text;

            if (!DateTime.TryParseExact(inputDate, dateFormat,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out dateStartTime))
            {
                MessageBox.Show("Start date/time must be in the format DD/MM/YYYY HH:MM.",
                    "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates the inputs for deleting fitness activities.
        /// </summary>
        /// <param name="dateStartTime"></param>
        /// <returns></returns>
        private bool ValidateFitnessActivitiesInputs(out DateTime dateStartTime)
        {
            dateStartTime = default;
            if (string.IsNullOrWhiteSpace(txtFitnessDateStartTime.Text))
            {
                MessageBox.Show("Please fill in all fields before saving.",
                    "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            string dateFormat = "dd/MM/yyyy HH:mm";

            string inputDate = txtFitnessDateStartTime.Text;

            if (!DateTime.TryParseExact(inputDate, dateFormat,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out dateStartTime))
            {
                MessageBox.Show("Start date/time must be in the format DD/MM/YYYY HH:MM.",
                    "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }
        /// <summary>
        /// back to main menu
        /// </summary>
        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainWindow = new MainMenu();
            mainWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Displays all entertainment activities in the data grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplayAllEntertainmentActivities_Click(object sender, RoutedEventArgs e)
        {
            var controller = new DisplaySearchEntertainmentController();
            dgEntertainmentActivities.ItemsSource = controller.GetAllEntertainmentActivities();
        }

        /// <summary>
        /// Clears the entertainment activities data grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearEntertainmentTable_Click(object sender, RoutedEventArgs e)
        {
            dgEntertainmentActivities.ItemsSource = null;
        }

        /// <summary>
        /// Deletes entertainment activities based on the specified start date and time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void btnDeleteEntertainmentActivity_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateEntertainmentActivitiesInputs(out DateTime dateStartTime))
            {
                return;
            }
            try
            {
                var deleteController = new DeleteActivityController();
                var existingController = new AddActivityController();
                var displayController = new DisplaySearchEntertainmentController();

                bool exists = existingController.DoesActivityExistOnDate(dateStartTime);

                if (exists)
                {
                    int deleted = deleteController.DeleteEntertainmentActivities(dateStartTime);
                    MessageBox.Show("Entertainment activities deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    dgEntertainmentActivities.ItemsSource = displayController.GetAllEntertainmentActivities();
                }
                else
                {
                    MessageBox.Show("No entertainment activities found for the specified start date/time.");
                }
            }

            catch (SqlException sqlEx)
            {
                MessageBox.Show($"A database error occurred: {sqlEx.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Displays all fitness activities in the data grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplayAllFitnessActivities_Click(object sender, RoutedEventArgs e)
        {
            var controller = new DisplaySearchFitnessController();
            dgFitnessActivities.ItemsSource = controller.GetAllFitnessActivities();
        }

        /// <summary>
        /// Clears the fitness activities data grid.
        /// </summary>
        private void btnClearFitnessTable_Click(object sender, RoutedEventArgs e)
        {
            dgFitnessActivities.ItemsSource = null;
        }

        /// <summary>
        /// Deletes fitness activities based on the specified start date and time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteFitnessActivity_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateFitnessActivitiesInputs(out DateTime dateStartTime))
            {
                return;
            }
            try
            {
                var deleteController = new DeleteActivityController();
                var existingController = new AddActivityController();
                var displayController = new DisplaySearchFitnessController();

                bool exists = existingController.DoesActivityExistOnDate(dateStartTime);

                if (exists)
                {
                    int deleted = deleteController.DeleteFitnessActivities(dateStartTime);
                    MessageBox.Show("Fitness activities deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    dgFitnessActivities.ItemsSource = displayController.GetAllFitnessActivities();
                }
                else
                {
                    MessageBox.Show("No fitness activities found for the specified start date/time.");
                }
            }

            catch (SqlException sqlEx)
            {
                MessageBox.Show($"A database error occurred: {sqlEx.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}

