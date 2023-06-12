using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIApplication.Models
{
    public class Laureates
    {
        public Laureates()
        {
            this.Prizes = new HashSet<Prize>();
        }
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime? Born { get; set; }

        public DateTime? Died { get; set; }

        public string CountryOfBirth { get; set; }

        public string Gender { get; set; }

        public virtual ICollection<Prize> Prizes { get; set; }

        
    }
}