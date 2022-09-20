using System;
namespace DataAccess.EFCore.Interfaces
{
    public interface IConjunctionRepository : IGenericRepository<Conjuction>
    {
        Conjuction? GetConjuctionByStatementId(int statementId);
    }
}

