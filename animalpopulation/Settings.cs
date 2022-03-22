using Microsoft.Extensions.Configuration;

namespace animalpopulation;

public class Settings 
{
     public static int MaleLifeTime;
    public static int FemaleLifeTime;
    public static int LoseOfFertility;
    public static int TimeOfPregnancy;
    public static int NumberOfNewbornRabbits;
    public static int PercentageOfRabbitsBorn;
    public static int Months;
    private readonly IConfiguration _configurationRoot;
    public Settings(IConfiguration configurationRoot)
    {
        _configurationRoot = configurationRoot;
    }
    public void getStatisticConfiguration()
    {
        MaleLifeTime = int.Parse(_configurationRoot.GetSection("Settings")[nameof(MaleLifeTime)]);
        FemaleLifeTime = int.Parse(_configurationRoot.GetSection("Settings")[nameof(FemaleLifeTime)]);
        LoseOfFertility = int.Parse(_configurationRoot.GetSection("Settings")[nameof(LoseOfFertility)]);
        TimeOfPregnancy = int.Parse(_configurationRoot.GetSection("Settings")[nameof(TimeOfPregnancy)]);
        NumberOfNewbornRabbits = int.Parse(_configurationRoot.GetSection("Settings")[nameof(NumberOfNewbornRabbits)]);
        PercentageOfRabbitsBorn = int.Parse(_configurationRoot.GetSection("Settings")[nameof(PercentageOfRabbitsBorn)]);
        Months = int.Parse(_configurationRoot.GetSection("Settings")[nameof(Months)]);
    }
}
