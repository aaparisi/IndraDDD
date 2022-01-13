using System;

namespace Indra.Infrastructure.Data.Model
{
    public class User
    {
        public int UserId { get; set; }
        public Guid Guid { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
