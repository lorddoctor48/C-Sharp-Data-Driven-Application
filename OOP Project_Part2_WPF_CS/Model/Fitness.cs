using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_Part2_WPF_CS
{
    /// <summary>
    /// Represents a Fitness activity record used by the application and conntected to the database
    /// </summary>

    //[DelimitedRecord(",")]
    //[IgnoreFirst]
    public class Fitness
    {
        /// <summary>
        /// Represents the ActivityID column for a fitness activity
        /// </summary>
        public int ActivityID { get; set; }

        /// <summary>
        /// Represents the DateStartTime column for a fitness activity
        /// </summary>

        public string DateStartTime { get; set; }

        /// <summary>
        /// Represents the Title column for a fitness activity
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Represents the Cost column for a fitness activity
        /// </summary>
        public int? Cost { get; set; }

        /// <summary>
        /// Represents the Location column for a fitness activity
        /// </summary>
        public string Location { get; set; }
    }
}
