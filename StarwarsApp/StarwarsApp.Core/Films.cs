using System;
using System.Collections.Generic;
using System.Text;

namespace StarwarsApp.Core
{
    public partial class Films
    {
        public long Count { get; set; }
        public object Next { get; set; }
        public object Previous { get; set; }
        public List<FilmDetails> Results { get; set; }
    }

   public partial class FilmDetails
    {
      public  string Title { get; set; }
      public DateTimeOffset release_date { get; set; }
      public string opening_crawl { get; set; }

    }
}
