using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.Server.Repository;
using WebApiCore.Server.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebApiCore.Server.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class CourseController : Controller

    {
        IDataAccess<Course, int> _CourseRepo;
        public CourseController(IDataAccess<Course, int> b)

        {
            _CourseRepo = b;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            var Courses = _CourseRepo.Get();
            return Courses;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Course = _CourseRepo.Get(id);
            if (Course == null)
            {
                return NotFound();
            }
            return Ok(Course);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Course b)
        {
            int res = _CourseRepo.Add(b);
            if (res != 0)
            {
                return Ok();
            }
            return Forbid();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Course b)
        {
            if (id == b.Id)
            {
               int res =  _CourseRepo.Update(id,b);
                if (res != 0)
                {
                    return Ok(res);
                }
                return NotFound();
            }
            return NotFound();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int res = _CourseRepo.Delete(id);
            if (res != 0)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
