using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFishServiceCenter.Repositories.Entities;

namespace KoiFishServiceCenter.Services.Interfaces
{
    public interface IUserAccountService
    {
        Task<List<UserAccount>> GetUserAccountsAsync();
        Task<UserAccount> GetUserByIdAsync(int id);
        Task<UserAccount> GetUserByUsernameAsync(string username);
        Task<int> AddUserAccountAsync(UserAccount userAccount);
        Task<bool> RemoveUserAccountAsync(int userId);
        Task<bool> DeleteUserAccountAsync(int userId);
        Task<int> UpdateUserAccountAsync(UserAccount userAccount);
    }
}
