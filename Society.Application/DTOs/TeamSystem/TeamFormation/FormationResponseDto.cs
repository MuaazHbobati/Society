using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Application.DTOs.TeamSystem.TeamFormation
{
    public class FormationResponseDto
    {
        public List<TeamFormationListDto> Items { get; set; } = new();
        public bool HasMore { get; set; }
    }
}
