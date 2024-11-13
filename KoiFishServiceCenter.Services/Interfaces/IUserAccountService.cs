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
		Task<UserAccount> Account(string username, string password);
		Task<int> CountUserAccount();
        Task<List<UserAccount>> SearcheAsync(string searchString);
        SelectList GetRoleSelect();
		Task<bool> CreateAccount(string userName, string passWord, string email);
        Task<bool> checkEmail(string email);
        Task<bool> DeleteUserAccount(UserAccount userAccount);
        Task<bool> ChangePasswordAsync(string OldPassWord, string NewPassWord, int id);
        Task<int> CreateId();
    }
}
