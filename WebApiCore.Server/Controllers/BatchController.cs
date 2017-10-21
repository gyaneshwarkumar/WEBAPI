using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.Server.Repository;
using WebApiCore.Server.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebApiCore.Server.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class BatchController : Controller

    {
        IDataAccess<Batch, int> _BatchRepo;
        public BatchController(IDataAccess<Batch, int> b)

        {
            _BatchRepo = b;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Batch> Get()
        {
            var Batchs = _BatchRepo.Get();
            return Batchs;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Batch = _BatchRepo.Get(id);
            if (Batch == null)
            {
                return NotFound();
            }
            return Ok(Batch);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Batch b)
        {
            int res = _BatchRepo.Add(b);
            if (res != 0)
            {
                return Ok();
            }
            return Forbid();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Batch b)
        {
            if (id == b.Id)
            {
               int res =  _BatchRepo.Update(id,b);
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
            int res = _BatchRepo.Delete(id);
            if (res != 0)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
