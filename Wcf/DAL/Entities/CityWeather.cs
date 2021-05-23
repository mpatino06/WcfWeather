using System;
using System.Collections.Generic;

namespace Wcf.DAL.Entities
{
    public partial class CityWeather
    {
        public int IdCityWeather { get; set; }
        public int? IdCity { get; set; }
        public decimal? Temperature { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual City IdCityNavigation { get; set; }
    }
}
