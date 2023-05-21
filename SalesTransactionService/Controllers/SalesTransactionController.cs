using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesTransactionService.Context;

namespace SalesTransactionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesTransactionController : ControllerBase
    {
        private readonly ISalesTransactionRepository _salesTransactionRepository;
        public SalesTransactionController(ISalesTransactionRepository salesTransactionsRepository)
        {
            _salesTransactionRepository = salesTransactionsRepository;
        }

        [HttpGet("getsalestransactionslist")]
        public async Task<ActionResult<IEnumerable<SalesTransaction>>> GetSalesTransactions()
        {
            try
            {
                return Ok(await _salesTransactionRepository.GetSalesTransactionListAsync());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet("getsalestransaction/{id}")]
        public async Task<ActionResult> GetSalesTransaction(int id)
        {
            try
            {
                var response = await _salesTransactionRepository.GetSalesTransactionByIdAsync(id);

                if (response == null)
                {
                    return NotFound();
                }

                return Ok(response) ;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost("addsalestransaction")]
        public async Task<IActionResult> AddSalesTransactionsAsync([FromBody] SalesTransaction salesTransaction)
        {
            if (salesTransaction == null)
            {
                return BadRequest();
            }

            try
            {
                var response = await _salesTransactionRepository.AddSalesTransactionAsync(salesTransaction);
                return CreatedAtAction(nameof(GetSalesTransaction),
                 new { id = response.SalesTransactionId }, response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Error creating new employee record");
            }
        }

        [HttpPut("updatesalestransactions")]
        public async Task<IActionResult> UpdateSalesTransactionAsync([FromBody] SalesTransaction salesTransaction)
        {
            if (salesTransaction == null)
            {
                return BadRequest();
            }

            try
            {
                var salesTransactionToUpdate = await _salesTransactionRepository.GetSalesTransactionByIdAsync(salesTransaction.SalesTransactionId);

                if (salesTransactionToUpdate == null)
                    return NotFound($"SalesTransaction  not found");

                var result = await _salesTransactionRepository.UpdateSalesTransactionAsync(salesTransaction);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("deletesalestransaction/{id}")]
        public async Task<ActionResult<SalesTransaction>> DeleteSalesTransactionAsync(int id)
        {
            try
            {
                var salesTransactionsTodelete = await _salesTransactionRepository.GetSalesTransactionByIdAsync(id);


                if (salesTransactionsTodelete == null)
                {
                    return NotFound($"SalesTransaction not found");
                }
                var response = await _salesTransactionRepository.DeleteSalesTransactionAsync(id);
                return response;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
              "Error deleting data");
            }
        }
    }
}
