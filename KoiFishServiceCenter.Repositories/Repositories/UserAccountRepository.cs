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

        public async Task<bool> AddUserAccountAsync(UserAccount userAccount)
        {
            try
            {
                await _dbContext.UserAccounts.AddAsync(userAccount);
                await _dbContext.SaveChangesAsync();
                return true;
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

        public async Task<bool> UpdateUserAccountAsync(UserAccount userAccount)
        {
            try
            {
                var existingEntity = await _dbContext.UserAccounts.FindAsync(userAccount.UserId);
                if (existingEntity != null)
                {
                    _dbContext.Entry(existingEntity).State = EntityState.Detached; // Gỡ theo dõi thực thể cũ
                }

                // Đính kèm (attach) thực thể mới và đánh dấu nó đã bị chỉnh sửa
                _dbContext.UserAccounts.Attach(userAccount);
                _dbContext.Entry(userAccount).State = EntityState.Modified;

                //_dbContext.UserAccounts.Update(userAccount);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Lỗi khi cập nhật tài khoản người dùng", ex);
            }
        }
        public async Task<string> CheckAccount(string username, string password)
        {
            var x = await _dbContext.UserAccounts.FirstOrDefaultAsync(p => p.UserName == username && p.Password == password && (p.Role == "Manager" || p.Role == "Staff"));

            if (x == null)
            {
                return "Customer";
            }
            return x.Role;
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

       

        public async Task<bool> CreateAccount(string userName, string passWord, string email)
        {
            var emailExists = await _dbContext.UserAccounts.FirstOrDefaultAsync(m => m.Email == email);
            var userNameExists = await _dbContext.UserAccounts.FirstOrDefaultAsync(m => m.UserName == userName);
            if (userNameExists != null || emailExists != null)
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
            // thêm vào customer
            Customer customer = new Customer();
            Random random1 = new Random();
            int randomID1;
            do
            {
                randomID1 = random1.Next(1, 1001);
                var y = await _dbContext.Customers.Include(c => c.User).FirstOrDefaultAsync(m => m.CustomerId == randomID1);
                if (y == null)
                {
                    break;
                }
            }
            while (true);
            customer.CustomerId = randomID1;
            customer.FullName = "Họ và tên";
            customer.Email = UserAccount.Email;
            customer.UserId = UserAccount.UserId;
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();

            return true;
        }

       

        public async Task<bool> DeleteUserAccount(UserAccount userAccount)
        {
            try
            {
                // Xóa các Feedback liên quan tới các Customer thuộc về UserAccount này
                var relatedCustomers = await _dbContext.Customers
                    .Where(c => c.UserId == userAccount.UserId)
                    .Include(c => c.Feedbacks)
                    .Include(c => c.ServiceHistories)
                    .ToListAsync();

                foreach (var customer in relatedCustomers)
                {
                    // Xóa feedback của từng customer
                    if (customer.Feedbacks.Any())
                    {
                        _dbContext.Feedbacks.RemoveRange(customer.Feedbacks);
                    }
                    // Xóa ServiceHistory của từng customer
                    if (customer.ServiceHistories.Any())
                    {
                        _dbContext.ServiceHistories.RemoveRange(customer.ServiceHistories);
                    }
                }

                // Xóa khách hàng thuộc UserAccount
                _dbContext.Customers.RemoveRange(relatedCustomers);

                // Xóa ServiceHistories và VetSchedules liên quan đến UserAccount
                var vetSchedules = await _dbContext.VetSchedules
                    .Where(v => v.VeterinarianId == userAccount.UserId)
                    .ToListAsync();
                _dbContext.VetSchedules.RemoveRange(vetSchedules);

                var userServiceHistories = await _dbContext.ServiceHistories
                    .Where(s => s.VeterinarianId == userAccount.UserId)
                    .ToListAsync();
                _dbContext.ServiceHistories.RemoveRange(userServiceHistories);

                _dbContext.UserAccounts.Remove(userAccount);

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Lỗi khi xóa tài khoản người dùng và các bản ghi liên quan", ex);
            }
        }

        public async Task<bool> ChangePasswordAsync(string OldPassWord, string NewPassWord, int id)
        {
            try
            {
                var ojb = await GetUserByIdAsync(id);
                if (ojb == null)
                {
                    return false;
                }
                if (ojb.Password != OldPassWord)
                {
                    return false;
                }
                ojb.Password = NewPassWord;
                await UpdateUserAccountAsync(ojb);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public async Task<int> CreateId()
        {
            Random random = new Random();
            int id;
            do
            {
                id = random.Next(1, 1001);
                var ojb = await GetUserByIdAsync(id);
                if (ojb == null)
                {
                    return id;
                }
            } while (true);
        }
    }
}
