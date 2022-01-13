using Indra.Application.Services.Interfaces;
using Indra.Domain.Entities;
using Indra.Infrastructure.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace Indra.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        private IUserRepository _userRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<UserEntity> Insert(UserEntity userEntity)
        {
            userEntity.Guid = new Guid();
            var result = await _userRepository.InsertAsync(UserEntity.MapToUserDataModel(userEntity));
            _unitOfWork.Commit();
            return UserEntity.MapFromUserDataModel(result);
        }
    }
}
