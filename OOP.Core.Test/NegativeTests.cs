using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP.Core.Activities;
using System;

namespace OOP.Core.Tests
{
    [TestClass]
    public class NegativeTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Entertainment_Throws_WhenDateTimeIsInvalid()
        {
            _ = new Entertainment("2025-12-32 19:30", "Concert", 10, 2);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Entertainment_Throws_WhenTitleIsTooShort()
        {
            _ = new Entertainment("2025-12-31 19:30", "C", 80, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Entertainment_Throws_WhenCostIsNegative()
        {
            _ = new Entertainment("2025-12-31 19:30", "Concert", -10, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Entertainment_Throws_WhenMinPartcipantstIsInvalid()
        {
            _ = new Entertainment("2025-12-31 19:30", "Concert", 10, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Fitness_Throws_WhenDateTimeIsInvalid()
        {
            _ = new Fitness("2025-12-32 19:30", "Walking", 0, "Macquarie Park");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Fitness_Throws_WhenTitleIsTooShort()
        {
            _ = new Fitness("2025-12-31 19:30", "W", 0, "Macquarie Park");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Fitness_Throws_WhenCostIsNegative()
        {
            _ = new Fitness("2025-12-31 19:30", "Walking", -50, "Macquarie Park");
        }
    }
}