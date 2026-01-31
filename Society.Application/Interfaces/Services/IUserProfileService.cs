using Society.Application.DTOs.UserProfile;
using Society.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Application.Interfaces.Services
{
    public interface IUserProfileService
    {
        Task UpdateMyUserProfileAsync(Guid userId, UpdateUserProfileDto dto);
        Task<UserProfileDto> GetMyProfileAsync(Guid userId);

    }
}