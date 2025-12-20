using OOP_Project_Part2_WPF_CS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_Part2_WPF_CS
{
    /// <summary>
    /// Retrieves all fitness activities from the database.
    /// Controller class for searching and displaying all fitness activities.
    /// Provides functionality to search and view fitness activities.
    /// </summary>>
    public class DisplaySearchFitnessController
    {

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        /// <summary>
        /// Retrieves all fitness activities from the database.
        /// </summary>
        /// <returns>A list of <see cref="Fitness"/> objects representing all fitness activities.</returns>
        public List<Fitness> GetAllFitnessActivities()
        {
            var activities = new List<Fitness>();

            DataTable fitnessActivitiesTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllFitnessActivities", connection);

                connection.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    activities.Add(new Fitness
                    {
                        DateStartTime = rdr["DateStartTime"].ToString(),
                        Title = rdr["Title"].ToString(),
                        Cost = rdr["Cost"] != DBNull.Value ? Convert.ToInt32(rdr["Cost"]) : (int?)null,
                        Location = rdr["Location"].ToString(),
                    });
                }
            }
            return activities;
        }

        /// <summary>
        /// Not implemented. Intended to retrieve fitness activities.
        /// </summary>
        /// <returns>Throws <see cref="NotImplementedException"/>.</returns>
        public object GetFitnessActivities()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves fitness activities from the database based on a search date and comparison operator.
        /// </summary>
        /// <param name="searchDate">The date to compare activity start times against.</param>
        /// <param name="operatorValue">The comparison operator (e.g., "=", "&gt;", "&lt;") to use for filtering activities by date.</param>
        /// <returns>A list of <see cref="Fitness"/> objects that match the search criteria.</returns>
        public List<Fitness> GetSearchFitnessActivities(DateTime searchDate, string operatorValue)
        {
            var activities = new List<Fitness>();
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
                    if (rdr["Location"] != DBNull.Value)
                    {
                        activities.Add(new Fitness
                        {
                            ActivityID = Convert.ToInt32(rdr["ActivityID"]),
                            DateStartTime = rdr["DateStartTime"].ToString(),
                            Title = rdr["Title"].ToString(),
                            Cost = rdr["Cost"] != DBNull.Value ? Convert.ToInt32(rdr["Cost"]) : (int?)null,
                            Location = rdr["Location"].ToString(),
                        });
                    }
                }
            }
            return activities;
        }
    }
}