﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IBusinessServices;
using BusinessEntities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AngularClient")]
    [Authorize]
    public class BatchController : Controller
    {
        private readonly IBatchServices _batchServices;


        public BatchController(IBatchServices batchServices)
        {
            _batchServices = batchServices;
        }


        [HttpGet]
        public IEnumerable<BatchEntity> Get()
        {

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