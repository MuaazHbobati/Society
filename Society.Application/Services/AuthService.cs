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
using System.Security.Claims;


namespace Society.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly IProgramService _programService;

        public AuthService(IUserRepository userRepository, IJwtProvider jwtProvider, IProgramService programService)
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
            _programService = programService;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto dto)
        {
            var user = await _userRepository.GetUserByEmailAsync(dto.Email);

            if (user == null) 
            {
                throw new Exception("Invalid email or password");
            }

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            {
                throw new Exception("Invalid email or password");
            }

            var Token = _jwtProvider.GenerateToken(user.Id, user.Email);

            return new LoginResponseDto { Token = Token , Message = "Login successful" };
        }

        public async Task RegisterAsync(RegisterRequestDto dto)
        {
            if(await _userRepository.isEmailExistAsync(dto.Email))
            {
                throw new ArgumentException("Email alredy exist");
            }
            if(await _userRepository.isUsernameExistAsync(dto.Username) && !string.IsNullOrEmpty(dto.Username))
            {
                throw new ArgumentException("Username alredy exist");
            }
            var program = await _programService.GetProgramByIdAsync(dto.ProgramId);
            if (program == null)
            {
                throw new ArgumentException("Invalid program selected");
            }
            if (!Enum.TryParse<Gender>(dto.Gender,true,out var gender))
            {
                throw new Exception("Invalid gender value");
            }

            var person = new Person()
            {
                FirstName = dto.FirstName,               
                LastName = dto.LastName,
                BirthDate = dto.BirthDate,
                Gender = gender
            };
            await _userRepository.AddPersonAsync(person);

            var user = new User()
            {
                PersonId = person.Id,
                Username = dto.Username,
                PasswordHash = HashPassword(dto.Password),
                Email = dto.Email,
                SVUMail = dto.SVUMail,
                ProgramId = dto.ProgramId
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
