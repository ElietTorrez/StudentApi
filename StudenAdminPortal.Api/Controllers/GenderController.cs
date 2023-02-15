using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudenAdminPortal.Api.DomainModels;
using StudenAdminPortal.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenAdminPortal.Api.Controllers
{
    [ApiController]
    public class GenderController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;
        public GenderController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetGender()
        {
            var gender = await studentRepository.GetGender();
            //con mapper

            if (gender == null || !gender.Any())
            {
                return NotFound();
            }
            else
            {
                return Ok(mapper.Map<List<Gender>>(gender));
            }

                }
    }
}
