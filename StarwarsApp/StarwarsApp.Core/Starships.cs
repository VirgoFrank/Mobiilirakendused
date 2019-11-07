using System;
using System.Collections.Generic;
using System.Text;

namespace StarwarsApp.Core
{
    public partial class Starships
    {
        
            public long Count { get; set; }
            public object Next { get; set; }
            public object Previous { get; set; }
            public List<StarshipDetails> Results { get; set; }
    }
    public partial class StarshipDetails
    {
            public string Name { get; set; }
            public string model { get; set; }
            public string cost_in_credits { get; set; }
            public string length { get; set; }
            public string crew { get; set; }
            public string passengers { get; set; }
          
        
    }
}
