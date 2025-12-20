using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_Part2_WPF_CS.View_Mode
{
    /// <summary>
    /// Controller for adding new entertainment and fitness activities.
    /// Provides functionality to input and save new activities to the database.
    /// </summary>
    public class AddActivityController
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        /// <summary>
        /// Adds a new entertainment activity to the database.
        /// </summary>
        /// <param name="DateStartTime">The start date and time of the activity.</param>
        /// <param name="Title">The title of the activity.</param>
        /// <param name="Cost">The cost of the activity (optional).</param>
        /// <param name="MinParticipants">The minimum number of participants (optional).</param>
        /// <returns>A list of <see cref="Entertainment"/> activities.</returns>
        public List<Entertainment> GetAddEntertainmentActivities(DateTime DateStartTime, string Title, int? Cost, int? MinParticipants)
        {
            var activities = new List<Entertainment>();

            using (var conn = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("AddEntertainmentActivity", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DateStartTime", DateStartTime);
                    cmd.Parameters.AddWithValue("@Title", Title);
                    cmd.Parameters.AddWithValue("@Cost", (object)Cost ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MinParticipants", (object)MinParticipants ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
                return activities;
            }
        }

        /// <summary>
        /// Adds a new fitness activity to the database.
        /// </summary>
        /// <param name="DateStartTime">The start date and time of the activity.</param>
        /// <param name="Title">The title of the activity.</param>
        /// <param name="Cost">The cost of the activity (optional).</param>
        /// <param name="Location">The location of the activity.</param>
        /// <returns>A list of <see cref="Fitness"/> activities.</returns>
        public List<Fitness> GetAddFitnessActivities(DateTime DateStartTime, string Title, int? Cost, string Location)
        {
            var activities = new List<Fitness>();

            using (var conn = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("AddFitnessActivity", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DateStartTime", DateStartTime);
                    cmd.Parameters.AddWithValue("@Title", Title);
                    cmd.Parameters.AddWithValue("@Cost", (object)Cost ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Location", Location);
                    cmd.ExecuteNonQuery();
                }
                return activities;
            }
        }

        /// <summary>
        /// Checks if an activity exists on a specific date.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <returns>True if the activity exists on the specified date; otherwise, false.</returns>
        public bool DoesActivityExistOnDate(DateTime date)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("CheckActivityExistsByDate", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DateToCheck", date.Date);

                conn.Open();
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                return result > 0;
            }
        }


        /// <summary>
        /// Updates an existing activity with new details.
        /// </summary>
        /// <param name="activityId">The unique identifier of the activity to update.</param>
        /// <param name="newDateStartTime">The new start date and time of the activity.</param>
        /// <param name="newTitle">The new title of the activity.</param>
        /// <param name="newCost">The new cost of the activity.</param>
        /// <param name="newType">The type of the activity (e.g., Entertainment, Fitness).</param>
        /// <param name="location">The new location of the activity, or null if not applicable.</param>
        /// <param name="minParticipants">The minimum number of participants required, or null if not applicable.</param>
        /// <returns>True if the update succeeds; otherwise, false.</returns>

        public bool UpdateActivity(
            int activityId,
            DateTime newDateStartTime,
            string newTitle,
            decimal newCost,
            string newType,
            string location = null,
            int? minParticipants = null)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("UpdateActivityWithTypeCheck", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ActivityID", activityId);
                cmd.Parameters.AddWithValue("@NewDateStartTime", newDateStartTime);
                cmd.Parameters.AddWithValue("@NewTitle", newTitle);
                cmd.Parameters.AddWithValue("@NewCost", newCost);
                cmd.Parameters.AddWithValue("@NewType", newType);
                cmd.Parameters.AddWithValue("@Location", (object)location ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MinParticipants", (object)minParticipants ?? DBNull.Value);

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}