using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIApplication.Models
{
    public class Prize
    {
        public Prize()
        {
            this.Laureates = new HashSet<Laureates>();
        }
        public int Id { get; set; }

        public string Category { get; set; }

        public int Year { get; set; }

        public virtual ICollection<Laureates> Laureates { get; set; }
    }
}