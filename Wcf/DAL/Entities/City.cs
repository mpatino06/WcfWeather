using System;
using System.Collections.Generic;

namespace Wcf.DAL.Entities
{
    public partial class City
    {
        public City()
        {
            CityWeather = new HashSet<CityWeather>();
        }

        public int IdCity { get; set; }
        public string Name { get; set; }
        public int IdCountry { get; set; }
        public string Description { get; set; }

        public virtual Country IdCountryNavigation { get; set; }
        public virtual ICollection<CityWeather> CityWeather { get; set; }
    }
}
