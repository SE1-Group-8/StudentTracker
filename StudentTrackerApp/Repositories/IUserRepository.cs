using StudentTrackerApp.Models;
using System;

namespace StudentTrackerApp.Repositories
{
	public interface IUserRepository
	{
		Task<ICollection<User>> ReadAllUsersAsync();
		Task<User> CreateUserAsync(User newUser);
		Task<User?> ReadUserAsync(int id);
		Task UpdateUserAsync(int oldId, User user);
		Task DeleteUserAsync(int id);
	}
}
