using Indra.Domain.Entities.Authorization;
using System;

namespace Indra.Web.Dto.Authorization
{
    public class UserTokenDTO
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public TimeSpan Validaty { get; set; }
        public string RefreshToken { get; set; }
        public Guid Id { get; set; }
        public string EmailId { get; set; }
        public Guid GuidId { get; set; }
        public DateTime ExpiredTime { get; set; }

        public static UserTokenDTO MapFromUserTokenEntity(UserTokenEntity userTokenEntity)
        {
            return new UserTokenDTO
            {
                Token = userTokenEntity.Token,
                UserName = userTokenEntity.UserName,
                Validaty = userTokenEntity.Validaty,
                RefreshToken = userTokenEntity.RefreshToken,
                Id = userTokenEntity.Id,
                EmailId = userTokenEntity.EmailId,
                GuidId = userTokenEntity.GuidId,
                ExpiredTime = userTokenEntity.ExpiredTime
            };
        }

        public static UserTokenEntity MapToUserTokenEntity(UserTokenDTO userTokenDto)
        {
            return new UserTokenEntity
            {
                Token = userTokenDto.Token,
                UserName = userTokenDto.UserName,
                Validaty = userTokenDto.Validaty,
                RefreshToken = userTokenDto.RefreshToken,
                Id = userTokenDto.Id,
                EmailId = userTokenDto.EmailId,
                GuidId = userTokenDto.GuidId,
                ExpiredTime = userTokenDto.ExpiredTime
            };
        }
    }
}
