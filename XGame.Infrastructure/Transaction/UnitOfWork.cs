using System;
using XGame.Infrastructure.Persistence.Map;
using System.Data.SqlClient;

namespace XGame.Infrastructure.Transaction
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly XGameContext _context;

        public UnitOfWork(XGameContext context)
        {
            _context = context;
        }
        public void Commit()
        {           
            _context.SaveChanges();
        }
    }
}
