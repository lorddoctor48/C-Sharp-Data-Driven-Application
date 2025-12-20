using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_Part2_WPF_CS.Model
{
    public class Activity
    {
        public int ActivityID { get;  set; }
        public DateTime DateStartTime { get; set; }
        public string Title { get; set; }
        public decimal? Cost { get; set; }

        // Fitness-specific
        public string Location { get; set; }

        // Entertainment-specific
        public int? MinParticipants { get; set; }

    }
}
