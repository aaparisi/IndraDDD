using Indra.Domain.Entities.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Indra.Web.Dto.Authorization
{
    public class UserLoginDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public static UserLoginEntity MapToUserLoginEntity(UserLoginDTO userLogin)
        {
            return new UserLoginEntity
            {
                UserName = userLogin.UserName,
                Password = userLogin.Password
            };
        }

    }
}
