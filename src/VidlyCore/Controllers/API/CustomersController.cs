using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using VidlyCore.Data;
using VidlyCore.Dtos;
using VidlyCore.Models;

namespace VidlyCore.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Customers")]
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        
        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        // GET /api/Customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        // GET /api/Customers/1
        public IActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return new ObjectResult(customer);
        }

        // POST /api/Customers/1
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
                _context.Customers.Add(customer);
                _context.SaveChanges();

                customerDto.Id = customer.Id;

                return CreatedAtRoute(nameof(GetCustomer), new {id = customer.Id}, customerDto);
            }

        }

        // PUT /api/Customers/1
        [HttpPut]
        public void UpdateCustomer (int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                // TODO: Throw Exception
                // BadRequest
            }
            
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDb == null)
            {
                // TODO: Throw Exception
                // NotFound
            }
            else
            {
                Mapper.Map(customerDto, customerInDb);
                _context.SaveChanges();
            }
        }

        // DELETE /api/Customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                // TODO: Throw Exception
                // NotFound
            }
            else
            {
                _context.Customers.Remove(customerInDb);
                _context.SaveChanges();

            }
        }
    }
}