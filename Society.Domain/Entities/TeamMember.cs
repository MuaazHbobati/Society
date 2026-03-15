using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Society.Domain.Enums;

namespace Society.Domain.Entities
{
    public class TeamMember
    {
        public int Id { get; set; }

        public int TeamId { get; set; }

        public int UserId { get; set; }

        public TeamRole Role { get; set; }

        // Navigation
        public Team Team { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }


}
