using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Application.DTOs.UserProfile
{
    public class UserProfileDto
    {      
        public string? Bio { get; set; }
        public string? Major { get; set; }
        public string? ProgramName { get; set; }
        public string? University { get; set; }
        public string? City { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Country { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? UserName { get; set; }
        public string SVUMail { get; set; } = null!;
    }
}