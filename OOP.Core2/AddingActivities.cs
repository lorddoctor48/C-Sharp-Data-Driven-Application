using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OOP.Core.Activities
{
    public sealed class Entertainment
    {

        public string DateStartTime { get; set; }

        public string Title { get; set; }

        public int? Cost { get; set; }

        public int? MinParticipants { get; set; }


        public Entertainment(string DateStartTime, string Title, int Cost, int? MinParticipants)
        {
            if (!DateTime.TryParse(DateStartTime, out _)) throw new ArgumentException("DateStartTime must be a valid date/time.", nameof(DateStartTime));
            if (string.IsNullOrWhiteSpace(Title)) throw new ArgumentException("Title is required.", nameof(Title));
            if (Title.Length < 3) throw new ArgumentOutOfRangeException(nameof(Title), "Title must be at least three characters.");
            if (Cost < 0) throw new ArgumentOutOfRangeException(nameof(Cost), "Cost cannot be negative.");
            if (MinParticipants is null) throw new ArgumentNullException(nameof(MinParticipants));
            if (MinParticipants < 2) throw new ArgumentOutOfRangeException(nameof(MinParticipants), "MinParticipants must be at least two.");

            this.DateStartTime = DateStartTime;
            this.Title = Title;
            this.Cost = Cost;
            this.MinParticipants = MinParticipants;
        }
    }

    public sealed class Fitness
    {
        public string DateStartTime { get; set; }

        public string Title { get; set; }

        public int? Cost { get; set; }

        public string Location { get; set; }


        public Fitness(string DateStartTime, string Title, int Cost, string Location)
        {
            if (!DateTime.TryParse(DateStartTime, out _)) throw new ArgumentException("DateStartTime must be a valid date/time.", nameof(DateStartTime));
            if (string.IsNullOrWhiteSpace(Title)) throw new ArgumentException("Title is required.", nameof(Title));
            if (Title.Length < 3) throw new ArgumentOutOfRangeException("Title must be at least three characters", nameof(Title));
            if (Cost < 0) throw new ArgumentOutOfRangeException(nameof(Cost), "Cost cannot be negative.");
            if (string.IsNullOrWhiteSpace(Location)) throw new ArgumentException("Location is required.", nameof(Location));


            this.DateStartTime = DateStartTime;
            this.Title = Title;
            this.Cost = Cost;
            this.Location = Location;
        }
    }
}