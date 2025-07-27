using BookingDiplomaApp.Models.DTOs;
using BookingDomainClassLibrary;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingDiplomaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ShopUser> userManager;

        public HomeController(ApplicationDbContext context,
            UserManager<ShopUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
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

        public async Task<IActionResult> Details(int id)
        {
            Apartment? apartment = await context.Apartments
                .Include(t=>t.City)
                .Include(t=>t.Photos)
                .Include(t=>t.Facilities)
                .Include(t=>t.Reviews)
                .FirstOrDefaultAsync(t=>t.Id == id);
            if (apartment == null)
                return NotFound();
            return View(apartment);
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmBooking(BookingDTO dTO)
        {
            if(User.Identity is not null && User.Identity.IsAuthenticated)
            {
                ShopUser? shopUser = await userManager.GetUserAsync(User);
                if (shopUser == null) 
                    return RedirectToAction("Login", "Account");
                Booking booking = new Booking()
                {
                    UserId = shopUser.Id,
                    ApartmentId = dTO.ApartmentId,
                    FromDate = dTO.FromDate,
                    TillDate = dTO.TillDate,
                    GuestCount = dTO.GuestCount,
                };
                context.Bookings.Add(booking);
                await context.SaveChangesAsync();
                return View(booking);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> LeaveReview(ReviewDTO dTO)
        {
            if (User.Identity is not null && User.Identity.IsAuthenticated)
            {
                ShopUser? shopUser = await userManager.GetUserAsync(User);
                if (shopUser == null)
                    return RedirectToAction("Login", "Account");
                await context.Entry(shopUser).Collection(t => t.Bookings!).LoadAsync();
                Booking? booking =  shopUser.Bookings.FirstOrDefault(t => t.ApartmentId == dTO.AppartmentId);
                if(booking is not null)
                {
                    Review review = new Review()
                    {
                        BookingId = booking.Id,
                        Date = DateTime.Now,
                        Rating = dTO.Rating,
                        ShopUserId = shopUser.Id,
                        Text = dTO.Text,
                        ApartmentId = dTO.AppartmentId,
                    };
                    context.Reviews.Add(review);
                    await context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                return NotFound();
            }
            return RedirectToAction("Login", "Account");
        }
    }
}
