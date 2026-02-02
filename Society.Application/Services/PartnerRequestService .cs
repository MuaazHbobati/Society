using Society.Application.DTOs.PartnerSystem;
using Society.Application.Interfaces.Repositories;
using Society.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Application.Services
{
    public class PartnerRequestService : IPartnerRequestService
    {
        private readonly IPartnerRequestRepository _repository;

        public PartnerRequestService(IPartnerRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> CreateAsync(Guid creatorId, CreatePartnerRequestDto dto)
        {
            return await _repository.CreateAsync(creatorId, dto);
        }

        public async Task<List<PaetnerRequestListDto>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}


