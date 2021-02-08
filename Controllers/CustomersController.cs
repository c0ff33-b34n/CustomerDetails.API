using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CustomerDetails.DataLayer;
using CustomerDetailsApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerDetailsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _repo;
        public CustomersController(ICustomerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerNameToReturnDto>> Get()
        {
            var customers = _repo.All()
                .Select(c => _mapper.Map<CustomerNameToReturnDto>(c));

            return Ok(customers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerToReturnDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var customer = _repo.FindById(id);

            if (customer != null){
                var cust = _mapper.Map<CustomerToReturnDto>(customer);
                return Ok(cust);
            }

            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add(CreateCustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                var customer = _mapper.Map<Customer>(customerDto);
                _repo.Insert(customer);
                return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
            }
            else
            {
                return BadRequest("Customer data is not valid");
            }
        }

        [HttpPost("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var customer = _repo.FindById(id);
            if (customer != null)
            {
                _repo.DeleteById(id);
                return Ok();
            }

            return NotFound();
        }
        
    }
}