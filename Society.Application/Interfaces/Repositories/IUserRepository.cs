using System;
using Society.Domain.Entities;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task AddPersonAsync(Person person);
        Task AddProfileAsync(UserProfile userProfile);
        Task AddAsync (User user);

        Task<bool> isUsernameExistAsync(string username);
        Task<bool> isEmailExistAsync(string email);

    }
}
