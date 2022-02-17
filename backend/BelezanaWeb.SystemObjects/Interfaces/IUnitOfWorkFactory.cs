using System.Data;

namespace BelezanaWeb.SystemObjects.Interfaces
{
    public interface IUnitOfWorkFactory<TUnitOfWork> where TUnitOfWork : IUnitOfWork
    {
        IUnitOfWork Create();
        IUnitOfWork Create(IsolationLevel isolationLevel);
    }
}
