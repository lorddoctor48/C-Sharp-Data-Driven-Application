using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Part_2_Project_Test
{
    [DelimitedRecord(",")]
    [IgnoreFirst]
    public class Fitness
    {
        public string DateStartTime { get; set; }

        public string Title { get; set; }

        public int? Cost { get; set; }

        public string Location { get; set; }
    }
}
