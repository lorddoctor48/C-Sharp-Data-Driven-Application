using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_Part2_WPF_CS
{
    /// <summary>
    /// Represents a Entertainment activity record used by the application and conntected to the database
    /// </summary>

    //[DelimitedRecord(",")]
    //[IgnoreFirst]
    public class Entertainment
    {
        /// <summary>
        /// Represents the ActivityID column for an entertainment activity
        /// </summary>
        public int ActivityID { get; set; }

        /// <summary>
        /// Represents the DateStartTime column for an entertainment activity
        /// </summary>
        public string DateStartTime { get; set; }

        /// <summary>
        /// Represents the Title column for an entertainment activity
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Represents the Cost column for an entertainment activity
        /// </summary>
        public int? Cost { get; set; }

        /// <summary>
        /// Represents the MinParticipants column for an entertainment activity
        /// </summary>
        public int? MinParticipants { get; set; }
    }
}
