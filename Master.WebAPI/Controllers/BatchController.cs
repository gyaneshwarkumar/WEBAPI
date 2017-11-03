using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IBusinessServices;
using BusinessEntities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace MasterWebapi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AngularClient")]
    [Authorize]
    public class BatchController : Controller
    {
        private readonly IBatchServices _batchServices;
        private readonly ILogger<BatchController> _logger;


        public BatchController(IBatchServices batchServices, ILogger<BatchController> logger)
        {
            _batchServices = batchServices;
            _logger = logger;
        }


        [HttpGet]
        public IEnumerable<BatchEntity> Get()
        {
            _logger.LogInformation("Executed Get action");
            var batchs = _batchServices.GetAllBatches();
            if (batchs != null && batchs.Any())
                return batchs.ToList();
            return Enumerable.Empty<BatchEntity>();
        }

        [HttpPost]
        public IActionResult Post([FromBody]BatchEntity batch)
        {
            _batchServices.CreateBatch(batch);
            return Ok(batch);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var batch = _batchServices.GetBatchById(id);
            if (batch == null)
            {
                return NotFound();
            }
            return Ok(batch);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]BatchEntity batch)
        {
            if (id == batch.Id)
            {
                _batchServices.UpdateBatch(id, batch);

                return Ok(batch);
            }
            return NotFound();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _batchServices.DeleteBatch(id);
            if (id != 0)
            {
                return Ok(id);
            }
            return NotFound();
        }


    }
}