using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IBusinessServices;
using BusinessEntities;
using System.Net.Http;
using System.Net;

namespace WebAPI.Controllers
{
     [Route("api/[controller]")]
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ICourseServices _courseServices;


        public CourseController(ICourseServices courseServices)
        {
            _courseServices = courseServices;
        }


        [HttpGet]
        public IEnumerable<CourseEntity> Get()
        {


            var courses = _courseServices.GetAllCourses();
            if (courses!=null && courses.Any())
                return courses.ToList();
            return Enumerable.Empty<CourseEntity>();
        }

        [HttpPost]
        public IActionResult Post([FromBody]CourseEntity course)
        {
            _courseServices.CreateCourse(course);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Course = _courseServices.GetCourseById(id);
            if (Course == null)
            {
                return NotFound();
            }
            return Ok(Course);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CourseEntity course)
        {
            if (id == course.Id)
            {
                _courseServices.UpdateCourse(id, course);

                return Ok(course);
            }
            return NotFound();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _courseServices.DeleteCourse(id);
            if (id != 0)
            {
                return Ok(id);
            }
            return NotFound();
        }


    }
}