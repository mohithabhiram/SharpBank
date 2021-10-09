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
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionServices transactionServices;

        public TransactionsController(ITransactionServices transactionServices)
        {
            this.transactionServices = transactionServices;
        }

        [HttpGet]
        public async Task<ActionResult> GetTransactions()
        {
            try
            {
                return Ok(await transactionServices.GetTransactions());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Retrieval Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(string id)
        {
            try
            {
                var result = await transactionServices.GetTransaction(id);
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

        [HttpPost]
        public async Task<ActionResult<Transaction>> CreateTransaction(Transaction transaction)
        {
            try
            {
                if (transaction == null)
                {
                    return BadRequest();
                }
                var newTransaction = await transactionServices.AddTransaction(transaction);
                return CreatedAtAction(nameof(GetTransaction), new { id = newTransaction.TransactionID }, newTransaction);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Retrieval Error");
            }

        }

    }
}
