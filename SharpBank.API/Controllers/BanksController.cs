using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharpBank.API.Models;
using SharpBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly IBankServices bankServices;

        public BanksController(IBankServices bankServices)
        {
            this.bankServices = bankServices;
        }

        [HttpGet]
        public async Task<ActionResult> GetBanks()
        {
            try
            {
                return Ok(await bankServices.GetBanks());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Retrieval Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bank>> GetBank(string id)
        {
            try
            {
                var result = await bankServices.GetBank(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Retrieval Error");
            }

        }

       

    }
}

