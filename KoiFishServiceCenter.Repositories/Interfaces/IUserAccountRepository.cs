using KoiFishServiceCenter.Repositories.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishServiceCenter.Repositories.Interfaces
{
    public interface IUserAccountRepository
    {
        Task<List<UserAccount>> GetUserAccountsAsync();  
        Task<UserAccount> GetUserByIdAsync(int id);   
        Task<UserAccount> GetUserByUsernameAsync(string username);  
        Task<bool> AddUserAccountAsync(UserAccount userAccount);  
        Task<bool> DeleteUserAccountAsync(int userId);  
        Task<bool> UpdateUserAccountAsync(UserAccount userAccount);
        Task<string> CheckAccount(string username, string password);
        Task<List<UserAccount>> SearcheAsync(string searchString);
        SelectList GetRoleSelect();
		Task<bool> CreateAccount(string userName,string passWord,string email);
        Task<bool> DeleteUserAccount(UserAccount userAccount);
        Task<bool> ChangePasswordAsync(string OldPassWord,string NewPassWord, int id);
        Task<int> CreateId();
    }
}
