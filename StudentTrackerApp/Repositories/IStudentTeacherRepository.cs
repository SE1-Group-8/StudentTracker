using StudentTrackerApp.Models;
using System.Collections.ObjectModel;

namespace StudentTrackerApp.Repositories
{
	public interface IStudentTeacherRepository
	{
		public Task<List<int>> GetStudentsByTeacherIdAsync(int teacherId);
		public Task<List<int>> GetTeachersByStudentIdAsync(int studentId);

	}
}
