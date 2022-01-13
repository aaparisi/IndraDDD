using CapgeminiDDD.Infrastructure.Repository;
using Indra.Infrastructure.Data.Model;
using Indra.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Indra.Infrastructure.Repository.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<User> LoginUser(string userName, string password)
        {
            var userExists = _unitOfWork.Context.Users.Any(x =>
                x.UserName == userName);

            if (userExists)
            {
                return await _unitOfWork.Context.Users.FirstOrDefaultAsync(_ =>
                    _.UserName == userName &&
                    _.Password == password);
            }

            return new User();
        }
    }
}
