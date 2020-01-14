using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Landon.Models;
using Landon.Data;
using Microsoft.AspNetCore.Cors;

namespace Landon.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly Context _context;
        public CountriesController(Context context) => _context = context;

        [HttpGet]
        [EnableCors]
        public IEnumerable<Country> Get()
        {
            return _context.Countries.ToList();
        }

        [HttpPost]
        public void Post(Country country)
        {
            _context.Add(country);
            //_context.Customers.Add(country);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(string id, Country country)
        {
            if (id.Equals(country.Id, StringComparison.InvariantCultureIgnoreCase))
            {
                _context.Countries.Update(country);
                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var country = _context.Countries.FirstOrDefault(c => c.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase));
            _context.Countries.Remove(country);
            _context.SaveChanges();
        }
    }
}