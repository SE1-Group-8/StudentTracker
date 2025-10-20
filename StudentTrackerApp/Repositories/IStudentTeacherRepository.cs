using StudentTrackerApp.Models;
using System.Collections.ObjectModel;

namespace StudentTrackerApp.Repositories
{
	public interface IStudentTeacherRepository
	{
		public Task<Collection<Student>> GetStudentsByTeacherIdAsync(int teacherId);
		public Task<Collection<Teacher>> GetTeachersByStudentIdAsync(int studentId);

	}
}
