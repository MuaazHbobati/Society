using Society.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Application.DTOs.TeamSystem.TeamFormation
{
    public class TeamFormationDetailsDto
    {
        public int Id { get; set; }

        public string TutorName { get; set; }

        public string Description { get; set; }
        public string ClassName { get; set; }

        public string ProgramName { get; set; }

        public string SubjectName { get; set; }

        public int MaxMembers { get; set; }

        public int CurrentMembersCount { get; set; }

        public TeamFormationStatus Status { get; set; }

    }
} 