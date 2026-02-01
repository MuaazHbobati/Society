using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Society.Domain.Enums;

namespace Society.Domain.Entities
{
    public class PartnerRequest
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid CreatorId { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public RequestCategory Category { get; set; }

        public RequestStatus Status { get; set; } = RequestStatus.Open;

        [Range(1, 50)]
        public byte MaxPartners { get; set; } = 1;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public User Creator { get; set; } = null!;

        public ICollection<PartnerApplication> Applications { get; set; } = new List<PartnerApplication>();

        [Timestamp]
        public byte[] RowVersion { get; set; } = null!;

        public int AcceptedCount
        {
            get
            {
                var count = 0;
                foreach (var a in Applications)
                    if (a.Status == ApplicationStatus.Accepted) count++;
                return count;
            }
        }

        public void CheckIfFilled()
        {
            if (Status != RequestStatus.Open) return;
            if (AcceptedCount >= MaxPartners)
            {
                Status = RequestStatus.Filled;
                UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}