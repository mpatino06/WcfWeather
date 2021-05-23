using System;
using System.Collections.Generic;

namespace Wcf.DAL.Entities
{
    public partial class Country
    {
        public Country()
        {
            City = new HashSet<City>();
        }

        public int IdCountry { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<City> City { get; set; }
    }
}
