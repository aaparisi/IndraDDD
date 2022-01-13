using Indra.Domain.Entities;

namespace Indra.Web.Dto
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public static UserEntity MapToUserEnity(UserDTO userDto)
        {
            return new UserEntity
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
                Password = userDto.Password,
            };
        }

        public static UserDTO MapFromUserEnity(UserEntity userEntity)
        {
            return new UserDTO
            {
                UserName = userEntity.UserName,
                Email = userEntity.Email,
                Password = userEntity.Password
            };
        }
    }
}
