using App.Core.Models.UnitModule;
using System.Collections.Generic;

namespace App.Core.Interfaces
{
    public interface IUnitRepository : IBaseRepository<Unit>
    {
        IEnumerable<Unit> SpecialMethod();
    }
}