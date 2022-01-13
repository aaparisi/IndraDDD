using Indra.Infrastructure.Data.Model;
using System.Threading.Tasks;

namespace Indra.Infrastructure.Repository.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User> LoginUser(string userName, string password);
    }
}
