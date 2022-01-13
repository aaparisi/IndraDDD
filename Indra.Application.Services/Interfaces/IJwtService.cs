using Indra.Domain.Entities.Authorization;
using System.Threading.Tasks;

namespace Indra.Application.Services.Interfaces
{
    public interface IJwtService
    {
        public Task<UserTokenEntity> GetToken(UserLoginEntity userLoginEntity);
    }
}
