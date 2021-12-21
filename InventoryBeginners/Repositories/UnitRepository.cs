using InventoryBeginners.BaseRepos;
using InventoryBeginners.Data;
using InventoryBeginners.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tools;

namespace InventoryBeginners.Repositories
{
    public class UnitRepository : IUnitGennericRepository
    {
        private readonly InventoryContext _context;

        public UnitRepository(InventoryContext context)
        {
            _context = context;
        }

        public Unit Create(Unit unit)
        {
            _context.Units.Add(unit);
            _context.SaveChanges();
            return unit;
        }

        public Unit Delete(Unit unit)
        {
            _context.Units.Attach(unit);
            _context.Entry(unit).State = EntityState.Deleted;
            _context.SaveChanges();
            return unit;
        }

        public List<Unit> GetItems(string SortProperty, SortOrder sortOrder)
        {
            List<Unit> units = _context.Units.ToList();

            if (SortProperty.ToLower().Equals("name"))
            {
                if (sortOrder.Equals(SortOrder.Ascending))
                {
                    units = units.OrderBy(n => n.Name).ToList();
                }
                else
                {
                    units = units.OrderByDescending(n => n.Name).ToList();
                }
            }
            else if (SortProperty.ToLower().Equals("description"))
            {
                if (sortOrder.Equals(SortOrder.Ascending))
                {
                    units = units.OrderBy(n => n.Description).ToList();
                }
                else
                {
                    units = units.OrderByDescending(n => n.Description).ToList();
                }
            }
           

            return units;
        }

        public Unit GetUnit(int id)
        {
            Unit unit = _context.Units.Where(u => u.Id == id).FirstOrDefault();
            return unit;
        }

        public Unit Update(Unit unit)
        {
            _context.Units.Attach(unit);
            _context.Entry(unit).State = EntityState.Modified;
            _context.SaveChanges();
            return unit;
        }
    }
}
