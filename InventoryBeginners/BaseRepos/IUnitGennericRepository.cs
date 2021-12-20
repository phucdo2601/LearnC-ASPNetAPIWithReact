using InventoryBeginners.Models;
using System.Collections.Generic;

namespace InventoryBeginners.BaseRepos
{
    public interface IUnitGennericRepository
    {
        List<Unit> GetItems();

        Unit GetUnit(int id);

        Unit Create(Unit unit);

        Unit Update(Unit unit);

        Unit Delete(Unit unit);
    }
}
