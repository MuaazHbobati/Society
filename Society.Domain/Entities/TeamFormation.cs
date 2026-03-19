using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Society.Domain.Enums;

namespace Society.Domain.Entities
{
    public class TeamFormation
    {
        public int Id { get; set; }

        public int CreatorId { get; set; }

        public int ProgramSubjectId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string ClassName { get; set; }

        public int MaxMembers { get; set; }

        public DateTime CreatedAt { get; set; }

        public TeamFormationStatus Status { get; set; } = TeamFormationStatus.Open;

        public int CurrentMembersCount { get; set; } = 1;

        // Navigation
        [ForeignKey("CreatorId")]
        public User Creator { get; set; }

        public ProgramSubject ProgramSubject { get; set; }

        public Team? Team { get; set; }

         
    }

}
