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
using Microsoft.AspNetCore.Cors;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AngularClient")]
    //[Authorize]
    
    public class SubCourseController : Controller
    {
        private readonly ISubCourseServices _SubcourseServices;


        public SubCourseController(ISubCourseServices SubcourseServices)
        {
            _SubcourseServices = SubcourseServices;
        }


        [HttpGet]
        public  IEnumerable<SubCourseEntity> Get()
        {

            var Subcourses = _SubcourseServices.GetAllSubCourse();
            if (Subcourses != null && Subcourses.Any())
                return Subcourses.ToList();
            return Enumerable.Empty<SubCourseEntity>();
        }

        [HttpPost]
        public IActionResult Post([FromBody]SubCourseEntity subCourse)
        {
            _SubcourseServices.CreateSubCourse(subCourse);
            return Ok(subCourse);          
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var SubCourse = _SubcourseServices.GetSubCourseById(id);
            if (SubCourse == null)
            {
                return NotFound();
            }
            return Ok(SubCourse);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]SubCourseEntity subcourseEntity)
        {
            if (id == subcourseEntity.Id)
            {
                _SubcourseServices.UpdateSubCourse(id, subcourseEntity);

                return Ok(subcourseEntity);
            }
            return NotFound();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _SubcourseServices.DeleteSubCourse(id);
            if (id != 0)
            {
                return Ok(id);
            }
            return NotFound();
        }


    }
}