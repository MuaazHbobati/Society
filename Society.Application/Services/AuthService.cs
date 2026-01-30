using Society.Application.DTOs.Auth;
using Society.Application.Interfaces.Services;
using Society.Domain.Entities;
using Society.Domain.Enums;
using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Society.Application.Interfaces.Repositories;

namespace Society.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task RegisterAsync(RegisterRequestDto dto)
        {
            if(!Enum.TryParse<Gender>(dto.Gender,true,out var gender))
            {
                throw new Exception("Invalid gender value");
            }

            var person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = dto.FirstName,
                FatherName = dto.FatherName,
                LastName = dto.LastName,
                BirthDate = dto.BirthDate,
                Gender = gender
            };
            await _userRepository.AddPersonAsync(person);

            var user = new User()
            {
                Id = Guid.NewGuid(),
                PersonId = person.Id,
                Username = dto.Username,
                PasswordHash = HashPassword(dto.Password),
                Email = dto.Email
            };
            await _userRepository.AddAsync(user);

            var profile = new UserProfile()
            {
                UserId = user.Id
            };

            await _userRepository.AddProfileAsync(profile);

        }
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
