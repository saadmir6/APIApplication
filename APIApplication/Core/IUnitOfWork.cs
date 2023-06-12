using APIApplication.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIApplication.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IPrizeRepository Prizes { get; }

        ILaureateRepository Laureates { get; }

        int Complete();
    }
}
