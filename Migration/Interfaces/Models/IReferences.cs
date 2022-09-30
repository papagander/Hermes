namespace Domain.Interfaces.Models;

public interface IReferences<TRef> : IIndexed where TRef : IIndexed
{
    public int MyTRefId { get; /*set;*/ }
    public TRef MyTRef { get; /*set;*/ }
}
