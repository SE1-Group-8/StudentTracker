using Microsoft.EntityFrameworkCore;
using StudentTrackerApp.Models;
using StudentTrackerApp.Services;

namespace StudentTrackerApp.Repositories
{
	public class DbUserRepository : IUserRepository
	{

		private readonly ApplicationDbContext _db;
		public DbUserRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<User> CreateUserAsync(User newUser)
		{
			await _db.UserDb.AddAsync(newUser);
			await _db.SaveChangesAsync();
			return newUser;
		}

		public async Task DeleteUserAsync(int id)
		{
			User? userToDelete = await ReadUserAsync(id);
			if (userToDelete != null)
			{
				_db.UserDb.Remove(userToDelete);
				await _db.SaveChangesAsync();
			}
		}

		public async Task<ICollection<User>> ReadAllUsersAsync()
		{
			return await _db.UserDb.ToListAsync();
		}

		public async Task<User?> ReadUserAsync(int id)
		{
			return await _db.UserDb.FindAsync(id);
		}

		public async Task UpdateUserAsync(int oldId, User user)
		{
			User? userToUpdate = await ReadUserAsync(oldId);
			if (userToUpdate != null)
			{
				userToUpdate.FirstName = user.FirstName;
				userToUpdate.LastName = user.LastName;
				userToUpdate.Email = user.Email;
				userToUpdate.Password = user.Password;
				userToUpdate.UserType = user.UserType;
				await _db.SaveChangesAsync();
			}
		}
        public async Task<User?> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return null;

            var normalizedEmail = email.Trim().ToLowerInvariant();
            var normalizedPassword = password.Trim();

            return await _db.UserDb
                .FirstOrDefaultAsync(u =>
                    u.Email.ToLower() == normalizedEmail &&
                    u.Password == normalizedPassword);
        }
    }
}
