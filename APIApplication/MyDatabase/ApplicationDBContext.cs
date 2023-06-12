using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace APIApplication.MyDatabase
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("APIApplicationConnection")
        {

        }

        public DbSet<Models.Prize> Prizes { get; set; }

        public DbSet<Models.Laureates> Laureates { get; set; }
    }
}