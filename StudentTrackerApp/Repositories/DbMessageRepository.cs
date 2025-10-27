using StudentTrackerApp.Components.Pages;
using StudentTrackerApp.Models;
using StudentTrackerApp.Services;
using Microsoft.EntityFrameworkCore;

namespace StudentTrackerApp.Repositories
{
	public class DbMessageRepository : IMessageRepository
	{
		private readonly ApplicationDbContext _db;
		public DbMessageRepository(ApplicationDbContext db)
		{
			_db = db;
		}
		public async Task<Message> CreateMessageAsync(Message newMessage)
		{
			await _db.MessageDb.AddAsync(newMessage);
			await _db.SaveChangesAsync();
			return newMessage;
		}

		public async Task DeleteMessageAsync(int id)
		{
			Message? messageToDelete = await ReadMessageAsync(id);
			if (messageToDelete != null)
			{
				_db.MessageDb.Remove(messageToDelete);
				await _db.SaveChangesAsync();
			}
		}

		/// <summary>
		/// Probably dont use this! instead use ReadAllMessagesByUserIdAsync() to get all messages pertaining to a user
		/// </summary>
		/// <returns>Every message in the db</returns>
		/// <exception cref="NotImplementedException"></exception>
		public Task<ICollection<Message>> ReadAllMessagesAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<ICollection<Message>> ReadAllMessagesByUserIdAsync(int userId)
		{
			var messages = await _db.MessageDb.Where(m => m.SenderId == userId || m.RecieverId == userId).ToListAsync();
			return messages;
		}

		public async Task<Message?> ReadMessageAsync(int id)
		{
			return await _db.MessageDb.FindAsync(id);
		}

		public async Task UpdateMessageAsync(int oldId, Message message)
		{
			Message? messageToUpdate = await ReadMessageAsync(oldId);
			if (messageToUpdate != null)
			{
				messageToUpdate.Id = message.Id;
				messageToUpdate.SenderId = message.SenderId;
				messageToUpdate.RecieverId = message.RecieverId;
				messageToUpdate.DateTime = message.DateTime;
				messageToUpdate.ReadByReciever = message.ReadByReciever;
				messageToUpdate.MessageContent = message.MessageContent;
				await _db.SaveChangesAsync();
			}
		}
	}
}
