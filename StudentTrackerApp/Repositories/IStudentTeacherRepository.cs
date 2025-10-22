using StudentTrackerApp.Models;
using System.Collections.ObjectModel;

namespace StudentTrackerApp.Repositories
{
	public interface IStudentTeacherRepository
	{
		public Task<List<int>> GetStudentsByTeacherIdAsync(int teacherId);
		public Task<List<int>> GetTeachersByStudentIdAsync(int studentId);

		public Task CreateStudentTeacherRelationAsync(int studentId, int teacherId);

		public Task DeleteStudentTeacherRelationAsync(int studentTeacherId);

		public Task<StudentTeacher?> ReadStudentTeacherByIdAsync(int studentTeacherId);
	}
}
