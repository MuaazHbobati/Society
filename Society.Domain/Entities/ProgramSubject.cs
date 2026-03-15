using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Domain.Entities
{
    public class ProgramSubject
    {
        public int Id { get; set; }

        public int ProgramId { get; set; }
        public Program Program { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public ICollection<TeamFormation> TeamFormations { get; set; } = new List<TeamFormation>();
        public ICollection<Team> Teams { get; set; } = new List<Team>();

    }
}
