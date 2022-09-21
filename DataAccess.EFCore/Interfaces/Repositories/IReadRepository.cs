using System;
namespace DataAccess.EFCore.Interfaces.Repositories
{
    public interface IReadRepository<T> where T : class
    {
        IEnumerable<T> GetRange(IEnumerable<int> indexes);
        T Get(int index);
    }
}

