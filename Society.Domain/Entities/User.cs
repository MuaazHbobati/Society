using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person Person { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null;
        public string PasswordHash { get; set; } = null;
        public bool IsEmailConfirmed { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime LastLoginAt { get; set; }
        public UserProfile? Profile { get; set; }
       
    }
}