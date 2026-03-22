using Society.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Application.DTOs.Auth
{
    public class RegisterRequestDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public int ProgramId { get; set; }
        public string Email { get; set; } = null!;
        public string SVUMail { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; } = null!;

    }
}
