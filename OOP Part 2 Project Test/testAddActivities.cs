namespace OOP_Part_2_Project_Test;

[TestClass]
public class testAddActivities
{
    [TestMethod]
    public void SaveEntertainmentActivity()
    {
        var engine = new FileHelpers.FileHelperEngine<Entertainment>();
        var newActivity = new Entertainment
        {
            DateStartTime = "2024-07-05 20:00",
            Title = "Concert",
            Cost = 50,
            MinParticipants = 1
        };
        engine.AppendToFile("EntertainmentActivities.csv", new[] { newActivity });
        var records = engine.ReadFile("EntertainmentActivities.csv");
    }

    [TestMethod]
    public void SaveFitnessActivity()
    {   var engine = new FileHelpers.FileHelperEngine<Fitness>();
        var newActivity = new Fitness
        {
            DateStartTime = "2024-07-01 10:00",
            Title = "Yoga Class",
            Cost = 20,
            Location = "Community Center"
        };
        engine.AppendToFile("FitnessActivities.csv", new[] { newActivity });
        var records = engine.ReadFile("FitnessActivities.csv");
    }
}