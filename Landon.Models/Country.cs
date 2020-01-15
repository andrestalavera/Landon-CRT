using System.Collections.Generic;
using Newtonsoft.Json;

namespace Landon.Models
{
    public class Country : EntityBase<string>
    {
        public string Label { get; set; }
        
        [JsonIgnore]
        public virtual IEnumerable<Customer> Customers { get; set; }
    }
}
