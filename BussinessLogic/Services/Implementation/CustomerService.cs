using ITS_TechnicalAssignment.DataAccess.DTOs;
using ITS_TechnicalAssignment.DataAccess.Models;
using ITS_TechnicalAssignment.DataAccess.Repository;

namespace ITS_TechnicalAssignment.BussinessLogic.Services
{
    public class CustomerService:ICustomerService
    {
        private readonly IRepository<Customer, CustomerDto> customerRepository;

        public CustomerService(IRepository<Customer, CustomerDto> customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IEnumerable<CustomerDto> GetCustomers(int pageSize, int pageNumber)
        {
            var customers = customerRepository.GetAll(pageSize, pageNumber);
            return customers;
        }

        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            Customer customer = customerRepository.Add(customerDto);
            customerRepository.SaveChanges();

            customerDto.Id = customer.Id;
            return customerDto;
        }

        public CustomerDto UpdateCustomer(int id,CustomerDto customerDto)
        {
            customerRepository.Update(id, customerDto);
            customerRepository.SaveChanges();
            return customerDto;
        }

        public bool DeleteCustomer(int id)
        {
                bool isDeleted = customerRepository.Delete(id);
                customerRepository.SaveChanges();
                return isDeleted;
        }
    }
}
