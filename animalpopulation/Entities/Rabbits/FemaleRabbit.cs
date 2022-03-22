namespace animalpopulation.Entities.Rabbits;

public class FemaleRabbit : Rabbit
{
    private int TimeofPregnancy;
    private int LoseofFertility;
    private bool _isPregnant;
    public FemaleRabbit()
    {
        LifeTime = Settings.MaleLifeTime;
        TimeofPregnancy = Settings.TimeOfPregnancy;
        LoseofFertility = Settings.LoseOfFertility;
        Age = 0;
        _isPregnant = false;
    }
    public int getTimeofPregnancy()
    {
        return TimeofPregnancy;
    }
    public void setTimeofPregnancy(int timeofPregnancy)
    {
        TimeofPregnancy = timeofPregnancy;
    }
    public int getLoseofFertility()
    {
        return LoseofFertility;
    }
    public void setLoseofFertility(int loseofFertility)
    {
        LoseofFertility = loseofFertility;
    }
    public bool isPregnant()
    {
        return _isPregnant;
    }
    public void setPregnant(bool isPregnant)
    {
        _isPregnant = isPregnant;
    }
}
