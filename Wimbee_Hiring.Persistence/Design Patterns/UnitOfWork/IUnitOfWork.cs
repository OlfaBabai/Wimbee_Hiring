using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Wimbee_Hiring.Persistence.Design_Patterns.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private CodingBlastDdContext context;
        public UnitOfWork(CodingBlastDdContext _context)
        {
            context = _context;
        }
        public async Task Commit()
        {
           await context.SaveChangesAsync();
        }

    }
    public interface IUnitOfWork
    {
        public Task Commit();
    }
}
