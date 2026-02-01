using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Society.Domain.Entities;

namespace Society.Application.Interfaces.Repositories
{
    public interface IApplicationRepository
    {
        Task<PartnerApplication?> GetByIdAsync(Guid id);

    }
}
