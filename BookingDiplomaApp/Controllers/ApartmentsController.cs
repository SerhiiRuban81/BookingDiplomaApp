using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookingDomainClassLibrary;
using BookingDiplomaApp.Models.ViewModels;
using AutoMapper;
using BookingDiplomaApp.Models.DTOs;

namespace BookingDiplomaApp.Controllers
{
    public class ApartmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public ApartmentsController(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: Apartments
        public async Task<IActionResult> Index()
        {
            var apartments = _context.Apartments.Include(a => a.Category).Include(a => a.City);
            List<ApartmentDTO> apartmentDTOs = mapper.Map<List<ApartmentDTO>>( await apartments.ToListAsync());
            return View(apartmentDTOs);
        }

        // GET: Apartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartments
                .Include(a => a.Category)
                .Include(a => a.City)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apartment == null)
            {
                return NotFound();
            }

            return View(apartment);
        }

        // GET: Apartments/Create
        public IActionResult Create()
        {
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            //ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");
            CreateApartmentVM vM = new CreateApartmentVM
            {
                Cities = new SelectList(_context.Cities, "Id", "Name"),
                Categories = new SelectList(_context.Categories, "Id", "Name")
            };
            return View(vM);
        }

        // POST: Apartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateApartmentVM vM)
        {
            if (ModelState.IsValid)
            {
                //Apartment apartment = new Apartment
                //{
                //    Title = vM.Apartment.Title,
                //    CategoryId = vM.Apartment.CategoryId,
                //    CityId = vM.Apartment.CityId,
                //    Address = vM.Apartment.Address,
                //    Description = vM.Apartment.Description,
                //    Places = vM.Apartment.Places,
                //    Price = vM.Apartment.Price,
                //    DistanceFromCenter = vM.Apartment.DistanceFromCenter,
                //    RoomsCount = vM.Apartment.RoomsCount,
                //    Square = vM.Apartment.Square,
                //};
                Apartment apartment = mapper.Map<Apartment>(vM.Apartment);
                _context.Apartments.Add(apartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            };
            vM.Cities = new SelectList(_context.Cities, "Id", "Name", vM.Apartment.CityId);
            vM.Categories = new SelectList(_context.Categories, "Id", "Name", vM.Apartment.CategoryId);
            return View(vM);
        }

        // GET: Apartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", apartment.CategoryId);
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", apartment.CityId);
            return View(apartment);
        }

        // POST: Apartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Price,CityId,CategoryId,Address,Places,Square,RoomsCount,DistanceFromCenter")] Apartment apartment)
        {
            if (id != apartment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApartmentExists(apartment.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", apartment.CategoryId);
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", apartment.CityId);
            return View(apartment);
        }

        // GET: Apartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartments
                .Include(a => a.Category)
                .Include(a => a.City)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apartment == null)
            {
                return NotFound();
            }

            return View(apartment);
        }

        // POST: Apartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment != null)
            {
                _context.Apartments.Remove(apartment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApartmentExists(int id)
        {
            return _context.Apartments.Any(e => e.Id == id);
        }
    }
}
