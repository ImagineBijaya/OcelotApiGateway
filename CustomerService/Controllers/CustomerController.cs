using CustomerService.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("getcustomerlist")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            try
            {
                return Ok (await _customerRepository.GetCustomerListAsync());
            }
            catch(Exception)
            {
               
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet("getCustomer/{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id )
        {
            try
            {
                var response = await _customerRepository.GetCustomerByIdAsync(id);

                if (response == null)
                {
                    return NotFound();
                }

                return Ok(response);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost("addcustomer")]
        public async Task<ActionResult<Customer>> AddCustomerAsync([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            try
            {
                var response = await _customerRepository.AddCustomerAsync(customer);
               return CreatedAtAction(nameof(GetCustomer),
                new { id = response.CustomerId }, response);
            }
            catch(Exception)
            {
               return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new employee record");
            }
        }

        [HttpPut("updateCustomer")]
        public async Task<ActionResult> UpdateCustomerAsync([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            try
            {
                var customerToUpdate = await _customerRepository.GetCustomerByIdAsync(customer.CustomerId);

                if (customerToUpdate == null)
                    return NotFound($"Customer  not found");

                var result = await _customerRepository.UpdateCustomerAsync(customer);
                return Ok(result);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("deleteCustomer/{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomerAsync(int id)
        {
            try
            {
                var customerTodelete = await _customerRepository.GetCustomerByIdAsync(id);

                if (customerTodelete == null)
                {
                    return NotFound($"Customer not found");
                }
                var response = await _customerRepository.DeleteCustomerAsync(id);
                return response;
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
              "Error deleting data");
            }
        }
    }
}
