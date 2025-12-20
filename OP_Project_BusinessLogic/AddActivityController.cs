using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP_Project_BusinessLogic
{
    public class AddActivityController
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

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

        public bool DoesActivityExistOnDate(DateTime date, string title)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("CheckActivityExistsByDate", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DateToCheck", date.Date);

                conn.Open();
                var result = cmd.ExecuteScalar();

                return Convert.ToInt32(result) == 1;
            }
        }
    }
}
