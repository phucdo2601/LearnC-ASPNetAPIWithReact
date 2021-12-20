using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryBeginners.Data;
using InventoryBeginners.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using InventoryBeginners.BaseRepos;

namespace InventoryBeginners.Controllers
{
    public class UnitController : Controller
    {
        public IActionResult Index() // return method of the crud operations. It lists all data from the Units table.
        {
           /* List<Unit> units = _context.Units.ToList();*/

            List<Unit> units = _unitRepo.GetItems();
            return View(units);
        }

        private readonly InventoryContext _context;
        private readonly IUnitGennericRepository _unitRepo;

        public UnitController(InventoryContext context, IUnitGennericRepository unitRepo)
        {
            _context = context;
            _unitRepo = unitRepo;
        }

        public IActionResult Create()
        {
            Unit unit = new Unit();
            return View(unit);
        }

        [HttpPost]
        public IActionResult Create(Unit unit)
        {
            try
            {
                _unitRepo.Create(unit);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);
        }

        public IActionResult Edit(int id)
        {
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);
        }

        [HttpPost]
        public IActionResult Edit(Unit unit)
        {
            try
            {
                unit = _unitRepo.Update(unit);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);
        }

        [HttpPost]
        public IActionResult Delete(Unit unit)
        {
            try
            {
                unit = _unitRepo.Delete(unit);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
