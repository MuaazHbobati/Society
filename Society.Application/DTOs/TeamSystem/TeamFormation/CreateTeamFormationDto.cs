using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Application.DTOs.TeamSystem.TeamFormation
{
    public class CreateTeamFormationDto
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public Guid ProgramId { get; set; }

        [Required]
        public Guid SubjectId { get; set; }

        [Range(1, 20)]
        public int MaxMembers { get; set; } = 2;
    }
}
