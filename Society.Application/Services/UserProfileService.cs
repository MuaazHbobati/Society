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
        private readonly IUserRepository _userRepository;

        public UserProfileService(
            IUserProfileRepository profileRepository,
            IUserRepository userRepository)
        {
            _profileRepository = profileRepository;
            _userRepository = userRepository;
        }

        public async Task UpdateMyUserProfileAsync(int userId, UpdateUserProfileDto dto)
        {
            var profile = await _profileRepository.GetByUserIdAsync(userId);

            if (profile == null)
            {
                throw new Exception("Profile not found");
            }

            // ✅ تحدث فقط إذا القيمة مش null (حماية البيانات)
            if (dto.Bio != null) profile.Bio = dto.Bio;
            if (dto.City != null) profile.City = dto.City;
            if (dto.University != null) profile.University = dto.University;
            if (dto.Faculty != null) profile.Faculty = dto.Faculty;
            if (dto.Major != null) profile.Major = dto.Major;
            if (dto.Country != null) profile.Country = dto.Country;
            if (dto.ProfilePictureUrl != null) profile.ProfilePictureUrl = dto.ProfilePictureUrl;

            profile.UpdatedAt = DateTime.UtcNow;

            await _profileRepository.UpdateAsync(profile);
        }

        public async Task<UserProfileDto?> GetMyProfileAsync(int userId)
        {
            var user = await _userRepository.GetUserWithProfileAsync(userId);
            if (user?.Profile == null) return null;

            var profile = user.Profile;

            return new UserProfileDto
            {
                // من UserProfile
                Bio = profile.Bio,
                City = profile.City,
                University = profile.University,
                Faculty = profile.Faculty,
                Major = profile.Major,
                ProfilePictureUrl = profile.ProfilePictureUrl,
                Country = profile.Country,
                UpdatedAt = profile.UpdatedAt,
                UserId = user.Id,

                // ✅ من User (البيانات الأساسية)
                FirstName = user.Person.FirstName,
                LastName = user.Person.LastName,
                UserName = user.Username,
                Email = user.Email
            };
        }
    }
}