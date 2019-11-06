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
        public long rotation_period { get; set; }
        public long orbital_period { get; set; }
        public long diameter { get; set; }
        public long climate { get; set; }
        public long gravity { get; set; }
        public string terrain { get; set; }
        public long surface_water { get; set; }
        public long population { get; set; }
    }
   
}
