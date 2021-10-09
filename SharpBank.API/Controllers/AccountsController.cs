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
    public class AccountsController : ControllerBase
    {
        private readonly IAccountServices accountServices;

        public AccountsController(IAccountServices accountServices)
        {
            this.accountServices = accountServices;
        }

        [HttpGet]
        public async Task<ActionResult> GetAccounts()
        {
            try
            {
                return Ok(await accountServices.GetAccounts());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Retrieval Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(string id)
        {
            try
            {
                var result = await accountServices.GetAccount(id);
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

        public async Task<ActionResult<Account>> CreateAccount(Account account)
        {
            try
            {
                if (account == null)
                {
                    return BadRequest();
                }
                var newAccount = await accountServices.AddAccount(account);
                return CreatedAtAction(nameof(GetAccount), new { id = newAccount.AccountNumber }, newAccount);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Retrieval Error");
            }

        }

    }
}
