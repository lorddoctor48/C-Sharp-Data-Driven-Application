using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_Part2_WPF_CS
{
    /// <summary>
    /// DeleteActivityController handles the deletion of entertainment and fitness activities from the database.
    /// </summary>
    public class DeleteActivityController
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        
        /// <summary>
        /// Deletes entertainment activities that start at the specified date and time.
        /// </summary>
        /// <remarks>This method executes the <c>DeleteEntertainmentActivitiesByDateStartTime</c> stored
        /// procedure in the database.</remarks>
        /// <param name="dateStartTime">The start date and time of the entertainment activities to delete.</param>
        /// <returns>The number of entertainment activities deleted. Returns 0 if no activities match the specified start time.</returns>
        public int DeleteEntertainmentActivities(DateTime dateStartTime)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("DeleteEntertainmentActivitiesByDateStartTime", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DateStartTime", dateStartTime);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Deletes fitness activities that start at the specified date and time.
        /// </summary>
        /// <param name="dateStartTime"></param>
        /// <returns></returns>
        public int DeleteFitnessActivities(DateTime dateStartTime)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("DeleteFitnessActivitiesByDateStartTime", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DateStartTime", dateStartTime);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
