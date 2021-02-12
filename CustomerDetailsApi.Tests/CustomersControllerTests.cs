using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CustomerDetails.DataLayer.EFCore;
using CustomerDetailsApi.Controllers;
using CustomerDetailsApi.Mappers;
using CustomerDetailsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CustomerDetailsApi.Tests
{
    public class CustomersControllerTests
    {
        [Fact]
        public void Get_ReturnsActionResultContainingListOfCustomerNameToReturnDtos_WhenCalled()
        {
            // Arrange
            var repo = GetCustomerRepository();
            var mapper = GetMapper();
            var customersController = new CustomersController(repo, mapper);

            // Act
            var result = customersController.Get();

            // Assert
            Assert.IsType<ActionResult<List<CustomerNameToReturnDto>>>(result);
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void Get_ReturnsActionResultContainingAllCustomerNameToReturnDtos_WhenCalled()
        {
            // Arrange
            var repo = GetCustomerRepository();
            var mapper = GetMapper();
            var customersController = new CustomersController(repo, mapper);

            // Act
            var result = customersController.Get();

            // Assert
            var actionResult = Assert.IsType<ActionResult<List<CustomerNameToReturnDto>>>(result);
            Assert.IsType<List<CustomerNameToReturnDto>>(result.Value);
            Assert.Equal(actionResult.Value.Count(), 5);
            Assert.Equal(actionResult.Value.ElementAt(3).Id, 4);
        }

        private CustomerRepository GetCustomerRepository()
        {
            var options = new DbContextOptionsBuilder<CustomerContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new CustomerContext(options);
            databaseContext.Database.EnsureCreated();

            if (databaseContext.Customers.Count() <= 0)
            {
                for (int i = 1; i <= 5; i++)
                {
                    databaseContext.Customers.Add(
                        new Customer()
                        {
                            Id = i,
                            FirstName = "Stu",
                            LastName = "Bowes",
                            BusinessName = "My Business",
                            BuildingName = "Shop",
                            NumberAndStreet = "10 High Street",
                            LocalityName = "Locality Name",
                            TownOrCity = "Burford",
                            County = "Oxfordshire",
                            PostCode = "OX18 4RG"

                        });
                }
                databaseContext.SaveChanges();
            }

            var customerRepo = new CustomerRepository(databaseContext);
            
            return customerRepo;
        }

        private IMapper GetMapper()
        {
            var config = new MapperConfiguration(opts => {
                opts.AddProfile<CustomerProfile>();
            });

            var mapper = config.CreateMapper();

            return mapper;
        } 
    }
}