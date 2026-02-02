using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Society.Application.DTOs.PartnerSystem;
using Society.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Society.Infrastructure.Data;
using Society.Domain.Entities;
using Society.Domain.Enums;


namespace Society.Infrastructure.Repositories
{
    public class PartnerRequestRepository : IPartnerRequestRepository
    {
        private readonly SocietyDbContext _context;
        public PartnerRequestRepository(SocietyDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> CreateAsync(Guid creatorId, CreatePartnerRequestDto dto)
        {
            var entity = new PartnerRequest
            {
                Id = Guid.NewGuid(),
                CreatorId = creatorId,
                Title = dto.Title,
                Category = dto.Category,
                Program = dto.Program,
                Subject = dto.Subject,
                MaxPartners = dto.RequierdPartnersCount,
                Description = dto.Description,
                Status = Domain.Enums.RequestStatus.Open,
                CreatedAt = DateTime.UtcNow
            };

            _context.PartnerRequests.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<List<PaetnerRequestListDto>> GetAllAsync()
        {
            return await _context.PartnerRequests
                .Include(p => p.Creator)
                .Select(p => new PaetnerRequestListDto
                {
                    Id = p.Id,
                    CategoryName = p.Category.ToString(),
                    Program = p.Program,
                    Subject = p.Subject,
                    MaxPartners = p.MaxPartners,
                    AcceptedCount = (byte)p.Applications.Count(a => a.Status == ApplicationStatus.Accepted),
                    Status = p.Status.ToString(),
                    CreatedAt = p.CreatedAt,
                    Description = p.Description,
                    CreatorId = p.CreatorId,
                    CreatorName = p.Creator.Username
                })
                .ToListAsync();
        }

    }
}