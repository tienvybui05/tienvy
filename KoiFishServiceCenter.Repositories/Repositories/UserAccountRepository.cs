using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Repositories.Interfaces;

namespace KoiFishServiceCenter.Repositories.Repositories
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly KoiVetServicesDbContext _dbContext;
        public UserAccountRepository(KoiVetServicesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> AddUserAccountAsync(UserAccount userAccount)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAccountAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserAccount>> GetUserAccountsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserAccount> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserAccount> GetUserByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveUserAccountAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateUserAccountAsync(UserAccount userAccount)
        {
            throw new NotImplementedException();
        }
    }
}
