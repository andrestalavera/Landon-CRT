using System;
using Landon.Models;

namespace Landon.Models
{
    public class Customer : EntityBase<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Country Country { get; set; }
        public string CountryId { get; set; }
    }
}
