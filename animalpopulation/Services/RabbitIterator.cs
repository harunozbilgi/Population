using animalpopulation.Interfaces;

namespace animalpopulation.Services;

public class RabbitIterator<T> : IRabbitIterator<T> where T : class, new()
{
    private readonly List<T> _rabbits;
    private int _currentIndex = 0;

    public RabbitIterator(List<T> rabbits)
    {
        _rabbits = rabbits;
    }

    public T CurrentItem()
    {
        return _rabbits[_currentIndex];
    }

    public T First()
    {
        _currentIndex = 0;
        return _rabbits[0];
    }

    public bool IsDone()
    {
        return _currentIndex < _rabbits.Count;
    }

    public T Next()
    {
        _currentIndex++;
        if (IsDone())
            return _rabbits[_currentIndex];
        else
            return null;
    }

    public void Remove()
    {
        _rabbits.RemoveAt(_currentIndex);
    }
}
