namespace Domain.Interfaces.Models;

public interface IReferences<TRef> : IIndexed where TRef : IIndexed
{
    public TRef MyTRef { get; /*set;*/ }
    public int MyTRefId { get; /*set;*/ }
}
