using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Application.DTOs.UserProfile
{
    public class UpdateUserProfileDto
    {
        public string? Bio { get; set; }
        public string? Major { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }
}