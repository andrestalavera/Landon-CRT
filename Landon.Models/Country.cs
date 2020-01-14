using System.Collections.Generic;

namespace Landon.Models
{
    public class Country : EntityBase<string>
    {
        public string Label { get; set; }
        public virtual IEnumerable<Customer> Customers { get; set; }
    }
}
