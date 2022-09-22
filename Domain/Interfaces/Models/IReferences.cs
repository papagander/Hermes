namespace Domain.Interfaces.Models;

public interface IReferences<T> : IIndexed where T : IIndexed
{
    public int TDex { get; set; }
    public T MyT { get; set; }
}
