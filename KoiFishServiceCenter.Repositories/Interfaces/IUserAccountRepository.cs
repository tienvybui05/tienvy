using KoiFishServiceCenter.Repositories.Entities;
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
        Task<int> AddUserAccountAsync(UserAccount userAccount);  
        Task<bool> DeleteUserAccountAsync(int userId);  
        Task<int> UpdateUserAccountAsync(UserAccount userAccount);
        Task<bool> CheckAccount(string username, string password);
        Task<int> CountUserAccount();
    }
}
