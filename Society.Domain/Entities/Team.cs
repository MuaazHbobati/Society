using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Domain.Entities
{
    public class Team
    {
        public int Id { get; set; }

        public int FormationId { get; set; }

        public int ProgramSubjectId { get; set; }

        public string Title { get; set; }

        public DateTime CreatedAt { get; set; }


        // Navigation
        public TeamFormation Formation { get; set; }

        public ProgramSubject ProgramSubject { get; set; }
        public ICollection<TeamMember> Members { get; set; } = new List<TeamMember>();

    }


}
