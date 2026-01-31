using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Application.DTOs.UserProfile
{
    public class UserProfileDto
    {
        public string Bio { get; set; } = null!;
        public string Major { get; set; } = null!;
        public string Faculty { get; set; } = null!;
        public string University { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}
