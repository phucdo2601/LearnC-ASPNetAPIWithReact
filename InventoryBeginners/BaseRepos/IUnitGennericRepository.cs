using InventoryBeginners.Models;
using System.Collections.Generic;
using Tools;

namespace InventoryBeginners.BaseRepos
{
    public interface IUnitGennericRepository
    {
        List<Unit> GetItems(string SortProperty, SortOrder sortOrder);

        Unit GetUnit(int id);

        Unit Create(Unit unit);

        Unit Update(Unit unit);

        Unit Delete(Unit unit);
    }
}
