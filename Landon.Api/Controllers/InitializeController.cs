using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Landon.Models;
using Landon.Data;

namespace Landon.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InitializeController : ControllerBase
    {
        private readonly Context _context;
        public InitializeController(Context context) => _context = context;

        [HttpGet]
        public async Task<string> Get()
        {
            for (int i = 0; i < 100; i++)
            {
                await _context.Countries.AddAsync(
                    new Country
                    {
                        Id = Guid.NewGuid().ToString(),
                        Label = Faker.Name.Ethnicity()
                    });

                await _context.Customers.AddAsync(
                    new Customer
                    {
                        Id = Guid.NewGuid().ToString(),
                        FirstName = Faker.Name.FirstName(),
                        BirthDate = Faker.Date.Birthday(18, 30),
                        LastName = Faker.Name.LastName()
                    });
            }

            await _context.SaveChangesAsync();

            return "ok";
        }
    }
}
