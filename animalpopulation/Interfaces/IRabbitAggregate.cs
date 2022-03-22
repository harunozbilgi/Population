namespace animalpopulation.Interfaces;

public interface IRabbitAggregate<T> where T : class, new()
{
    public IRabbitIterator<T> GetIterator();
}