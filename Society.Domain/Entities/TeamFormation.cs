using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Society.Domain.Enums;

namespace Society.Domain.Entities
{
    public class TeamFormation
    {
        public Guid Id { get; set; }

        public Guid CreatorId { get; set; }

        public Guid ProgramSubjectId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public int MaxMembers { get; set; }

        public DateTime CreatedAt { get; set; }

        public TeamFormationStatus Status { get; set; } = TeamFormationStatus.Open;

        public int CurrentMembersCount { get; set; } = 1;

        // Navigation
        public ProgramSubject ProgramSubject { get; set; }

        public Team? Team { get; set; }
    }

}
