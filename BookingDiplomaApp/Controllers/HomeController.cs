using BookingDomainClassLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingDiplomaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;

        public HomeController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            IQueryable<Apartment> apartmentList =
                context.Apartments
                .Include(t => t.City)
                .Include(t => t.Photos)
                .Include(t => t.Facilities)
                .Include(t => t.Category);
            var apartments = await apartmentList.ToListAsync();
            return View(apartments);
        }
    }
}
