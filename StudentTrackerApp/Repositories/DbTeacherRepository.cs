using Microsoft.EntityFrameworkCore;
using StudentTrackerApp.Models;
using StudentTrackerApp.Services;

namespace StudentTrackerApp.Repositories
{
    public class DbTeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _db;
        public DbTeacherRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ICollection<Teacher>> ReadAllAsync()
        {
            return await _db.TeacherDb.ToListAsync();
        }

        public async Task<Teacher> CreateAsync(Teacher newTeacher)
        {
            await _db.TeacherDb.AddAsync(newTeacher);
            await _db.SaveChangesAsync();
            return newTeacher;
        }

        public async Task<Teacher?> ReadAsync(int id)
        {
            return await _db.TeacherDb.FindAsync(id);
            //return await _db.Students.FirstOrDefaultAsync((p) => p.Id == id);
        }

        public async Task UpdateAsync(int oldId, Teacher teacher)
        {
            Teacher? teacherToUpdate = await ReadAsync(oldId);
            if (teacherToUpdate != null)
            {
                teacherToUpdate.FirstName = teacher.FirstName;
                teacherToUpdate.LastName = teacher.LastName;
                teacherToUpdate.Email = teacher.Email;
                teacherToUpdate.Password = teacher.Password;
                //teacherToUpdate.Student = teacher.Student;
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            Teacher? teacherToDelete = await ReadAsync(id);
            if (teacherToDelete != null)
            {
                _db.TeacherDb.Remove(teacherToDelete);
                await _db.SaveChangesAsync();
            }
        }
    }
}
