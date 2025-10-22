using Microsoft.EntityFrameworkCore;
using StudentTrackerApp.Components.Pages;
using StudentTrackerApp.Models;
using StudentTrackerApp.Services;
using System;

namespace StudentTrackerApp.Repositories
{
    public class DbStudentTeacherRepository : IStudentTeacherRepository
    {
        private readonly ApplicationDbContext _db;
        public DbStudentTeacherRepository(ApplicationDbContext db)
        {
            _db = db;
        }

		public async Task CreateStudentTeacherRelationAsync(int studentId, int teacherId)
		{
			StudentTeacher newRelation = new StudentTeacher();
            newRelation.StudentId = studentId;
            newRelation.TeacherId = teacherId;
            await _db.StudentTeacherDb.AddAsync(newRelation);
            await _db.SaveChangesAsync();
            return;
		}

		public async Task DeleteStudentTeacherRelationAsync(int studentTeacherId)
		{
			StudentTeacher? relationToDelete = await ReadStudentTeacherByIdAsync(studentTeacherId);
			if (relationToDelete != null)
			{
				_db.StudentTeacherDb.Remove(relationToDelete);
				await _db.SaveChangesAsync();
			}
		}

		public async Task<List<int>> GetStudentsByTeacherIdAsync(int teacherId)
        {
            List<int> studentIds = new List<int>();

            var studentTeachers  = await _db.StudentTeacherDb.Where(s => s.TeacherId == teacherId).ToListAsync();
            foreach (var student in studentTeachers)
            {
                studentIds.Add(student.StudentId);
            }
            return studentIds;
        }

        public async Task<List<int>> GetTeachersByStudentIdAsync(int studentId)
        {
            List<int> teacherIds = new List<int>();

            var studentTeachers = await _db.StudentTeacherDb.Where(s => s.StudentId == studentId).ToListAsync();
            foreach (var teacher in studentTeachers)
            {
                teacherIds.Add(teacher.TeacherId);
            }
            return teacherIds;
        }

		public async Task<StudentTeacher?> ReadStudentTeacherByIdAsync(int studentTeacherId)
		{
            return await _db.StudentTeacherDb.FindAsync(studentTeacherId);
		}
	}
}
