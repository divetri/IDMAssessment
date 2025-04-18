using Microsoft.AspNetCore.Mvc;
using BusinessFacade;
using DomainObject;

namespace IDMAssessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IServiceManager _facade;
        public CustomerController(IServiceManager facade)
        {
            _facade = facade;
        }
        [HttpGet (Name = "GetCustomer")]
        public IActionResult GetCustomer([FromQuery] CustomerRequest customer)
        {
            try
            {
                var customers = _facade.CustomerFacade.Select(customer);
                var response = new BasicResponse<IEnumerable<Customer>>()
                {
                    Message = "OK",
                    TransactionId = Guid.NewGuid().ToString(),
                    Data = customers
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new BasicResponse<Customer>()
                {
                    Message = "Bad Request",
                    TransactionId = Guid.NewGuid().ToString(),
                    Data = null
                };
                return BadRequest(response);
            }
        }

        [HttpPost(Name = "CreateCustomer")]
        public IActionResult PostCustomer([FromQuery] CustomerCreateRequest customer)
        {
            try
            {
                var customers = _facade.CustomerFacade.Create(customer);
                var response = new BasicResponse<Customer>()
                {
                    Message = "OK",
                    TransactionId = Guid.NewGuid().ToString(),
                    Data = customers
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new BasicResponse<Customer>()
                {
                    Message = "Bad Request",
                    TransactionId = Guid.NewGuid().ToString(),
                    Data = null
                };
                return BadRequest(response);
            }
        }

        [HttpPut(Name = "UpdateCustomer")]
        public IActionResult UpdateCustomer([FromQuery] CustomerUpdateRequest customer)
        {
            try
            {
                var customers = _facade.CustomerFacade.Update(customer);
                var response = new BasicResponse<Customer>()
                {
                    Message = "OK",
                    TransactionId = Guid.NewGuid().ToString(),
                    Data = customers
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new BasicResponse<Customer>()
                {
                    Message = "Bad Request",
                    TransactionId = Guid.NewGuid().ToString(),
                    Data = null
                };
                return BadRequest(response);
            }
        }

        [HttpDelete(Name = "DeleteCustomer")]
        public IActionResult DeleteCustomer([FromQuery] CustomerDeleteRequest customer)
        {
            bool result = false;
            result = _facade.CustomerFacade.Delete(customer);
            var response = new BasicResponse<Customer>()
            {
                Message = result? "OK" : "Bad Request",
                TransactionId = Guid.NewGuid().ToString(),
                Data = null
            };
            if (result)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}