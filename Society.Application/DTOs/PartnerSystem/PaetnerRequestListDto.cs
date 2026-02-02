using Society.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Application.DTOs.PartnerSystem
{
    public class PaetnerRequestListDto
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public byte AcceptedCount { get; set; }
        public byte MaxPartners {  get; set; }
        public string Program { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string? Description { get; set; }
        public Guid CreatorId { get; set; }
        public string CreatorName { get; set; } = null!;

    }
}
