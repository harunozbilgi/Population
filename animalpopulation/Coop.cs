using animalpopulation.Entities;
using animalpopulation.Entities.Rabbits;
using Microsoft.Extensions.Options;

namespace animalpopulation;

public class Coop
{
    public List<MaleRabbit> maleRabbits = new List<MaleRabbit>();
    public List<FemaleRabbit> femaleRabbits = new List<FemaleRabbit>();
    private int percentageofRabbitsBorn;
    private int numberofNewbornRabbits;

    public Coop()
    {
        this.numberofNewbornRabbits = Settings.NumberOfNewbornRabbits;
        this.percentageofRabbitsBorn = Settings.PercentageOfRabbitsBorn;
    }
    public Rabbit getGenderRabbits(Gender gender, bool isPregnant = false)
    {
        Rabbit rabbit = null;
        if (gender.Equals(Gender.Male))
        {
            maleRabbits.Add(new MaleRabbit(Settings.MaleLifeTime));
        }
        else if (gender.Equals(Gender.Female))
        {
            femaleRabbits.Add(new FemaleRabbit());
        }
        return rabbit;
    }
    public int getPercentageofRabbitsBorn()
    {
        return percentageofRabbitsBorn;
    }
    public void setPercentageofRabbitsBorn(int percentageofRabbitsBorn)
    {
        this.percentageofRabbitsBorn = percentageofRabbitsBorn;
    }
    public int getNumberofNewbornRabbits()
    {
        return numberofNewbornRabbits;
    }
    public void setNumberofNewbornRabbits(int numberofNewbornRabbits)
    {
        this.numberofNewbornRabbits = numberofNewbornRabbits;
    }
}