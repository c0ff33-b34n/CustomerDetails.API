using System;
using System.Collections.Generic;
using System.Linq;
using CustomerDetailsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerDetails.DataLayer.EFCore
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _dbContext;
        public CustomerRepository(CustomerContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IEnumerable<Customer> All()
        {
            return _dbContext.Customers;
        }

        public void DeleteById(int customerId)
        {
            var customer = _dbContext.Customers.Find(customerId);
            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
        }

        public Customer FindById(int customerId)
        {
            var customer = _dbContext.Customers.Find(customerId);
            return customer;
        }

        public void Insert(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
        }

        public void Update(Customer customer)
        {
            var cust = _dbContext.Customers.First(c => c.Id == customer.Id);
            _dbContext.Entry(cust).CurrentValues.SetValues(customer);
            _dbContext.SaveChanges();
        }
    }
}