using StudenAdminPortal.Api.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenAdminPortal.Api.Repositories
{
   public  interface IStudentRepository 
    {
        Task<List <Student>> GetStudents();

        Task<Student> GetStudent(Guid Id);

        Task<List<Gender>> GetGender();

        Task<bool> ExistStudent(Guid studentId);

        Task  <Student>  UpdateStudent(Guid Id,Student student);

        Task<Student> AddStudent(Student student);

        Task<bool> UpdateImage(Guid studentId, string image);
    }
}
