using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Application.Interfaces.Services
{
    public interface IJwtProvider
    {
        string GenerateToken(Guid userId, string email);
    }
}
