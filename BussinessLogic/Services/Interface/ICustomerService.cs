using ITS_TechnicalAssignment.DataAccess.DTOs;
using ITS_TechnicalAssignment.DataAccess.Models;
using ITS_TechnicalAssignment.DataAccess.Repository;


namespace ITS_TechnicalAssignment.BussinessLogic.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetCustomers(int pageSize, int pageNumber);
        CustomerDto CreateCustomer(CustomerDto customerDto);
        CustomerDto UpdateCustomer(int id, CustomerDto customerDto);
        bool DeleteCustomer(int id);
    }
}
