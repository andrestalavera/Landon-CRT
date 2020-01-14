using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Landon.Models;
using Landon.Data;

namespace Landon.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly Context _context;
        public CustomersController(Context context) => _context = context;

        [HttpGet]
        public IEnumerable<Customer> Get() => _context.Customers.ToList();

        [HttpGet("{id}")]
        public Customer Get(string id) => _context.Customers
            .FirstOrDefault(c => c.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase));

        [HttpPost]
        public void Post(Customer customer)
        {
            _context.Add(customer);
            //_context.Customers.Add(customer);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(string id, Customer customer)
        {
            if (id.Equals(customer.Id, StringComparison.InvariantCultureIgnoreCase))
            {
                _context.Customers.Update(customer);
                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var customer = _context.Customers
                .FirstOrDefault(customer => 
                customer.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase));
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
