using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Society.Domain.Enums;

namespace Society.Domain.Entities
{
    public class PartnerApplication
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid RequestId { get; set; }

        [Required]
        public Guid ApplicantId { get; set; } 

        public ApplicationStatus Status { get; private set; } = ApplicationStatus.Pending;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(RequestId))]
        public PartnerRequest PartnerRequest { get; set; } = null!;

        [ForeignKey(nameof(ApplicantId))]
        public User Applicant { get; set; } = null!;

        public void Accept()
        {
            if (Status != ApplicationStatus.Pending)
                throw new InvalidOperationException("Only pending applications can be accepted.");

            Status = ApplicationStatus.Accepted;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Reject()
        {
            if (Status != ApplicationStatus.Pending)
                throw new InvalidOperationException("Only pending applications can be rejected.");

            Status = ApplicationStatus.Rejected;
            UpdatedAt = DateTime.UtcNow;
        }

        public void CancelByApplicant()
        {
            if (Status != ApplicationStatus.Pending)
                throw new InvalidOperationException("Only pending applications can be cancelled.");

            Status = ApplicationStatus.Rejected;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}