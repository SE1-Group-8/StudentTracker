using StudentTrackerApp.Models;

namespace StudentTrackerApp.Repositories
{
	public interface IMessageRepository
	{
		Task<ICollection<Message>> ReadAllMessagesAsync();
		Task<Message> CreateMessageAsync(Message newMessage);
		Task<Message?> ReadMessageAsync(int id);
		Task UpdateMessageAsync(int oldId, Message message);
		Task DeleteMessageAsync(int id);

		/// <summary>
		/// Returns all messages that were either sent to or sent by a user
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		Task<ICollection<Message>> ReadAllMessagesByUserIdAsync(int userId);
	}
}
