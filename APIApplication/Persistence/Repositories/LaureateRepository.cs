using APIApplication.Core.Repositories;
using APIApplication.Models;
using APIApplication.MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIApplication.Persistence.Repositories
{
    public class LaureateRepository : GenericRepository<Laureates>, ILaureateRepository
    {
        public LaureateRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
    }
}