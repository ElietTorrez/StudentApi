using Microsoft.EntityFrameworkCore;
using StudenAdminPortal.Api.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenAdminPortal.Api.Repositories
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly StudentAdminContext context;

        public SqlStudentRepository(StudentAdminContext context) 
        {
            this.context = context;
        }

        public async Task<Student> GetStudent(Guid StudentID)
        {
            return await context.Student.Include(nameof(Gender)).Include(nameof(Address)).FirstOrDefaultAsync(student => student.Id== StudentID);

        }

        public async Task<List<Student>> GetStudents()
        {
            return await context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }

        public async Task<List<Gender>> GetGender()
        {
            return await context.Gender.ToListAsync();
        }

        public async Task<bool> ExistStudent(Guid studentId)
        {
            return await context.Student.AnyAsync(x=>x.Id==studentId);
        }

        public async Task<Student> UpdateStudent(Guid Id, Student student)
        {

            var existStudent = await GetStudent(Id);
             if (existStudent!= null)
            {
                existStudent.FirstName = student.FirstName;
                existStudent.LastName = student.LastName;
                existStudent.Address = student.Address;
                existStudent.Email = student.Email;
                existStudent.Mobile = student.Mobile;
                existStudent.GenderId = student.GenderId;
                existStudent.Address.PhysicalAddress = student.Address.PhysicalAddress;
                existStudent.Address.PostalAddress = student.Address.PostalAddress;
                await context.SaveChangesAsync();
                return existStudent;

            }

            return null;
        }

        public async Task<Student> AddStudent(Student student)
        {
          var registro= await  context.Student.AddAsync(student);
            await context.SaveChangesAsync();
            return registro.Entity;
        }

        public async Task<bool> UpdateImage(Guid studentId, string image)
        {
            var student = await GetStudent(studentId);
            if (student != null)
            {
                student.ProfileImageUrl = image;
                await context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
