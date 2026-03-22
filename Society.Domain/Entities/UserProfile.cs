using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Domain.Entities
{
    public class UserProfile
    {
        [Key, ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public string? Bio {  get; set; }
        public string? University { get; set; } = "Syrian Virtual University (SVU)";
        public string? Major { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public string? ProfilePictureUrl { get; set; }

    }
}
