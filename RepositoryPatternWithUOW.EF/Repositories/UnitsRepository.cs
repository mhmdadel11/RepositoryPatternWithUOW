using App.Core.Interfaces;
using App.Core.Models.UnitModule;
using App.EF.Data;
using System.Collections.Generic;
using System.Linq;

namespace App.EF.Repositories
{
    public class UnitsRepository : BaseRepository<Unit>, IUnitRepository
    {
        private readonly ApplicationDbContext _context;

        public UnitsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Unit> SpecialMethod()
        {
            return _context.Set<Unit>().ToList();
        }
    }
}