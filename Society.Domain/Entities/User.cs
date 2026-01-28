using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Person Person { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string Username { get; set; } = null;
        public string PasswordHash { get; set; } = null;
        public bool IsEmailConfirmed { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime LastLoginAt { get; set; }
        public UserProfile? Profile { get; set; }

    }
}