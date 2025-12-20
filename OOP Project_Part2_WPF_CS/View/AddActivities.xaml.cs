using FileHelpers;
using OOP_Project_Part2_WPF_CS.View_Mode;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
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
    ///<AddActivties name = "Frm_AddActivties.cs" >
    ///<summary>
    ///Form for adding new entertainment and fitness activities.
    ///Provides functionality to input and save new activities to the system.
    ///</summary>
    ///</AddActivties>
    ///</summary>

    public partial class AddActivities : Window
    {
        /// <summary>
        /// Gets or sets a value indicating whether to edit an already existing activities.
        /// </summary>
        public int? EditingActivityId { get; set; } = null;

        /// <summary>
        /// Gets or sets a value indicating whether to search for fitness activities.
        /// </summary>
        public bool GetSearchFitnessActivities;
        /// <summary>
        /// Gets or sets a value indicating whether to add entertainment activities.
        /// </summary>
        public bool GetAddEntertainmentActivities;
        /// <summary>
        /// Initializes a new instance of the <see cref="AddActivities"/> class.
        /// </summary>
        public AddActivities()
        {
            InitializeComponent();

        }

        private bool ValidateActivitiesInputs(out DateTime dateStartTime, out int cost)
        {
            dateStartTime = default;
            cost = 0;

            // Check required fields
            if (string.IsNullOrWhiteSpace(txtDateStartTime.Text) ||
                string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtCost.Text))
            {
                MessageBox.Show("Please fill in all fields before saving.",
                    "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Date format check
            string dateFormat = "dd/MM/yyyy HH:mm";
            if (!DateTime.TryParseExact(txtDateStartTime.Text, dateFormat,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out dateStartTime))
            {
                MessageBox.Show("Start date/time must be in the format DD/MM/YYYY HH:MM.",
                    "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Title length check
            if (txtTitle.Text.Length < 3)
            {
                MessageBox.Show("Title must be at least three characters long.",
                    "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Cost check
            if (!int.TryParse(txtCost.Text, out cost))
            {
                MessageBox.Show("Cost must be a valid integer.",
                    "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (cost < 0)
            {
                MessageBox.Show("Cost must be a positive integer.",
                    "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        private bool ValidateEntertainmentInputs(out int minParticipants)
        {
            minParticipants = 0;
            if (string.IsNullOrWhiteSpace(txtMinParticipants.Text))
            {
                MessageBox.Show("Please fill in all fields before saving.",
                    "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!int.TryParse(txtMinParticipants.Text, out minParticipants))
            {
                MessageBox.Show("Minimum participants must be a valid integer.",
                    "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (minParticipants <= 1)
            {
                MessageBox.Show("Minimum participants must be at least two.",
                    "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        private bool ValidateFitnessInputs(out string location)
        {
            location = txtLocation.Text;
            if (string.IsNullOrWhiteSpace(location) || location.Length < 3)
            {
                MessageBox.Show("Location must be at least three characters long.",
                    "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;

        }
        ///<MainMenu_Click name = "btnMainMenu_Click" >
        ///<summary>
        ///Handles the click event for the "Main Menu" button.
        ///Closes the current form and returns to the main menu (FrmMainMenu).
        ///</summary>
        ///</MainMenu_Click>

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainWindow = new MainMenu();
            mainWindow.Show();
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
            txtDateStartTime.Clear();
            txtTitle.Clear();
            txtCost.Clear();
            txtMinParticipants.Clear();
            txtLocation.Clear();
        }

        ///<SaveEntertainmentActivity_Click name = "btnSaveEntertainmentActivity_Click" >
        ///<summary>
        ///Handles the click event for the "Save Entertainment Activity" button.
        ///Saves a new entertainment activity to the system based on user input with data validation.
        ///</summary>
        ///</SaveEntertainmentActivity_Click>

        private void btnSaveEntertainmentActivity_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateActivitiesInputs(out DateTime dateStartTime, out int cost1))
            {
                return;
            }
            if (!ValidateEntertainmentInputs(out int minParticipants))
            {
                return;
            }

            try
            {
                var controller = new AddActivityController();

                // Case 1: Editing an existing activity
                if (EditingActivityId != null)
                {
                    var storageController = new AddActivityController();
                    storageController.UpdateActivity(EditingActivityId.Value, dateStartTime, txtTitle.Text, cost1,
                                                     "Entertainment", null, minParticipants);

                    MessageBox.Show("Entertainment activity successfully updated", "Success",
                                    MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                // Case 2: Adding a new activity
                if (controller.DoesActivityExistOnDate(dateStartTime))
                {
                    var response = MessageBox.Show(
                        "An activity with this title already exists. Do you want to load it for editing?",
                        "Validation Error", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (response != MessageBoxResult.Yes)
                        return;

                    var searchController = new DisplaySearchEntertainmentController();
                    var existingActivities = searchController.GetSearchEntertainmentActivities(dateStartTime, "ON");

                    if (existingActivities != null && existingActivities.Count > 0)
                    {
                        var existingActivity = existingActivities[0];

                        // Populate fields with existing data
                        txtDateStartTime.Text = DateTime.Parse(existingActivity.DateStartTime).ToString("dd/MM/yyyy HH:mm");
                        txtTitle.Text = existingActivity.Title;
                        txtCost.Text = existingActivity.Cost?.ToString();
                        txtMinParticipants.Text = existingActivity.MinParticipants?.ToString();

                        // Mark that we are editing this activity
                        EditingActivityId = existingActivity.ActivityID;

                        MessageBox.Show("Existing activity loaded. Review and click Save to confirm changes.",
                            "Edit Mode", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("No existing activity found to load.", "Error",
                                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                    return; // stop here, no update yet
                }

                // Case 3: Add brand new activity (no duplicate found)
                controller.GetAddEntertainmentActivities(dateStartTime, txtTitle.Text, cost1, minParticipants);

                MessageBox.Show("Entertainment activity added successfully!", "Success",
                                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Database error: " + sqlEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        ///<SaveFitnessActivity_Click name = "btnSaveFitnessActivity_Click" >
        ///<summary>
        ///Handles the click event for the "Save Fitness Activity" button.
        ///Saves a new fitness activity to the system based on user input with data validation.
        ///</summary>
        ///</SaveFitnessActivity_Click>

        private void btnSaveFitnessActivity_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateActivitiesInputs(out DateTime dateStartTime, out int cost1))
            {
                return;
            }
            if (!ValidateFitnessInputs(out string location))
            {
                return;
            }

            try
            {
                var controller = new AddActivityController();

                // Case 1: Editing an existing fitness activity
                if (EditingActivityId != null)
                {
                    var storageController = new AddActivityController();
                    storageController.UpdateActivity(EditingActivityId.Value, dateStartTime, txtTitle.Text, cost1,
                                                     "Fitness", txtLocation.Text, null);

                    MessageBox.Show("Fitness activity successfully updated", "Success",
                                    MessageBoxButton.OK, MessageBoxImage.Information);

                    // Reset back to Add mode after update
                    EditingActivityId = null;
                    return;
                }

                // Case 2: Duplicate check when adding a new fitness activity
                if (controller.DoesActivityExistOnDate(dateStartTime))
                {
                    var response = MessageBox.Show(
                        "A fitness activity with this title already exists. Do you want to load it for editing?",
                        "Validation Error", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (response != MessageBoxResult.Yes)
                        return;

                    var searchController = new DisplaySearchFitnessController();
                    var existingActivities = searchController.GetSearchFitnessActivities(dateStartTime, "ON");

                    if (existingActivities != null && existingActivities.Count > 0)
                    {
                        var existingActivity = existingActivities[0];

                        // Populate fields with existing data
                        txtDateStartTime.Text = DateTime.Parse(existingActivity.DateStartTime)
                                                         .ToString("dd/MM/yyyy HH:mm");
                        txtTitle.Text = existingActivity.Title;
                        txtCost.Text = existingActivity.Cost?.ToString();
                        txtLocation.Text = existingActivity.Location; // fitness-specific field

                        // Mark that we are editing this activity
                        EditingActivityId = existingActivity.ActivityID;

                        MessageBox.Show("Existing fitness activity loaded. Review and click Save to confirm changes.",
                            "Edit Mode", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("No existing fitness activity found to load.", "Error",
                                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                    return; // stop here, no update yet
                }


                // Case 3: Add brand new fitness activity (no duplicate found)
                controller.GetAddFitnessActivities(dateStartTime, txtTitle.Text, cost1, txtLocation.Text);

                    MessageBox.Show("Fitness activity added successfully!", "Success",
                                    MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Database error: " + sqlEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unexpected error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
        }
    }
}