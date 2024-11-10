using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KoiFishServiceCenter.Repositories.Repositories
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly KoiVetServicesDbContext _dbContext;
        public UserAccountRepository(KoiVetServicesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddUserAccountAsync(UserAccount userAccount)
        {
            try
            {
                await _dbContext.UserAccounts.AddAsync(userAccount);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Lỗi khi thêm tài khoản người dùng", ex);
            }
        }

        public async Task<bool> DeleteUserAccountAsync(int userId)
        {
            try
            {
                var userAccount = await _dbContext.UserAccounts.FindAsync(userId);
                if (userAccount != null)
                {
                    _dbContext.UserAccounts.Remove(userAccount);
                    return await _dbContext.SaveChangesAsync() > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Lỗi khi xóa tài khoản người dùng", ex);
            }
        }

        public async Task<List<UserAccount>> GetUserAccountsAsync()
        {
            try
            {
                return await _dbContext.UserAccounts.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Lỗi khi lấy danh sách tài khoản người dùng", ex);
            }
        }

        public async Task<UserAccount> GetUserByIdAsync(int id)
        {
            try
            {
                return await _dbContext.UserAccounts.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Lỗi khi lấy tài khoản người dùng theo ID", ex);
            }
        }

        public async Task<UserAccount> GetUserByUsernameAsync(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("Tên người dùng không thể null hoặc rỗng", nameof(userName));
            }

            try
            {
                return await _dbContext.UserAccounts
                                       .Where(p => p.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase))
                                       .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Lỗi khi lấy tài khoản người dùng theo tên", ex);
            }
        }

        public async Task<int> UpdateUserAccountAsync(UserAccount userAccount)
        {
            try
            {
                _dbContext.UserAccounts.Update(userAccount);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Lỗi khi cập nhật tài khoản người dùng", ex);
            }
        }
        public async Task<string> CheckAccount(string username, string password)
        {
            var x = await _dbContext.UserAccounts.FirstOrDefaultAsync(p => p.UserName == username && p.Password == password&&(p.Role == "Manager"|| p.Role == "Staff"));
            
            if (x == null)
            { 
                return "Customer";
            }
            return x.Role;
        }

        public async Task<int> CountUserAccount()
        {
            int count = 0;
            var ojb = await _dbContext.UserAccounts.ToListAsync();
            foreach (var i in ojb)
            {
                count++;
            }
            return count;
        }
        public async Task<List<UserAccount>> SearcheAsync(string searchString)
        {
            return await _dbContext.UserAccounts
               .Where(u => u.UserName.Contains(searchString)
                    || u.Email.Contains(searchString)
                    || u.Role.Contains(searchString))
               .Include(u => u.Customers)
               .Include(u => u.ServiceHistories)
               .Include(u => u.VetSchedules)
               .ToListAsync();
        }
        public SelectList GetRoleSelect()
        {
            var roles = new List<string> { "Guest", "Customer", "Veterinarian", "Staff", "Manager" };
            return new SelectList(roles);
        }

		public async Task<UserAccount> Account(string username, string password)
		{
			var ojb = await _dbContext.UserAccounts.FirstOrDefaultAsync(p => p.UserName == username && p.Password == password);

			if (ojb == null)
			{
				return null;
			}
			return ojb;
		}

		public async Task<bool> CreateAccount(string userName, string passWord, string email)
		{
            var emailExists = await _dbContext.UserAccounts.FirstOrDefaultAsync(m => m.Email == email);
            var userNameExists = await _dbContext.UserAccounts.FirstOrDefaultAsync(m =>m.UserName == userName);
            if (userNameExists != null||emailExists!=null)
            {
                return false;
            }
			UserAccount UserAccount = new UserAccount();

			Random random = new Random();
			int ranDomID;
			do
			{
				ranDomID = random.Next(1, 1001);
				var x = await GetUserByIdAsync(ranDomID);
				if (x == null)
				{
					break;
				}
			} while (true);
			UserAccount.UserId = ranDomID;
			UserAccount.Role = "Customer";
			UserAccount.Email = email;
            UserAccount.Password = passWord;
            UserAccount.UserName = userName;
            await AddUserAccountAsync(UserAccount);
            return true;
		}

        public async Task<bool> checkEmail(string email)
        {
            var emailExists = await _dbContext.UserAccounts.FirstOrDefaultAsync(m => m.Email == email);
            if(emailExists != null)
            {
                return false;
            }
            return true;
        }
    }
}
