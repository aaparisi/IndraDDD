using Indra.Application.Services.Configuration.Models;
using Indra.Application.Services.Helpers;
using Indra.Application.Services.Interfaces;
using Indra.Domain.Entities;
using Indra.Domain.Entities.Authorization;
using Indra.Infrastructure.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace Indra.Application.Services.Implementations
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IUserRepository _userRepository;

        public JwtService(JwtSettings jwtSettings, IUserRepository userRepository)
        {
            _jwtSettings = jwtSettings;
            _userRepository = userRepository;
        }

        public async Task<UserTokenEntity> GetToken(UserLoginEntity userLoginEntity)
        {
            var loggedUser = UserEntity
                .MapFromUserDataModel(await _userRepository.LoginUser(userLoginEntity.UserName, userLoginEntity.Password));

            if (loggedUser.Equals(new UserEntity()))
                return null;

            var token = JwtHelper.GetTokenKey(new UserTokenEntity
            {
                UserName = loggedUser.UserName,
                GuidId = new Guid(),
                EmailId = loggedUser.Email
            }, _jwtSettings);

            return token;
        }
    }
}
