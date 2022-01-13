using Indra.Infrastructure.Persistence;
using Indra.Infrastructure.Repository.Interfaces;

namespace Indra.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IndraDbContext Context { get; }

        public UnitOfWork(IndraDbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }


        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
