using StudentTrackerApp.Services;
using StudentTrackerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace StudentTrackerApp.Repositories
{
    public class DbStudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _db;
        public DbStudentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ICollection<Student>> ReadAllAsync()
        {
            return await _db.StudentTracker.ToListAsync();
        }

        public async Task<Student> CreateAsync(Student newPerson)
        {
            await _db.StudentTracker.AddAsync(newPerson);
            await _db.SaveChangesAsync();
            return newPerson;
        }

        public async Task<Student?> ReadAsync(int id)
        {
            return await _db.StudentTracker.FindAsync(id);
            //return await _db.Students.FirstOrDefaultAsync((p) => p.Id == id);
        }

        public async Task UpdateAsync(int oldId, Student student)
        {
            Student? studentToUpdate = await ReadAsync(oldId);
            if (studentToUpdate != null)
            {
                studentToUpdate.FirstName = student.FirstName;
                studentToUpdate.LastName = student.LastName;
                studentToUpdate.Email = student.Email;
                studentToUpdate.Password = student.Password;
                studentToUpdate.Teacher = student.Teacher;
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            Student? studentToDelete = await ReadAsync(id);
            if (studentToDelete != null)
            {
                _db.StudentTracker.Remove(studentToDelete);
                await _db.SaveChangesAsync();
            }
        }
    }
}
