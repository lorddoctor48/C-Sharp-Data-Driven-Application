using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP.Core.Activities;


namespace OOP_Part_3_Project_Test
{
    [TestClass]
    public class EntertainmentTests
    {
        [TestMethod]
        public void Entertainment_Constructs_WithValidData()
        {
            var e = new Entertainment("2025-12-01 19:30", "Concert", 80, 2);

            Assert.AreEqual("2025-12-01 19:30", e.DateStartTime);
            Assert.AreEqual("Concert", e.Title);
            Assert.AreEqual(80, e.Cost);
            Assert.AreEqual(2, e.MinParticipants);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Entertainment_Throws_WhenTitleMissing()
        {
            _ = new Entertainment("2025-12-01 19:30", "", 80, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Entertainment_Throws_WhenCostNegative()
        {
            _ = new Entertainment("2025-12-01 19:30", "Concert", -1, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Entertainment_Throws_WhenMinParticipantsLessThanTwo()
        {
            _ = new Entertainment("2025-12-01 19:30", "Concert", 80, 1);
        }
    }

    [TestClass]
    public class FitnessTests
    {
        [TestMethod]
        public void Fitness_Constructs_WithValidData()
        {
            var f = new Fitness("2025-12-02 07:00", "Yoga", 25, "Studio A");

            Assert.AreEqual("2025-12-02 07:00", f.DateStartTime);
            Assert.AreEqual("Yoga", f.Title);
            Assert.AreEqual(25, f.Cost);
            Assert.AreEqual("Studio A", f.Location);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Fitness_Throws_WhenLocationMissing()
        {
            _ = new Fitness("2025-12-02 07:00", "Yoga", 25, "");
        }
    }

}
