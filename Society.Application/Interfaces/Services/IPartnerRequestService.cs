using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Society.Application.DTOs.PartnerSystem;

namespace Society.Application.Interfaces.Services
{
    public interface IPartnerRequestService
    {
        Task<Guid> CreateAsync(Guid creatorId, CreatePartnerRequestDto dto);
        Task<List<PaetnerRequestListDto>> GetAllAsync();
    }
}