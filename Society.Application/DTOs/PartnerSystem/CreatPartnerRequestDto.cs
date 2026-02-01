using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Society.Domain.Enums;

namespace Society.Application.DTOs.PartnerSystem
{
    public class CreatPartnerRequestDto
    {
        public RequestCategory Category { get; set; }
        public string Program { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string? Description { get; set; }
        public byte RequierdPartnersCount { get; set; }

    }
}
