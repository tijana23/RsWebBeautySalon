using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeautySalonT.Data;
using BeautySalonT.Models;

namespace BeautySalonT.Controllers
{
    public class EmployeeServicesController : Controller
    {
        private readonly BeautySalonTContext _context;

        public EmployeeServicesController(BeautySalonTContext context)
        {
            _context = context;
        }

        // GET: EmployeeServices
        public async Task<IActionResult> Index()
        {
            var beautySalonTContext = _context.EmployeeService.Include(e => e.Employee).Include(e => e.Service);
            return View(await beautySalonTContext.ToListAsync());
        }

        // GET: EmployeeServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeService = await _context.EmployeeService
                .Include(e => e.Employee)
                .Include(e => e.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeService == null)
            {
                return NotFound();
            }

            return View(employeeService);
        }

        // GET: EmployeeServices/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id");
            ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Id");
            return View();
        }

        // POST: EmployeeServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,ServiceId")] EmployeeService employeeService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id", employeeService.EmployeeId);
            ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Id", employeeService.ServiceId);
            return View(employeeService);
        }

        // GET: EmployeeServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeService = await _context.EmployeeService.FindAsync(id);
            if (employeeService == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id", employeeService.EmployeeId);
            ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Id", employeeService.ServiceId);
            return View(employeeService);
        }

        // POST: EmployeeServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,ServiceId")] EmployeeService employeeService)
        {
            if (id != employeeService.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeServiceExists(employeeService.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id", employeeService.EmployeeId);
            ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Id", employeeService.ServiceId);
            return View(employeeService);
        }

        // GET: EmployeeServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeService = await _context.EmployeeService
                .Include(e => e.Employee)
                .Include(e => e.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeService == null)
            {
                return NotFound();
            }

            return View(employeeService);
        }

        // POST: EmployeeServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeService = await _context.EmployeeService.FindAsync(id);
            _context.EmployeeService.Remove(employeeService);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeServiceExists(int id)
        {
            return _context.EmployeeService.Any(e => e.Id == id);
        }
    }
}
