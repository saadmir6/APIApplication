using APIApplication.Core.Repositories;
using APIApplication.Models;
using APIApplication.MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIApplication.Persistence.Repositories
{
    public class PrizeRepository : GenericRepository<Prize>, IPrizeRepository
    {
        public PrizeRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
    }
}