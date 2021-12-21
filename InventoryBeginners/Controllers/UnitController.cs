using Microsoft.AspNetCore.Mvc;
using InventoryBeginners.Models;
using System.Collections.Generic;

using System;
using InventoryBeginners.BaseRepos;
using Tools;

namespace InventoryBeginners.Controllers
{
    public class UnitController : Controller
    {

        private readonly IUnitGennericRepository _unitRepo;

        public UnitController(IUnitGennericRepository unitRepo)
        {
            _unitRepo = unitRepo;
        }

        

        public IActionResult Index(string sortExpression="") // return method of the crud operations. It lists all data from the Units table.
        {
            /* List<Unit> units = _context.Units.ToList();*/

            SortModel sortModel = new SortModel();

            sortModel.AddColumn("name");
            sortModel.AddColumn("description");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            List<Unit> units = _unitRepo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder);
            return View(units);
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
