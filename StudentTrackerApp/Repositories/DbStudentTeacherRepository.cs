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

        public async Task<List<int>> GetStudentsByTeacherIdAsync(int teacherId)
        {
            List<int> studentIds = new List<int>();

            var studentTeachers  = _db.StudentTeacherDb.Where(s => s.TeacherId == teacherId).ToList();
            foreach (var student in studentTeachers)
            {
                studentIds.Add(student.StudentId);
            }
            return studentIds;
        }

        public async Task<List<int>> GetTeachersByStudentIdAsync(int studentId)
        {
            List<int> teacherIds = new List<int>();

            var studentTeachers = _db.StudentTeacherDb.Where(s => s.StudentId == studentId).ToList();
            foreach (var teacher in studentTeachers)
            {
                teacherIds.Add(teacher.TeacherId);
            }
            return teacherIds;
        }
    }
}
