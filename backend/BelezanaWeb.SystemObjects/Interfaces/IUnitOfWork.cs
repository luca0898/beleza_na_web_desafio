using System;
using System.Threading;
using System.Threading.Tasks;

namespace BelezanaWeb.SystemObjects.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        Task CommitAsync(CancellationToken cancellationToken);
    }
}
