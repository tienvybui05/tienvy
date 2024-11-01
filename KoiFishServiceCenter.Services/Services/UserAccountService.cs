using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Repositories.Interfaces;
using KoiFishServiceCenter.Services.Interfaces;

namespace KoiFishServiceCenter.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public UserAccountService(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<List<UserAccount>> GetUserAccountsAsync()
        {
            return await _userAccountRepository.GetUserAccountsAsync();
        }

        public async Task<UserAccount> GetUserByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID không hợp lệ", nameof(id));
            }

            return await _userAccountRepository.GetUserByIdAsync(id);
        }

        public async Task<UserAccount> GetUserByUsernameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username không thể rỗng", nameof(username));
            }

            return await _userAccountRepository.GetUserByUsernameAsync(username);
        }

        public async Task<int> AddUserAccountAsync(UserAccount userAccount)
        {
            if (userAccount == null)
            {
                throw new ArgumentNullException(nameof(userAccount), "Tài khoản không thể null");
            }
            if (string.IsNullOrWhiteSpace(userAccount.UserName))
            {
                throw new ArgumentException("Tên người dùng không thể rỗng", nameof(userAccount.UserName));
            }

            return await _userAccountRepository.AddUserAccountAsync(userAccount);
        }

        public async Task<bool> DeleteUserAccountAsync(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentException("ID không hợp lệ", nameof(userId));
            }

            return await _userAccountRepository.DeleteUserAccountAsync(userId);
        }

        public async Task<int> UpdateUserAccountAsync(UserAccount userAccount)
        {
            if (userAccount == null)
            {
                throw new ArgumentNullException(nameof(userAccount), "Tài khoản không thể null");
            }
            if (userAccount.UserId <= 0)
            {
                throw new ArgumentException("ID không hợp lệ", nameof(userAccount.UserId));
            }

            return await _userAccountRepository.UpdateUserAccountAsync(userAccount);
        }
        public Task<bool> CheckAccount(string username, string password)
        {
            return _userAccountRepository.CheckAccount(username, password);
        }
    }
}
