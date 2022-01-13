using Indra.Domain.Entities;
using System.Threading.Tasks;

namespace Indra.Application.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserEntity> Insert(UserEntity userEntity);
    }
}
