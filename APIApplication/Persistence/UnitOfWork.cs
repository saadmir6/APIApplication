using APIApplication.Core;
using APIApplication.Core.Repositories;
using APIApplication.MyDatabase;
using APIApplication.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIApplication.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDBContext context;

        public UnitOfWork(ApplicationDBContext dbContext)
        {
            context = dbContext;
            Prizes = new PrizeRepository(context);
            Laureates = new LaureateRepository(context);
        }

        public IPrizeRepository Prizes { get; }

        public ILaureateRepository Laureates { get; }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}