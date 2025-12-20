using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP.Core.Activities;

namespace OOP.Core.Test
{
    [TestClass]

    public class PositiveTests
    {

        [TestMethod]
        public void Entertainment_Throws_WhenDateTimeIsValid()
        {
            _ = new Entertainment("2025-12-31 19:30", "Concert", 10, 2);
        }
        [TestMethod]
        public void Entertainment_Throws_WhenTitleIsAtLeastThreeCharacters()
        {
            _ = new Entertainment("2025-12-31 19:30", "Concert", 80, 2);
        }

        [TestMethod]
        public void Entertainment_Throws_WhenCostIsPositive()
        {
            _ = new Entertainment("2025-12-31 19:30", "Concert", 10, 2);
        }

        [TestMethod]
        public void Entertainment_Throws_WhenMinPartcipantstIsValid()
        {
            _ = new Entertainment("2025-12-31 19:30", "Concert", 10, 2);
        }

        [TestMethod]
        public void Fitness_Throws_WhenDateTimeIsValid()
        {
            _ = new Fitness("2025-12-31 19:30", "Walking", 0, "Macquarie Park");
        }
        [TestMethod]
        public void Fitness_Throws_WhenTitleIsAtLeastThreeCharacters()
        {
            _ = new Fitness("2025-12-31 19:30", "Walking", 0, "Macquarie Park");
        }

        [TestMethod]
        public void Fitness_Throws_WhenCostIsPositive()
        {
            _ = new Fitness("2025-12-31 19:30", "Walking", 0, "Macquarie Park");
        }

    }
}
