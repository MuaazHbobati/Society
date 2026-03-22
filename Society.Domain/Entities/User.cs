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
        public int Id { get; set; }

        [Required]
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person Person { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;
        public string SVUMail { get; set; } = null!;
        public string Username { get; set; } = null;
        public string PasswordHash { get; set; } = null;
        public bool IsEmailConfirmed { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime LastLoginAt { get; set; }
        public UserProfile? Profile { get; set; }
        public int ProgramId { get; set; }
        public ICollection<TeamMember> TeamMemberships { get; set; }
        public ICollection<TeamFormation> CreatedTeamFormations { get; set; }
        public Program Program { get; set; } = null!;
    }
}