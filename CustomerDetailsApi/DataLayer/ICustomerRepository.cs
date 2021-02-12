using System.Collections.Generic;
using CustomerDetailsApi.Models;

namespace CustomerDetails.DataLayer
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> All();
        Customer FindById(int customerId);
        void Insert(Customer customer);
        void Update(Customer customer);
        void DeleteById(int customerId);
    }
}