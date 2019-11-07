using System;
using System.Collections.Generic;
using System.Text;

namespace StarwarsApp.Core
{
    public partial class Planets
    {
        public long Count { get; set; }
        public object Next { get; set; }
        public object Previous { get; set; }
        public List<PlanetDetails> Results { get; set; }
    }
    public partial class PlanetDetails
    {
        public string Name { get; set; }
        public string rotation_period { get; set; }
        public string orbital_period { get; set; }
        public string diameter { get; set; }
        public string climate { get; set; }
        public string gravity { get; set; }
        public string terrain { get; set; }
        public string surface_water { get; set; }
        public string population { get; set; }
    }
   
}
