using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IBusinessServices;
using BusinessEntities;
using BusinessServices;
using DataAccessLayer;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace FunctionalWebAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AngularClient")]
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentServices _studentServices;

        public StudentController(IStudentServices StudentServices)
        {
            _studentServices = StudentServices;
        }

        [HttpGet]
        public IEnumerable<StudentEntity> Get()
        {

            var Stud = _studentServices.GetAllStudent();
            if (Stud != null && Stud.Any())
                return Stud.ToList();
            return Enumerable.Empty<StudentEntity>();
        }

        [HttpPost]
        public IActionResult Post([FromBody] StudentEntity studententity)
        {
            _studentServices.CreateStudent(studententity);
            return Ok(studententity);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var stud = _studentServices.GetStudentByID(id);
            if (stud == null)
            {
                return NotFound();
            }
            return Ok(stud);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]StudentEntity StudentEntity)
        {
            if (id == StudentEntity.Id)
            {
                _studentServices.UpdateStudent(id, StudentEntity);

                return Ok(StudentEntity);
            }
            return NotFound();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _studentServices.DeleteStudent(id);
            if (id != 0)
            {
                return Ok(id);
            }
            return NotFound();
        }


    }
}