using Indra.Infrastructure.Data.Model;
using System;

namespace Indra.Domain.Entities
{
    public class UserEntity
    {
        public Guid Guid { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public override bool Equals(object obj)
        {

            if (obj == null || !obj.GetType().Equals(typeof(UserEntity)))
            {
                return false;
            }
            var user = (UserEntity)obj;

            return Guid.Equals(user.Guid)
                && UserName == user.UserName
                && Email == user.Email
                && Password == user.Password;
        }
        public static UserEntity MapFromUserDataModel(User user)
        {
            if (user == null) return new UserEntity();

            return new UserEntity
            {
                Guid = user.Guid,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
            };
        }

        public static User MapToUserDataModel(UserEntity userEntity)
        {
            return new User
            {
                Guid = userEntity.Guid,
                UserName = userEntity.UserName,
                Email = userEntity.Email,
                Password = userEntity.Password
            };
        }
    }
}
