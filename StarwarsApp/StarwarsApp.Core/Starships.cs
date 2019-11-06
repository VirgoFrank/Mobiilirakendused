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
            public long cost_in_credits { get; set; }
            public long length { get; set; }
            public long crew { get; set; }
            public long passengers { get; set; }
          
        
    }
}
