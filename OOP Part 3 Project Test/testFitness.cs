using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Part_3_Project_Test
{
    public class Fitness
    {
        private string v1;
        private string v2;
        private int v3;
        private string v4;

        public Fitness(string v1, string v2, int v3, string v4)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
        }

        public string DateStartTime { get; set; }

        public string Title { get; set; }

        public int? Cost { get; set; }

        public string Location { get; set; }
    }
}
