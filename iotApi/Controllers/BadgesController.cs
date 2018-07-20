using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iotApi.Models;
using iotApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace iotApi.Controllers
{
    [Route("api/[controller]")]
    public class BadgesController : Controller
    {
        private IBadgeRepository _repo;

        public BadgesController(IBadgeRepository repo)
        {
            this._repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this._repo.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                Badge result = this._repo.Get(id);
                if (result != null)
                {
                    return Ok(result);
                } else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Badge value)
        {
            try
            {
                bool result = await this._repo.Create(value);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Creation failed. No change in database");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/values/5
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] Badge value)
        {
            try
            {
                bool result = await this._repo.Update(value);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Update failed. No change in database");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                bool result = await this._repo.Delete(id);
                if (result)
                {
                    return Ok();
                } else
                {
                    return BadRequest("Delete failed. No change in database");
                }
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
