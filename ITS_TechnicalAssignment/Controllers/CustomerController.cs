using ITS_TechnicalAssignment.API.Models;
using ITS_TechnicalAssignment.BussinessLogic.Services;
using ITS_TechnicalAssignment.DataAccess.DTOs;
using ITS_TechnicalAssignment.DataAccess.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ITS_TechnicalAssignment.API.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService CustomerService;
        private readonly IResponse<CustomerDto> response;

        public CustomerController(ICustomerService CustomerService,IResponse<CustomerDto> response)
        {
            this.CustomerService = CustomerService;
            this.response = response;
        }

        [HttpGet("GetCustomers")]
        public async Task<IActionResult> GetCustomers(int pageSize = 0,int pageNumber = 0)
        {
            try
            {
                List<CustomerDto> customers = CustomerService.GetCustomers(pageSize, pageNumber).ToList();
                response.BuildResponse(customers, HttpStatusCode.OK, "Getting data successfully");
                return Ok(response);
            }
            catch(Exception ex)
            {
                response.BuildResponse(HttpStatusCode.InternalServerError, "Something went wrong");
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }

        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                response.HandleModelState(ModelState.Values);
                return BadRequest(response);
            }

            try
            {
                customerDto = CustomerService.CreateCustomer(customerDto);
                response.BuildResponse(customerDto, HttpStatusCode.OK, "Saved successfully");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.BuildResponse(HttpStatusCode.InternalServerError, "Something went wrong");
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }

        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                response.HandleModelState(ModelState.Values);
                return BadRequest(response);
            }

            try
            {
                customerDto = CustomerService.UpdateCustomer(id,customerDto);
                response.BuildResponse(customerDto,HttpStatusCode.OK, "Updated successfully");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.BuildResponse(HttpStatusCode.InternalServerError, "Something went wrong");
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }

        [HttpDelete("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                if (!CustomerService.DeleteCustomer(id))
                {
                    response.BuildResponse(HttpStatusCode.BadRequest, "Something went wrong");
                    return BadRequest(response);
                }

                response.BuildResponse(HttpStatusCode.OK, "Deleted successfully");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.BuildResponse(new CustomerDto(), HttpStatusCode.InternalServerError, "Something went wrong");
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }
    }
}
