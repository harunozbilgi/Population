namespace animalpopulation.Interfaces;

public interface IRabbitIterator<T> where T : class, new()
{
    public T First();
    public T Next();
    public bool IsDone();
    public T CurrentItem();
    public void Remove();

}
