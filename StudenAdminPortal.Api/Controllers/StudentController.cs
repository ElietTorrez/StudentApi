using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudenAdminPortal.Api.DomainModels;
using StudenAdminPortal.Api.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudenAdminPortal.Api.Controllers
{
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IImageRepository imageRepository;
        private readonly IMapper mapper;
        public StudentController(IStudentRepository studentRepository, IMapper mapper, IImageRepository imageRepository)
        {
            this.studentRepository = studentRepository;
            this.imageRepository = imageRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await studentRepository.GetStudents();
            //con mapper

            return Ok(mapper.Map<List<Student>>(students));

            //sin mapper
            //var DomainModelStudent = new List<Student>();

            //foreach (var student in students)
            //{
            //    DomainModelStudent.Add(new Student()
            //    {
            //        Id=student.Id,
            //        FirstName=student.FirstName,
            //        LastName=student.LastName,
            //        DateOfBirth=student.DateOfBirth,
            //        Email=student.Email,
            //        Mobile=student.Mobile,
            //        GenderId = student.GenderId,
            //        Address= new Address() 
            //        { 
            //            Id=student.Address.Id,
            //            PhysicalAddress= student.Address.PhysicalAddress,
            //            PostalAddress= student.Address.PostalAddress,
            //        },
            //        Gender=new Gender()
            //        {
            //            Id=student.Gender.Id,
            //            Description= student.Gender.Description
            //        }
            //    }
            //   );
            //}

            //return Ok(DomainModelStudent);
        }


        [HttpGet]
        [Route("[controller]/{studentID:guid}"),ActionName("GetStudent")]
        public async Task<IActionResult> GetStudent([FromRoute] Guid studentID)
        {
            var student = await studentRepository.GetStudent(studentID);

            if (student == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(mapper.Map<Student>(student));
            }
        }

        [HttpPut]
        [Route("[controller]/{studentID:guid}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] Guid studentID, [FromBody] UpdateStudent student)
        {
            if (await studentRepository.ExistStudent(studentID))
            {
               var update= await studentRepository.UpdateStudent(studentID,mapper.Map<DataModels.Student>(student));
                if (update != null)
                {
                    return Ok(mapper.Map<Student>(update));
                }
            }
           
                return NotFound();
          
         
        }

        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddStudent( [FromBody] AddStudent student)
        {
      
            var add = await studentRepository.AddStudent( mapper.Map<DataModels.Student>(student));
            return CreatedAtAction(nameof(GetStudent),new { 
                studentId= student.Id
            },mapper.Map<Student>(add));
    


        }



        [HttpPost]
        [Route("[controller]/{studentID:guid}/upload")]
        public async Task<IActionResult> uploadImage([FromRoute] Guid studentID, IFormFile image)
        {
            if (await studentRepository.ExistStudent(studentID))
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
               var filePath= await imageRepository.upload(image, fileName);

                if (await studentRepository.UpdateImage(studentID, filePath))
                {
                    return Ok(filePath);
                }
               // return StatusCode(StatusCode.Status500InternalServeError, "Error");
            }
            

            return NotFound();


        }



    }
}
