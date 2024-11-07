using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFishServiceCenter.Repositories.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KoiFishServiceCenter.Services.Interfaces
{
    public interface IUserAccountService
    {
        Task<List<UserAccount>> GetUserAccountsAsync();
        Task<UserAccount> GetUserByIdAsync(int id);
        Task<UserAccount> GetUserByUsernameAsync(string username);
        Task<int> AddUserAccountAsync(UserAccount userAccount);
        Task<bool> DeleteUserAccountAsync(int userId);
        Task<int> UpdateUserAccountAsync(UserAccount userAccount);
        Task<string> CheckAccount(string username, string password);
        Task<int> CountUserAccount();
        Task<List<UserAccount>> SearcheAsync(string searchString);
        SelectList GetRoleSelect();
    }
}
