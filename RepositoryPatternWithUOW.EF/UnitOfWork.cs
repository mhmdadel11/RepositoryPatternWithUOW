using App.Core;
using App.Core.Interfaces;
using App.EF.Data;
using App.EF.Repositories;

namespace App.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IUnitRepository Units { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Units = new UnitsRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}