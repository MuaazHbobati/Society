using Society.Application.DTOs.UserProfile;
using Society.Application.Interfaces.Repositories;
using Society.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Application.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _profileRepository;

        public UserProfileService(IUserProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task UpdateMyUserProfileAsync(Guid userId, UpdateUserProfileDto dto)
        {
            var profile = await _profileRepository.GetByUserIdAsync(userId);

            if (profile == null)
            {
                throw new Exception("Profile not found");
            }

            profile.Bio = dto.Bio;
            profile.City = dto.City;
            profile.University = dto.University;
            profile.Faculty = dto.Faculty;
            profile.Major = dto.Major;

            await _profileRepository.UpdateAsync(profile);
        }

        public async Task<UserProfileDto?> GetMyProfileAsync(Guid userId)
        {
            var profile = await _profileRepository.GetByUserIdAsync(userId);
            if (profile == null)
            {
                return null;
            }

            return new UserProfileDto
            {
                Bio = profile.Bio,
                City = profile.City,
                University = profile.University,
                Faculty = profile.Faculty,
                Major = profile.Major
            };

        }
    }
}
