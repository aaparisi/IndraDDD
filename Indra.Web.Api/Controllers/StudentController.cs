using Indra.Application.Services.Interfaces;
using Indra.Web.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Indra.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IEnumerable<StudentDTO>> Get()
        {
            var res = await _studentService.GetAll();
            return StudentDTO.MapFromStudentEntityList(res);
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<StudentDTO> Get(int id)
        {
            var res = await _studentService.Get(id);
            return StudentDTO.MapFromStudentEntity(res);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<StudentDTO> Post([FromBody] StudentDTO student)
        {
            var res = await _studentService.Insert(StudentDTO.MapToStudentEntity(student));
            return StudentDTO.MapFromStudentEntity(res);


        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] StudentDTO student)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
