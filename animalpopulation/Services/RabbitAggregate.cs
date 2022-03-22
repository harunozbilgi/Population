using animalpopulation.Interfaces;

namespace animalpopulation.Services;

public class RabbitAggregate<T> : IRabbitAggregate<T> where T : class, new()
{
    private List<T> _items = new List<T>();
    public RabbitAggregate(List<T> items)
    {
        _items = items;
    }
    public int Count
    {
        get { return _items.Count; }
    }
    public T this[int index]
    {
        get { return _items[index]; }
        set { _items.Add(value); }
    }
    public IRabbitIterator<T> GetIterator()
    {
        return new RabbitIterator<T>(_items);
    }
}
