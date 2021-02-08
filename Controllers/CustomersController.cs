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
        public IActionResult Get(int id)
        {
            var customer = _repo.FindById(id);

            if (customer != null){
                var cust = _mapper.Map<CustomerToReturnDto>(customer);
                return Ok(cust);
            }

            return NotFound();
        }

        
    }
}