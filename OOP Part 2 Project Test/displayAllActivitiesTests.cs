using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileHelpers;
namespace OOP_Part_2_Project_Test
{
    [TestClass]
    public sealed class displayAllActivitiesTests
    {
         
        [TestMethod]
        public void displayAllEntertainmentActivities()
        {
            var engine = new FileHelperEngine <Entertainment> ();
            var records = engine.ReadFile("EntertainmentActivities.csv");
            Assert.IsNotNull(records);
        }

        [TestMethod]
        public void displayAllFitnessActivities()
        {
            var engine = new FileHelperEngine<Fitness>();
            var records = engine.ReadFile("FitnessActivities.csv");
            Assert.IsNotNull(records);
        }
    }
}