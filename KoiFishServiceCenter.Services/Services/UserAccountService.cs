using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Repositories.Interfaces;
using KoiFishServiceCenter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public async Task<bool> AddUserAccountAsync(UserAccount userAccount)
        {
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

        public async Task<bool> UpdateUserAccountAsync(UserAccount userAccount)
        {
            var listAccount = await _userAccountRepository.GetUserAccountsAsync();
            var y = listAccount;
            var exists = listAccount.FirstOrDefault(x => x.UserName == userAccount.UserName && x.UserId != userAccount.UserId);
            var emailExists = y.FirstOrDefault(x => x.Email == userAccount.Email && x.UserId != userAccount.UserId);
            if (exists != null || emailExists != null)
            {
                return false;
            }
            return await _userAccountRepository.UpdateUserAccountAsync(userAccount);
        }
        public Task<string> CheckAccount(string username, string password)
        {
            return _userAccountRepository.CheckAccount(username, password);
        }

        public async Task<int> CountUserAccount()
        {
            var listAccount = await _userAccountRepository.GetUserAccountsAsync();
            int count = 0;
            foreach (var account in listAccount)
            {
                count++;
            }
            return count;
        }
        public Task<List<UserAccount>> SearcheAsync(string searchString)
        {
            return _userAccountRepository.SearcheAsync(searchString);
        }
        public SelectList GetRoleSelect()
        {
            return _userAccountRepository.GetRoleSelect();
        }

		public async Task<UserAccount> Account(string username, string password)
		{
            var listAccount = await _userAccountRepository.GetUserAccountsAsync();
            var exists = listAccount.FirstOrDefault(p => p.UserName == username && p.Password == password);
            if (exists == null)
            {
                return null;
            }
            return exists;
        }

		public Task<bool> CreateAccount(string userName, string passWord, string email)
		{
			return _userAccountRepository.CreateAccount(userName, passWord, email);
		}

        public async Task<bool> checkEmail(string email)
        {
            var listAccount = await _userAccountRepository.GetUserAccountsAsync();

            var emailExists = listAccount.FirstOrDefault(x => x.Email == email);

            if (emailExists != null)
            {
                return false;
            }
            return true;
        }
        public Task<bool> DeleteUserAccount(UserAccount userAccount)
        {
            return _userAccountRepository.DeleteUserAccount(userAccount);
        }

        public Task<bool> ChangePasswordAsync(string OldPassWord, string NewPassWord, int id)
        {
            return _userAccountRepository.ChangePasswordAsync(OldPassWord, NewPassWord, id);
        }
        public Task<int> CreateId()
        {
            return _userAccountRepository.CreateId();
        }

        public async Task<bool> checkUserName(string userName)
        {
            var listAccount = await _userAccountRepository.GetUserAccountsAsync();

            var userNameExists = listAccount.FirstOrDefault(x => x.UserName == userName);

            if (userNameExists != null)
            {
                return false;
            }
            return true;
        }
    }
}
