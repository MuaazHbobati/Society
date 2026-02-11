using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Society.Domain.Enums;

namespace Society.Domain.Entities
{
    public class TeamMember
    {
        public Guid Id { get; set; }

        public Guid TeamId { get; set; }

        public Guid UserId { get; set; }

        public TeamRole Role { get; set; }
    }

}
