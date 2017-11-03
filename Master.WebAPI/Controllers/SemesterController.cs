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

namespace MasterWebapi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AngularClient")]
    //[Authorize]

    public class SemesterController : Controller
    {
        private readonly ISemisterServices _SemisterServices;


        public SemesterController(ISemisterServices SemisterServices)
        {
            _SemisterServices = SemisterServices;
        }


        [HttpGet]
        public IEnumerable<SemisterEntity> Get()
        {

            var Semister = _SemisterServices.GetAllSemister();
            if (Semister != null && Semister.Any())
                return Semister.ToList();
            return Enumerable.Empty<SemisterEntity>();
        }

        [HttpPost]
        public IActionResult Post([FromBody]SemisterEntity SemisterEntity)
        {
            _SemisterServices.CreateSemister(SemisterEntity);
            return Ok(SemisterEntity);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Sem = _SemisterServices.GetSemisterByID(id);
            if (Sem == null)
            {
                return NotFound();
            }
            return Ok(Sem);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]SemisterEntity SemisterEntity)
        {
            if (id == SemisterEntity.Id)
            {
                _SemisterServices.UpdateSemister(id, SemisterEntity);

                return Ok(SemisterEntity);
            }
            return NotFound();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _SemisterServices.DeleteSemister(id);
            if (id != 0)
            {
                return Ok(id);
            }
            return NotFound();
        }


    }
}