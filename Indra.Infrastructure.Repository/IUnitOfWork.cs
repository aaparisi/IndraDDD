using Indra.Infrastructure.Persistence;
using System;

namespace Indra.Infrastructure.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IndraDbContext Context { get; }

        public void Commit();
    }
}
