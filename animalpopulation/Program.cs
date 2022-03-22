using animalpopulation;
using animalpopulation.Entities;
using animalpopulation.Entities.Rabbits;
using animalpopulation.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

using var host = Host.CreateDefaultBuilder(args).Build();
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true, true)
    .AddEnvironmentVariables()
    .Build();

new Settings(config).getStatisticConfiguration();

Coop coop = new Coop();
coop.getGenderRabbits(Gender.Male);
coop.getGenderRabbits(Gender.Female);

for (int month = 0; month <= Settings.Months; month++)
{
    if (coop.femaleRabbits.Count > 0)
    {
        int newBornFemaleRabbit = 0;
        int newBornMaleRabbit = 0;

        coop.femaleRabbits?.ForEach(femaleRabbit =>
        {
            if (femaleRabbit.getLoseofFertility() > femaleRabbit.getAge() && femaleRabbit.getAge() > 0)
            {
                newBornFemaleRabbit += coop.getNumberofNewbornRabbits()
                        * coop.getPercentageofRabbitsBorn() / 100;
                newBornMaleRabbit += coop.getNumberofNewbornRabbits()
                        * (100 - coop.getPercentageofRabbitsBorn()) / 100;
            }
        });

        for (int i = 0; i < newBornFemaleRabbit; i++)
            coop.getGenderRabbits(Gender.Female);

        for (int i = 0; i < newBornMaleRabbit; i++)
            coop.getGenderRabbits(Gender.Male);

        RabbitAggregate<FemaleRabbit> femaleRabbitAggregate = new RabbitAggregate<FemaleRabbit>(coop.femaleRabbits);
        var femaleRabbitIterator = femaleRabbitAggregate.GetIterator();
        femaleRabbitIterator.First();
        while (femaleRabbitIterator.IsDone())
        {
            FemaleRabbit femaleRabbit = femaleRabbitIterator.CurrentItem();
            if (femaleRabbit.getAge() >= femaleRabbit.getLifetime())
                femaleRabbitIterator.Remove();
            else
            {
                if (month != Settings.Months)
                    femaleRabbit.Age += Settings.TimeOfPregnancy;
            }
            femaleRabbitIterator.Next();
        }

        RabbitAggregate<MaleRabbit> maleRabbitAggregate = new RabbitAggregate<MaleRabbit>(coop.maleRabbits);
        var maleRabbitIterator = maleRabbitAggregate.GetIterator();
        maleRabbitIterator.First();
        while (maleRabbitIterator.IsDone())
        {
            MaleRabbit maleRabbit = maleRabbitIterator.CurrentItem();
            if (maleRabbit.getAge() >= maleRabbit.getLifetime())
                maleRabbitIterator.Remove();
            else
            {
                if (month != Settings.Months)
                    maleRabbit.Age += Settings.TimeOfPregnancy;
            }
            maleRabbitIterator.Next();
        }
    }
    month += Settings.TimeOfPregnancy;
}

for (int i = 0; i <= Settings.Months; i++)
{
    int numberFemale = 0;
    int numberMale = 0;

    coop.femaleRabbits?.ForEach(femaleRabbit =>
    {
        if (femaleRabbit.getAge() == i)
            numberFemale++;
    });

    coop.maleRabbits?.ForEach(maleRabbit =>
    {
        if (maleRabbit.getAge() == i)
            numberMale++;
    });

    Console.WriteLine(i + " aylık " + numberFemale + " dişi " + numberMale + " erkek tavşan");
}
Console.ReadLine();