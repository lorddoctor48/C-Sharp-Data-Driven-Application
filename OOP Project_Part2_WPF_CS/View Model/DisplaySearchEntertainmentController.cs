using FileHelpers;
using FileHelpers.DataLink;
using OOP_Project_Part2_WPF_CS;
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
    /// Controller class for searching and displaying all entertainment activities.
    /// Provides functionality to search and view entertainment activities.
    /// </summary>
    public class DisplaySearchEntertainmentController
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            /// <summary>
            /// Retrieves all entertainment activities from the database.
            /// </summary>
            /// <returns>List of all <see cref="Entertainment"/> activities.</returns>
            public List<Entertainment> GetAllEntertainmentActivities()
            {
                var activities = new List<Entertainment>();

                DataTable entertainmentActivitiesTable = new DataTable();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetAllEntertainmentActivities", connection);
                    connection.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        activities.Add(new Entertainment
                        {
                            DateStartTime = rdr["DateStartTime"].ToString(),
                            Title = rdr["Title"].ToString(),
                            Cost = rdr["Cost"] != DBNull.Value ? Convert.ToInt32(rdr["Cost"]) : (int?)null,
                            MinParticipants = rdr["MinParticipants"] as int?
                        });
                    }
                }
                return activities;
            }



            /// <summary>
            /// Not implemented. Intended to retrieve entertainment activities.
            /// </summary>
            /// <returns>Throws <see cref="NotImplementedException"/>.</returns>
            public object GetEntertainmentActivities()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Searches for entertainment activities by date using the specified operator.
        /// </summary>
        /// <param name="searchDate">The date to search for.</param>
        /// <param name="operatorValue">The operator to use in the search (e.g., '=', '&gt;', '&lt;').</param>
        /// <returns>List of <see cref="Entertainment"/> activities matching the search criteria.</returns>
        public List<Entertainment> GetSearchEntertainmentActivities(DateTime searchDate, string operatorValue)
        {
            var activities = new List<Entertainment>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SearchActivitiesByDate", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Add parameters with explicit types
                cmd.Parameters.Add("@SearchDate", SqlDbType.Date).Value = searchDate;
                cmd.Parameters.Add("@Operator", SqlDbType.NVarChar, 10).Value = operatorValue;

                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr["MinParticipants"] != DBNull.Value)
                    {

                        activities.Add(new Entertainment
                        {
                            ActivityID = Convert.ToInt32(rdr["ActivityID"]),
                            DateStartTime = rdr["DateStartTime"].ToString(),
                            Title = rdr["Title"].ToString(),
                            Cost = rdr["Cost"] != DBNull.Value ? Convert.ToInt32(rdr["Cost"]) : (int?)null,
                            MinParticipants = rdr["MinParticipants"] as int?
                        });
                    }
                }
            }
            return activities;
        }
    }
}